using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlacementData.Controllers
{
    public class HomeController : Controller
    {
        DbModel db = new DbModel();
       
        public ActionResult Index()
        {
            List<Year> YearList = db.Years.ToList();
            ViewBag.YearList = new SelectList(YearList, "YearId", "Year1");
            List<Branch> BranchList = db.Branches.ToList();

            ViewBag.BranchList = new SelectList(BranchList, "BranchId", "BranchName");
            return View();
        }

        public JsonResult GetSectionList(int BranchId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Section> SectionList = db.Sections.Where(x => x.BranchId == BranchId).ToList();
            ViewBag.SectionList = db.Sections.Where(x => x.BranchId == BranchId).ToList();
            return Json(SectionList, JsonRequestBehavior.AllowGet);

        }

        public ActionResult getData()
        {
            List<Year> YearList = db.Years.ToList();
            ViewBag.YearList = new SelectList(YearList, "YearId", "Year1");
            List<Branch> BranchList = db.Branches.ToList();
            ViewBag.BranchList = new SelectList(BranchList, "BranchId", "BranchName");
            return View();
        }

        [HttpPost]
        public string getData(FormCollection collection)
        {

            string[] YearList = new string[] { "2018", "2017", "2016" };
            string[] BranchList = new string[] { "ECE", "CSE", "IT" };
            string[] SectionList = new string[] { "A", "B", "C", "A", "B", "C", "A", "B" };




            var year = YearList[int.Parse(collection["YearId"]) - 1];
            var branch = BranchList[int.Parse(collection["BranchId"]) - 1];
            var section = SectionList[int.Parse(collection["SectionId"]) - 1];

            return year+branch+section;
        }

    }
}