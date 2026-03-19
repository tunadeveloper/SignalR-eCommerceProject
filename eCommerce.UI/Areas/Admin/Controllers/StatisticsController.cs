using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
