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
    [AllowAnonymous]
    public class ChartController : Controller
    {
        // GET: Chart
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager com = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexForHeading()
        {
            return View();
        }
        public ActionResult IndexForContent()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(cm.CategoryChartList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult HeadingChart()
        {
            return Json(hm.HeadingChart(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ContentChart()
        {
            return Json(com.ContentChart(), JsonRequestBehavior.AllowGet);
        }
        
    }
}