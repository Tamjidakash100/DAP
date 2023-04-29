using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTERP.Controllers.HR
{
    public class BusinessAllowanceController : Controller
    {
        public GTRDBContext db;
        public BusinessAllowanceController(GTRDBContext context)
        {
            db = context;
        }
        public IActionResult Index(DateTime? todate)
        {
            string comid = HttpContext.Session.GetString("comid");
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@ComId", comid);
            //parameter[1] = new SqlParameter("@todate", todate);
            var BusinessAllow = Helper.ExecProcMapTList<BusinessAllowViewModel>("HR_prcGetBusinessAllow", parameter);
            ViewBag.BusinessAllow = BusinessAllow;
            return View();
        }

        public class BusinessAllowViewModel
        {
            public int EmpId { get; set; }
            public string EmpCode { get; set; }
            public string EmpName { get; set; }
            public string EmpType { get; set; }
            public string DeptName { get; set; }
            public string SectName { get; set; }
            public string DesigName { get; set; }
            public decimal ttlBusinessDuty { get; set; }
            public decimal Rate { get; set; }
            public decimal Amount { get; set; }
            public string DtFrom { get; set; }
            public string DtTo { get; set; }
            public string Remarks { get; set; }
        }

        public IActionResult Create(List<HR_Emp_BusinessAllow> BusinessAllows)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");
                string userid = HttpContext.Session.GetString("userid");
                foreach (var item in BusinessAllows)
                {
                    var exist = db.HR_Emp_BusinessAllow
                        .Where(r => r.DtTo.Value.Month == item.DtTo.Value.Month && r.EmpId == item.EmpId)
                        .ToList();

                    if (exist.Count > 0)
                    {
                        db.HR_Emp_BusinessAllow.RemoveRange(exist);
                        db.SaveChanges();
                    }

                    db.HR_Emp_BusinessAllow.Add(item);
                    db.SaveChanges();
                }


                TempData["Message"] = "Business Allowance Save/Update Successfully";
                return Json(new { Success = 1, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Json(new { Success = 0, ex = TempData["Message"].ToString() });
            }

        }



    }
}
