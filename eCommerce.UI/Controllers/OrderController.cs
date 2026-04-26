using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Received()
        {
            return View();
        }

        public IActionResult Shipping()
        {
            return View();
        }
    }
}
