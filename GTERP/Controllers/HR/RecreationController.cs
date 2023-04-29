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
    [OverridableAuthorize]

    public class RecreationController : Controller
    {
        public GTRDBContext db;
        public RecreationController(GTRDBContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            string comid = HttpContext.Session.GetString("comid");
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@ComId", comid);
            var reCreation = Helper.ExecProcMapTList<RecreationViewModel>("HR_prcGetReCreation", parameter);
            ViewBag.Recreation = reCreation;
            return View();
        }

        public class RecreationViewModel
        {
            public int EmpId { get; set; }
            public string EmpCode { get; set; }
            public string EmpName { get; set; }
            public string EmpType { get; set; }
            public string DeptName { get; set; }
            public string SectName { get; set; }
            public string DesigName { get; set; }
            public int BS { get; set; }
            public string DtPayment { get; set; }
            public string DtReference { get; set; }
            public bool IsReCreation { get; set; }
            public string ReferenceNo { get; set; }
        }

        public IActionResult Create(List<HR_Emp_Recreation> recreations)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");
                string userid = HttpContext.Session.GetString("userid");
                foreach (var item in recreations)
                {
                    var exist = db.HR_Emp_Recreation
                        .Where(r => r.DtPayment.Value.Year == item.DtPayment.Value.Year && r.EmpId == item.EmpId)
                        .ToList();

                    if (exist.Count > 0)
                        db.HR_Emp_Recreation.RemoveRange(exist);

                    db.HR_Emp_Recreation.Add(item);
                }
                db.SaveChanges();

                TempData["Message"] = "Re-Creation Save/Update Successfully";
                return Json(new { Success = 1, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Json(new { Success = 1, ex = TempData["Message"].ToString() });
            }

        }

    }
}
