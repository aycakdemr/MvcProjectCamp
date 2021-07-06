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
    public class AbilitiesController : Controller
    {
        AbilityManager abm = new AbilityManager(new EfAbilityDal());
        // GET: Abilities
        public ActionResult Index()
        {
            var value = abm.GetListDto();
            ViewBag.d1 = value.FirstOrDefault().FirstName;
            ViewBag.d2 = value.FirstOrDefault().LastName;
            ViewBag.d3 = value.FirstOrDefault().Title;
            return View(value);
        }
        public ActionResult AllAbility()
        {
            var value = abm.GetList();
            return View(value);
        }
        [HttpGet]
        public ActionResult NewAbility()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAbility(Ability ability)
        {
            ability.UserId = 1;
            abm.Add(ability);
            return RedirectToAction("Index","Abilities");
        }
        public ActionResult DeleteAbility(int id)
        {
            var value = abm.GetById(id);
            
            abm.Delete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAbility(int id)
        {
           
            var value = abm.GetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditAbility(Ability h)
        {
            abm.Update(h);
            return RedirectToAction("Index");
        }
    }
}