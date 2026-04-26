using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
