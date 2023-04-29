using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GTERP.Controllers.Payroll
{
    [OverridableAuthorize]
    public class HolidaySetupController : Controller
    {
        public HolidaySetupController(GTRDBContext _db)
        {
            db = _db;
        }

        private GTRDBContext db { get; set; }

        public IActionResult Index()
        {

            return View();

        }

        [HttpPost]
        public JsonResult Create(HR_ProssType_WHDay WHProssType)
        {
            if (ModelState.IsValid)
            {
                var check = db.HR_ProssType_WHDay.Where(s => s.WHId != WHProssType.WHId && s.dtPunchDate.Value.Date == WHProssType.dtPunchDate.Value.Date).FirstOrDefault();
                if (check != null)
                {
                    TempData["Message"] = "Data Already Exist";
                    return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                }

                string comid = HttpContext.Session.GetString("comid");
                WHProssType.ComId = comid;
                WHProssType.UserId = HttpContext.Session.GetString("userid");
                if (WHProssType.WHId > 0)
                {
                    WHProssType.DateUpdated = DateTime.Now;
                    WHProssType.UpdateByUserId = HttpContext.Session.GetString("userid");


                    db.Entry(WHProssType).State = EntityState.Modified;
                    TempData["Message"] = "Data Update Successfully";
                }
                else
                {
                    WHProssType.DateAdded = DateTime.Now;
                    db.Add(WHProssType);
                    TempData["Message"] = "Data Save Successfully";
                }
                db.SaveChanges();
                return Json(new { Success = 1, ex = TempData["Message"].ToString() });

            }
            else
            {
                TempData["Message"] = "Models state is not valid";
                return Json(new { Success = 3, ex = TempData["Message"].ToString() });
            }

        }

        [HttpPost]
        public JsonResult DeleteWHProssTypeAjax(int addId)
        {
            var WHProssType = db.HR_ProssType_WHDay.Find(addId);
            if (WHProssType != null)
            {
                db.HR_ProssType_WHDay.Remove(WHProssType);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, ex = TempData["Message"].ToString() });
            }

            TempData["Message"] = "No Data Found";
            return Json(new { Success = 2, ex = TempData["Message"].ToString() });
        }


        //load salary addition partial view
        [HttpPost]
        public ActionResult LoadWHProssTypePartial(DateTime date)
        {

            string comid = HttpContext.Session.GetString("comid");
            var WHProssTypes = db.HR_ProssType_WHDay
                .Where(s => s.dtPunchDate.Value.Date.Year == date.Year && s.ComId == comid)
                .Select(w => new HR_ProssType_WHDayViewModel
                {
                    WHId = w.WHId,
                    dtPunchDate = w.dtPunchDate.Value.ToString("dd-MMM-yyyy"),
                    DaySts = w.DaySts,
                    DayStsB = w.DayStsB,
                    Remarks = w.Remarks,
                    PcName = w.PcName,
                    ComId = w.ComId,
                    UserId = w.UserId,
                    DateAdded = w.DateAdded,
                    DateUpdated = w.DateUpdated,
                    UpdateByUserId = w.UpdateByUserId
                }).ToList();

            return Json(WHProssTypes);
        }

        public class HR_ProssType_WHDayViewModel
        {

            public int WHId { get; set; }
            public string dtPunchDate { get; set; }
            public string DaySts { get; set; }
            public string DayStsB { get; set; }
            public string Remarks { get; set; }
            public string PcName { get; set; }
            public string ComId { get; set; }
            public string UserId { get; set; }
            public DateTime? DateAdded { get; set; }
            public string UpdateByUserId { get; set; }
            public DateTime? DateUpdated { get; set; }
        }
    }
}