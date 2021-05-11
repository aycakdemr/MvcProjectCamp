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
    public class StatisticsController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        Statistics statistics = new Statistics();
        // GET: Statistics
        public ActionResult Index()
        {
            statistics.CategoriesCount = cm.GetList().Count;
            var categoryOfSoftwareHeader = cm.GetByName("Yazılım");
            statistics.SoftwareHeaderCount = hm.Get(categoryOfSoftwareHeader.CategoryId).Count;
            statistics.WritersCount = wm.GetList().Count;
            statistics.Difference = cm.StatusIsTrue().Count - cm.StatusIsFalse().Count;
            var list = hm.CategoryNameWithTheMostTitles();
            foreach (var item in list)
            {
                var category = cm.GetById(item.CategoryId);
                statistics.CategoryNameWithTheMostTitles = category.CategoryName;

            }

            return View(statistics);
            
        }
      
    }
}