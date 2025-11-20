using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_stock.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
