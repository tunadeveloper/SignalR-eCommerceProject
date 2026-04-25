using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.ViewComponents.Home
{
    public class _HomePopularProductComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
