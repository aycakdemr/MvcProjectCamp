using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
            var value = cm.GetListByHeadingId(id);
            return View(value);
        }
    }
}