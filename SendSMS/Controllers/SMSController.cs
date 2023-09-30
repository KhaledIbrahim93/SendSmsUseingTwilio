using Microsoft.AspNetCore.Mvc;
using SendSMS.Dtos;
using SendSMS.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SendSMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISendSMS _sendSMS;
        public SMSController(ISendSMS sendSMS)
        {
            _sendSMS = sendSMS;
        }
        [HttpPost("SendSms")]
        public IActionResult SendSms(Message ms)
        {
            try
            {
                var res = _sendSMS.CreateSMS(ms.PhoneNumber, ms.Body);
                if (!string.IsNullOrEmpty(res.ErrorMessage))
                {
                    return BadRequest();
                }
                return Ok("Message Send Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

   
        }
    }
}
