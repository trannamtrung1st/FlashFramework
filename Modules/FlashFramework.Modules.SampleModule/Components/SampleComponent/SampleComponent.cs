using FlashFramework.Shared.Models;
using FlashFramework.Shared.Modular;
using Microsoft.AspNetCore.Mvc;

namespace FlashFramework.Modules.SampleModule.Components.SampleComponent
{
    public class SampleComponent : ViewComponent, IComponent<IndexComponentModel>
    {
        public string Name => nameof(SampleComponent);

        public async Task<IViewComponentResult> InvokeAsync(IndexComponentModel model)
        {
            await Task.CompletedTask;

            return View(new SampleComponentModel
            {
                Message = $"Passed number: {model.Number}"
            });
        }
    }
}
