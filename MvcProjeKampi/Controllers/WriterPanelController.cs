using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator wv = new WriterValidator();
        int writerid;
        [HttpGet]
        public ActionResult WriterProfile(int id)
        {
            string p = (string)Session["Writermail"];
            writerid = wm.GetByMail(p).WriterId;
            var value = wm.GetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            ValidationResult results = wv.Validate(writer);
            if (results.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("AllHeading","WriterPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult MyHeading(string p)
        {
            p = (string)Session["Writermail"];
             writerid = wm.GetByMail(p).WriterId;
            var value = hm.GetListByWriter(writerid);
            return View(value);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.dgr1 = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string a = (string)Session["WriterMail"];
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            writerid = wm.GetByMail(a).WriterId;
            heading.WriterId = writerid;
            heading.HeadingStatus = true;
            hm.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
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
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int sayfa = 1)
        {
            var he = hm.GetList().ToPagedList(sayfa,4);
            return View(he);
        }
    }
}