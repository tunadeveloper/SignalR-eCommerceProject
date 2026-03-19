using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.Areas.Admin.Controllers
{
    public class SignalRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
