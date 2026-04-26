using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.ViewComponents.Product
{
    public class _CategoryListComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
