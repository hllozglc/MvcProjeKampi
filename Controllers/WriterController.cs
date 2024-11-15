using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        WriterMenager writerMenager = new WriterMenager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();

        public IActionResult Index()
        {
            var writerValues = writerMenager.GetList();
            return View(writerValues);
        }
        [HttpGet]
        public IActionResult AddWriter() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWriter(Writer writer)
        {
            ValidationResult validationResult = writerValidator.Validate(writer);
            if (validationResult.IsValid)
            {
                writerMenager.AddWriter(writer);
                return RedirectToAction("Index");
            }
            else 
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditWriter(int id) 
        {
            var writerValue = writerMenager.GetById(id);
            return View(writerValue);
        }
        [HttpPost]
        public IActionResult EditWriter(Writer writer)
        {

            ValidationResult validationResult = writerValidator.Validate(writer);
            if (validationResult.IsValid)
            {
                writerMenager.UpdateWriter(writer);
                return RedirectToAction("index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
    }
}
