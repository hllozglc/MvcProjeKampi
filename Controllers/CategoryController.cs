using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetCategoryList()
        {
            var categoryValues = cm.GetAllBl();
            return View(categoryValues);
        }
        [HttpGet]
        public IActionResult AddCategory() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            cm.CategoryAddBl(category);
            return RedirectToAction("GetCategoryList");
        }
    }
}
