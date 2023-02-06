using Microsoft.AspNetCore.Mvc;

namespace FlashFramework.Shared.Modular
{
    public interface IComponent<TModel>
    {
        string Name { get; }
        Task<IViewComponentResult> InvokeAsync(TModel model);
    }
}
