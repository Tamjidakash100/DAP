using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]

    public class IDCardController : Controller
    {
        public readonly GTRDBContext db;
        //public CommercialRepository repos;
        public IDCardController(GTRDBContext _db)
        {
            db = _db;
            //repos = repository;
        }

        public IActionResult Index()
        {
            var comid = HttpContext.Session.GetString("comid");
            ViewBag.EmpList = db.HR_Emp_Info.Where(e => e.ComId == comid && e.EmpId == 0).ToList();

            List<Cat_Department> Cat_Departments = new List<Cat_Department>();
            Cat_Departments = db.Cat_Department.ToList();
            ViewBag.Departments = Cat_Departments;

            List<Cat_Section> Cat_Sections = new List<Cat_Section>();
            Cat_Sections = db.Cat_Section.ToList();
            ViewBag.Sections = Cat_Sections;

            List<Cat_Designation> Cat_Designations = new List<Cat_Designation>();
            Cat_Designations = db.Cat_Designation.ToList();
            ViewBag.Designations = Cat_Designations;

            return View();
        }

        [HttpPost]
        public IActionResult Index(IdCard idCard)
        {
            string comid = HttpContext.Session.GetString("comid");

            db.HR_Emp_TempIdCard.RemoveRange(db.HR_Emp_TempIdCard);
            //insert empid in temp table
            for (int i = 0; i < idCard.Employess.Count; i++)
            {
                HR_Emp_TempIdCard t = new HR_Emp_TempIdCard();
                t.ComId = comid;
                t.EmpId = idCard.Employess[i];
                db.HR_Emp_TempIdCard.Add(t);
            }
            db.SaveChanges();

            return Json("");
        }

        [HttpGet]
        public IActionResult ViewReport(DateTime fromDate, DateTime toDate, IdCard IdCard)
        {
            string comid = HttpContext.Session.GetString("comid");
            ReportItem item = new ReportItem();
            var callBackUrl = "";
            var ReportPath = "";
            var SqlCmd = "";
            var ConstrName = "";
            var ReportType = "PDF";

            ReportPath = "/ReportViewer/HR/rptIDCardPrintBanglaFront.rdlc";
            SqlCmd = "Exec HR_rptIdCardPrint '" + comid + "', '" + fromDate + "', '" + toDate + "'";// + jobCard.SectId + ", " + jobCard.EmpId + "";
            ConstrName = "ApplicationServices";
            // ReportType = ReportType; 
            ReportType = IdCard.ViewReportAs;


            return Redirect(callBackUrl);
        }


        [HttpPost]
        public IActionResult EmployeeDataByDate(string FromDate, string ToDate)
        {
            var comid = HttpContext.Session.GetString("comid");

            var query = $"EXEC HR_PrcGetEmployeeInfoForIdCard '{comid}','{FromDate}','{ToDate}'";

            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@ComId", comid);
            parameters[1] = new SqlParameter("@dtFrom", FromDate);
            parameters[2] = new SqlParameter("@dtTo", ToDate);

            List<IdcardGreadData> IdcardGreadData = Helper.ExecProcMapTList<IdcardGreadData>("HR_PrcGetEmployeeInfoForIdCard", parameters);
            return Json(IdcardGreadData);
        }

        public class IdcardGreadData
        {
            public int EmpId { get; set; }
            public string EmpCode { get; set; }
            public string EmpName { get; set; }
            public string SectName { get; set; }
            public string DeptName { get; set; }
            public string DesigName { get; set; }
            public DateTime DtJoin { get; set; }
            public string ComId { get; set; }
        }
    }

    public class IdCard
    {
        [Display(Name = "From Date: ")]
        public string FromDate { get; set; }

        [Display(Name = "To Date: ")]
        public string ToDate { get; set; }

        [Display(Name = "View As: ")]
        public string ViewReportAs { get; set; }

        public List<int> Employess { get; set; }
        //public string EmployeeIdString { get; set; }

        //public string EmpCode { get; set; }
        //public string EmpName { get; set; }
    }
}