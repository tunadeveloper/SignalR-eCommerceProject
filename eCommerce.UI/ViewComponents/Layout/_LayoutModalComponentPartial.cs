using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.ViewComponents.Layout
{
    public class _LayoutModalComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
