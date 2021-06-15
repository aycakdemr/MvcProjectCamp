using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: Register
        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterRegister(WriterForRegisterDto writer)
        {
            wm.Register(writer, writer.Password);
            return View();
        }

    }
}