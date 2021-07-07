using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(Image image)
        {
             if(Request.Files.Count>0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string expansion = Path.GetExtension(Request.Files[0].FileName);
                string path = "/AdminLTE-3.0.4/images/"+fileName+ expansion;
                Request.Files[0].SaveAs(Server.MapPath(path));
                image.ImagePath= "/AdminLTE-3.0.4/images/" + fileName + expansion;
                im.Add(image);
                return RedirectToAction("Index");
                
            }
            return View();
        }
    }
}