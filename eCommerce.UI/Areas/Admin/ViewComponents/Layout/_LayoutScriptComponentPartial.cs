using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.Areas.Admin.ViewComponents.Layout
{
    public class _LayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
