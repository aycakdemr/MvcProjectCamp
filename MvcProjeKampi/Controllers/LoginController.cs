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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
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
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(WriterForLoginDto writer)
        {
            if ((wm.Login(writer)))
            {
                FormsAuthentication.SetAuthCookie(writer.Email, false);
                Session["Writermail"] = writer.Email.ToString();
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }
    }
}