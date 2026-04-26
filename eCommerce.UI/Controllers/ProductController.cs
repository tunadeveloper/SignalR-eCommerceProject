using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
