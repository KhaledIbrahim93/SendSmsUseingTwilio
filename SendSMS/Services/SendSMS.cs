using Microsoft.Extensions.Options;
using SendSMS.Dtos;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SendSMS.Services
{
    public class SendSMS : ISendSMS
    {
        private readonly TwilloSetting _twilloSetting;

        public SendSMS(IOptions<TwilloSetting>  twilloSetting)
        {
            _twilloSetting = twilloSetting.Value;
        }

       public MessageResource CreateSMS(string phone, string body)
        {
            TwilioClient.Init(_twilloSetting.AccountSID, _twilloSetting.Token);
            var resulte= MessageResource.Create(
                body: body,
                from: new Twilio.Types.PhoneNumber(_twilloSetting.PhoneNumber),
                to: phone
                );
            return resulte;
        }
    }
}
