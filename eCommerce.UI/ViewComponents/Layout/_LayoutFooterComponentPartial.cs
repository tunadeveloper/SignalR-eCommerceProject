using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.ViewComponents.Layout
{
    public class _LayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
