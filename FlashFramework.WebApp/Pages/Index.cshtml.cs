using FlashFramework.Email.Services;
using FlashFramework.Shared.Modular;
using FlashFramework.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlashFramework.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmailService _emailService;

        public IEnumerable<IModule> Modules { get; }

        public bool HasEmailService => _emailService is not NullEmailService;

        public IndexModel(
            ILogger<IndexModel> logger,
            IEnumerable<IModule> modules,
            IEmailService emailService)
        {
            Modules = modules;
            _logger = logger;
            _emailService = emailService;
        }


        public void OnGet()
        {
        }


        [BindProperty]
        public SendEmailModel SendEmailModel { get; set; }
        public string SendEmailMessage { get; set; }

        public async Task<IActionResult> OnPostSendEmail()
        {
            await _emailService.SendEmail(
                SendEmailModel.ToName,
                SendEmailModel.ToAddress,
                SendEmailModel.Subject,
                SendEmailModel.Body);

            SendEmailModel = null;

            SendEmailMessage = "Successfully!";

            return Page();
        }
    }

    public class SendEmailModel
    {
        public string ToName { get; set; }
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}