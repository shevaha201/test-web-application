using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers {
	public class HomeController : Controller {

		public static ICollection<Record> Records = new List<Record>();

		// GET: Home
		public ActionResult Index() {
			return View(Records);
		}

		[HttpGet]
		public ActionResult AddRecord() {
			var viewModel = new Record();
			return PartialView("_AddRecord", viewModel);
		}

		[HttpPost]
		public ActionResult AddRecord(Record record) {
			record.Id = (new Random()).Next(0, 100000);
			record.CreatedDate = DateTime.Now;
			Records.Add(record);
			return PartialView("_RecordItem", record);
		}
	}
}