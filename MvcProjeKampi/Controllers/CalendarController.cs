using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Dto;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class CalendarController : Controller
    {
        // GET: Calendar
        HeadingManager cm = new HeadingManager(new EfHeadingDal());
		[HttpGet]
		public ActionResult Index()
		{
			return View(new ContentCalendarDto());
		}

		public JsonResult GetEvents(DateTime start, DateTime end)
		{
			var viewModel = new ContentCalendarDto();
			var events = new List<ContentCalendarDto>();
			start = DateTime.Today.AddDays(-14);
			end = DateTime.Today.AddDays(-14);

			foreach (var item in cm.GetList())
			{
				events.Add(new ContentCalendarDto()
				{
					title = item.HeadingName,
					start = item.HeadingDate,
					end = item.HeadingDate.AddDays(-14),
					allDay = false
				});

				start = start.AddDays(7);
				end = end.AddDays(7);
			}


			return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
		}
	}
}