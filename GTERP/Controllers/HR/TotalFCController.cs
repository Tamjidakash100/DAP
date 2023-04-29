using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]

    public class TotalFCController : Controller
    {
        GTRDBContext db;
        public TotalFCController(GTRDBContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            string comid = HttpContext.Session.GetString("comid");

            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@ComId", comid);
            var prossType = Helper.ExecProcMapTList<Pross>("GetProssType", parameter);
            ViewBag.ProssType = new SelectList(prossType, "ProssType", "ProssType");
            ViewBag.OTFCList = new List<OTFC>();
            return View();
        }


        [HttpPost]
        public IActionResult Create(List<HR_OT_FC> hR_OT_FCs)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var item in hR_OT_FCs)
                    {
                        var exist = db.HR_OT_FC.Where(o => o.EmpId == item.EmpId && o.ProssType == item.ProssType && o.ComId == item.ComId).FirstOrDefault();
                        if (exist == null)
                            db.Add(item);
                        else
                        {
                            exist.ttlFC = item.ttlFC;
                            //exist.ttlNight = item.ttlNight;
                            //exist.ttlOT = item.ttlOT;
                            //exist.ttlShiftNight = item.ttlShiftNight;
                            db.Entry(exist).State = EntityState.Modified;
                        }
                    }
                    db.SaveChanges();
                    TempData["Message"] = "Total FC Save/Update Successfully";
                    return Json(new { Success = 1, ex = TempData["Message"].ToString() });
                }
                TempData["Message"] = "Some thing wrong, Check data";
                return Json(new { Success = 3, ex = TempData["Message"].ToString() });
            }
            catch (Exception e)
            {
                TempData["Message"] = "Please contact software authority";
                return Json(new { Success = 3, ex = TempData["Message"].ToString() });
            }
        }


        public IActionResult Search(string prossType)
        {
            string comid = HttpContext.Session.GetString("comid");

            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@ComId", comid);
            parameter[1] = new SqlParameter("@ProssType", prossType);
            var OTFCList = Helper.ExecProcMapTList<OTFC>("[Payroll_prcGetFC]", parameter);

            //ViewBag.OTFCList = OTFCList;
            return Json(new { result = OTFCList, Success = "1" });
        }


        public class Pross
        {
            public string ProssType { get; set; }
            public DateTime dtInput { get; set; }
        }

        public class OTFC
        {
            public int EmpId { get; set; }
            public string EmpCode { get; set; }
            public string ProssType { get; set; }
            public string EmpName { get; set; }
            public string EmpType { get; set; }
            public string DeptName { get; set; }
            public string SectName { get; set; }
            public string DesigName { get; set; }
            public int BS { get; set; }
            public float TtlOT { get; set; }
            public float TtlNight { get; set; }
            public float TtlShiftNight { get; set; }
            public float TtlFC { get; set; }
            public string Remarks { get; set; }

        }
    }
}