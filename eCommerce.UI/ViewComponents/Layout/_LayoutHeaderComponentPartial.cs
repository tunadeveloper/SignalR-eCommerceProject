using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.ViewComponents.Layout
{
    public class _LayoutHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
