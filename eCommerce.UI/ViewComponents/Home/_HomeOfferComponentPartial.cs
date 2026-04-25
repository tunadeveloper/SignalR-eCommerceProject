using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.ViewComponents.Home
{
    public class _HomeOfferComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
