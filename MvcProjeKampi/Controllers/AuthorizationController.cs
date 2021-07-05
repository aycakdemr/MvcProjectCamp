using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adm = new AdminManager(new EfAdminDal());
        AdminRoleManager admRole = new AdminRoleManager(new EfAdminRoleDal());
        public ActionResult Index()
        {
            var adminvalues = adm.GetList();
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult NewAdmin()
        {
            List<SelectListItem> valueRole = (from x in admRole.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.RoleName,
                                                  Value = x.Id.ToString()
                                              }).ToList();
            ViewBag.dgr1 = valueRole;
            return View();
        }
        [HttpPost]
        public ActionResult NewAdmin(AdminForRegisterDto c)
        {
            adm.AdminAdd(c,c.Password);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult ChangeRole(int id)
        {
            List<SelectListItem> valueRole = (from x in admRole.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.RoleName,
                                                  Value = x.Id.ToString()
                                              }).ToList();
            ViewBag.dgr1 = valueRole;
            var value = adm.GetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult ChangeRole(Admin admin)
        {
            
            adm.ChangeRole(admin.Id,admin.Role);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var value = adm.GetById(id);
            value.Status = false;
            adm.AdminUpdate(value);
            return RedirectToAction("Index");
        }
    }
}