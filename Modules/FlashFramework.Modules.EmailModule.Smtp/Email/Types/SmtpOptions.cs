using MailKit.Security;

namespace FlashFramework.Modules.EmailModule.Smtp.Email.Types
{
    public class SmtpOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }
        public SecureSocketOptions? SecureSocketOptions { get; set; }
        public bool QuitAfterSending { get; set; } = true;

        public string From { get; set; }
        public string FromAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
