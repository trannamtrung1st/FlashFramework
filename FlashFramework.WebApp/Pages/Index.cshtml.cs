using FlashFramework.Shared.Modular;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlashFramework.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IEnumerable<IModule> Modules { get; }

        public IndexModel(
            ILogger<IndexModel> logger,
            IEnumerable<IModule> modules)
        {
            _logger = logger;
            Modules = modules;
        }

        public void OnGet()
        {
        }
    }
}