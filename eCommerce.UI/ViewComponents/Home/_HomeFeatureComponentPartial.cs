using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.ViewComponents.Home
{
    public class _HomeFeatureComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
