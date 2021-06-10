using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AbilitiesController : Controller
    {
        AbilityManager abm = new AbilityManager(new EfAbilityDal());
        // GET: Abilities
        public ActionResult Index()
        {
            var value = abm.GetList();
            ViewBag.d1 = value.FirstOrDefault().FirstName;
            ViewBag.d2 = value.FirstOrDefault().LastName;
            ViewBag.d3 = value.FirstOrDefault().Title;
            return View(value);
        }
    }
}