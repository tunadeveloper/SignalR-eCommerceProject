using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.ViewComponents.Product
{
    public class _ProductListComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
