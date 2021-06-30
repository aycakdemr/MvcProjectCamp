using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var value = hm.GetList();
            return View(value);
        }
        public ActionResult HeadingResult()
        {
            var value = hm.GetList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.dgr1 = valueCategory;
            List<SelectListItem> valueWriter = (from x in wm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName +" " +x.WriterSurname,
                                                      Value = x.WriterId.ToString()
                                                  }).ToList();
            ViewBag.dgr2 = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.dgr1 = valueCategory;
            var headingvalue = hm.GetById(id);
            return View(headingvalue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading h)
        {
            hm.HeadingUpdate(h);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var value = hm.GetById(id);
            if (value.HeadingStatus)
            {
                value.HeadingStatus = false;
            }
            else
            {
                value.HeadingStatus = true;
            }
           
            hm.HeadingDelete(value);
            return RedirectToAction("Index");
        }
    }
}