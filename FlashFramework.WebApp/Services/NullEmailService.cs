using FlashFramework.Email.Services;

namespace FlashFramework.WebApp.Services
{
    public class NullEmailService : IEmailService
    {
        public Task SendEmail(string toName, string toAddress, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}
