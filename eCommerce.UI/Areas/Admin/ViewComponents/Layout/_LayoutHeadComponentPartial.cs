using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.Areas.Admin.ViewComponents.Layout
{
    public class _LayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
