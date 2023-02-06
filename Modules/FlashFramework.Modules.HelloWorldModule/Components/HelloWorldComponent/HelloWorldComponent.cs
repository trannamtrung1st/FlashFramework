using FlashFramework.Shared.Models;
using FlashFramework.Shared.Modular;
using Microsoft.AspNetCore.Mvc;

namespace FlashFramework.Modules.HelloWorldModule.Components.HelloWorldComponent
{
    public class HelloWorldComponent : ViewComponent, IComponent<IndexComponentModel>
    {
        public string Name => nameof(HelloWorldComponent);

        public async Task<IViewComponentResult> InvokeAsync(IndexComponentModel model)
        {
            await Task.CompletedTask;

            return View();
        }
    }
}
