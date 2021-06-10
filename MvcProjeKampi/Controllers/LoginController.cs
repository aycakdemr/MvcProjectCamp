using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdminForLoginDto admin)
        {
            if ((adm.Login(admin)))
            {
                FormsAuthentication.SetAuthCookie(admin.Email, false);
                Session["Email"] = admin.Email.ToString();
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return View();
            }
            
        }
    }
}