using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterMenager writerMenager = new WriterMenager(new EfWriterDal());
        public IActionResult Index()
        {
            var headingValue = headingManager.GetList();
            return View(headingValue);
        }
        [HttpGet]
        public IActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            List<SelectListItem> valueWriter = (from x in writerMenager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName,
                                                      Value = x.WriterId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }
        [HttpPost]
        public IActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.AddHeading(heading);
            return RedirectToAction("Index");
        }
    }
}
