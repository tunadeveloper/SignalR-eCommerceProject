using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.ViewComponents.Layout
{
    public class _LayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
