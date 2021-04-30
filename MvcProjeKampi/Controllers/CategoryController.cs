using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
       // CategoryManager cm = new CategoryManager();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAll()
        {
           // var value = cm.GetAll();
            return View();
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
           // cm.CategoryAdd(category);
            return RedirectToAction("GetAll");
        }
    }
}