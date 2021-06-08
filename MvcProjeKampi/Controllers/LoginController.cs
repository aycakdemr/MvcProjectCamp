using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        public ActionResult Index(Admin admin)
        {
            if ((adm.Login(admin)))
            {

                FormsAuthentication.SetAuthCookie(admin.AdminUserName, false);
                Session["UserName"] = admin.AdminUserName.ToString();
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return View();
            }
            
        }
    }
}