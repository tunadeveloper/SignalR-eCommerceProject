using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.ViewComponents.Home
{
    public class _HomeServiceComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
