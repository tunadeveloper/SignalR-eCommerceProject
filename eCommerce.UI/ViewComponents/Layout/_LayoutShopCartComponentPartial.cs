using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.ViewComponents.Layout
{
    public class _LayoutShopCartComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
