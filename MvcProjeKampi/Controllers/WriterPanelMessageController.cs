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
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
           string p = (string)Session["Writermail"];
            var value = mm.GetListInbox(p);
            var count = mm.GetListStatusFalse().Count();
            ViewBag.d1 = count;
            return View(value);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["Writermail"];
            var value = mm.GetListSendInbox(p);
            return View(value);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        public ActionResult GetInBoxMessagetDetails(int id)
        {
            var value = mm.GetById(id);
            value.Status = true;
            mm.MessageUpdate(value);
            return View(value);
        }
        public ActionResult GetSendBoxMessagetDetails(int id)
        {
            var value = mm.GetById(id);
            return View(value);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string p = (string)Session["Writermail"];
            message.SenderMail = p;
            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            mm.MessageAdd(message);
            return View();
        }

    }
}