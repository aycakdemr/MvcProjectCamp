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
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var value = abm.GetListStatusTrue();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            abm.AboutAdd(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public ActionResult ChangeStatus(int id)
        {
            var value = abm.GetById(id);
            if (value.Status)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            abm.AboutUpdate(value);
            return RedirectToAction("Index");
        }

    }
}