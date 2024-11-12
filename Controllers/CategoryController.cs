using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
