using Twilio.Rest.Api.V2010.Account;

namespace SendSMS.Services
{
    public interface ISendSMS
    {
        MessageResource CreateSMS(string phone,string body);
    }
}
