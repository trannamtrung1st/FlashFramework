using FlashFramework.Email.Services;
using FlashFramework.Modules.EmailModule.Smtp.Email.Extensions;
using FlashFramework.Modules.EmailModule.Smtp.Email.Types;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;

namespace FlashFramework.Modules.EmailModule.Smtp.Email.Services
{
    public interface ISimpleEmailService : IEmailService
    {
        SmtpOptions Options { get; }

        Task SendMailAsync(params MimeMessage[] messages);
        Task SendMailAsync(SmtpOptions option, params MimeMessage[] messages);
        void Reconfigure(SmtpOptions option);
    }

    public class SimpleEmailService : ISimpleEmailService
    {
        protected readonly IOptions<SmtpOptions> _preconfigOptions;

        private SmtpOptions _overridenOptions;

        public SimpleEmailService(IOptions<SmtpOptions> options)
        {
            _preconfigOptions = options;
        }

        public void Reconfigure(SmtpOptions options)
        {
            _overridenOptions = options;
        }

        public SmtpOptions Options => _overridenOptions ?? _preconfigOptions.Value;

        public async Task SendEmail(string toName, string toAddress, string subject, string body)
        {
            var message = new MimeMessage()
                .AddFrom(Options.From, Options.FromAddress)
                .AddTo(toName, toAddress)
                .Subject(subject)
                .Body(html: body);

            await SendMailAsync(message);
        }

        public Task SendMailAsync(params MimeMessage[] messages)
        {
            return SendMailAsync(Options, messages);
        }

        public async Task SendMailAsync(SmtpOptions option, params MimeMessage[] messages)
        {
            using (var client = new SmtpClient())
            {
                if (option.SecureSocketOptions.HasValue)
                    client.Connect(option.Host, option.Port, option.SecureSocketOptions.Value);
                else
                    client.Connect(option.Host, option.Port, option.UseSsl);

                client.Authenticate(new NetworkCredential(option.UserName, option.Password));

                foreach (var message in messages)
                    await client.SendAsync(message);

                await client.DisconnectAsync(option.QuitAfterSending);
            }
        }
    }
}
