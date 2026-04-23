using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
