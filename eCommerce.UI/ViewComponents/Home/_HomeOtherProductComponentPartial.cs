using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.ViewComponents.Home
{
    public class _HomeOtherProductComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
