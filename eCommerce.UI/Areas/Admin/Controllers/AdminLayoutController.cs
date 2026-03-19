using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLayoutController : Controller
    {
        public IActionResult _Layout()
        {
            return View();
        }
    }
}
