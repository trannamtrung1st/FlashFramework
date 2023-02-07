using FlashFramework.Modules.EmailModule.Smtp.Email.Services;
using FlashFramework.Modules.EmailModule.Smtp.Email.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FlashFramework.Modules.EmailModule.Smtp.Pages.Shared.Sample
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISimpleEmailService _simpleEmailService;

        public IndexModel(ILogger<IndexModel> logger,
            ISimpleEmailService simpleEmailService)
        {
            _logger = logger;
            _simpleEmailService = simpleEmailService;
        }

        [BindProperty]
        public SmtpOptions Options { get; set; }

        public void OnGet()
        {
            Options = _simpleEmailService.Options;
        }

        public void OnPost()
        {
            _simpleEmailService.Reconfigure(Options);
        }
    }
}