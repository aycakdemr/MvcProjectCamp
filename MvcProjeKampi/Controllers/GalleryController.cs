using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        ImageManager im = new ImageManager(new EfImageDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var v = im.GetList();
            return View(v);
        }
        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase httpPostedFile)
        {
            if (httpPostedFile.ContentLength > 0)
            {
                string imagepath = Path.Combine(Server.MapPath("/AdminLTE-3.0.4/images/"), Path.GetFileName(httpPostedFile.FileName));
                httpPostedFile.SaveAs(imagepath);
            }
            return RedirectToAction("Index", "Gallery");
        }
    }
}