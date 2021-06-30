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
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: WriterPanelContent
            
        public ActionResult MyContent(string p)
        {
            int id;
            p = (string)Session["Writermail"];
            var writerinfo = wm.GetByMail(p);
            id = writerinfo.WriterId;
            var value = cm.GetListByWriterId(id);
            return View(value);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            var  a = (string)Session["Writermail"];
            var writerinfo = wm.GetByMail(a);
            p.ContentDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            p.WriterId = writerinfo.WriterId;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}