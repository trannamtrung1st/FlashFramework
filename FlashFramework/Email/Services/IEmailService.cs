namespace FlashFramework.Email.Services
{
    public interface IEmailService
    {
        Task SendEmail(string toName, string toAddress, string subject, string body);
    }
}
