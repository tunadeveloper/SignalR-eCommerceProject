using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.ViewComponents.Home
{
    public class _HomeCategoryComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
