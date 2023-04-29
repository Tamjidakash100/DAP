using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTERP.Controllers.HR.HrReport
{
    [OverridableAuthorize]
    public class IncrementReportController : Controller
    {
        private readonly GTRDBContext db;
        //public CommercialRepository repos;

        public IncrementReportController(GTRDBContext context)
        {
            db = context;
            //repos = repository;
        }


        //Action to generate report 
        //[HttpPost]
        public ActionResult Index()
        {
            string comid = HttpContext.Session.GetString("comid");

            List<Cat_Department> Cat_Departments = new List<Cat_Department>();
            Cat_Departments = db.Cat_Department.Where(a => a.ComId == comid).ToList();
            ViewBag.Departments = Cat_Departments;

            List<Cat_Section> Cat_Sections = new List<Cat_Section>();
            Cat_Sections = db.Cat_Section.Where(a => a.ComId == comid).ToList();
            ViewBag.Sections = Cat_Sections;

            List<HR_Emp_Info> employee = new List<HR_Emp_Info>();
            employee = db.HR_Emp_Info.Where(a => a.ComId == comid).ToList();
            ViewBag.Employee = employee;

            List<Cat_Location> Locations = new List<Cat_Location>();
            Locations = db.Cat_Location.Where(a => a.ComId == comid).ToList();
            ViewBag.Location = Locations;

            List<Cat_Emp_Type> EmpTypes = new List<Cat_Emp_Type>();
            EmpTypes = db.Cat_Emp_Type.Where(a => a.ComId == comid).ToList();
            ViewBag.EmpType = EmpTypes;

            List<Cat_Shift> Shifts = new List<Cat_Shift>();
            Shifts = db.Cat_Shift.Where(a => a.ComId == comid).ToList();
            ViewBag.Shifts = Shifts;

            List<HR_ReportType> reports = db.HR_ReportType.Where(a => a.ComId == comid && a.ReportType == "Increment Report").OrderBy(a => a.SLNo).ToList();
            ViewBag.ReportTypes = reports;

            return View();
        }

        [HttpPost]

        public ActionResult Index(IncrementReport aIncrementReport)
        {
            string comid = HttpContext.Session.GetString("comid");

            if (HttpContext.Session.GetString("userid") == null)
            {
                return RedirectToRoute("GTR");
            }

            ReportItem item = new ReportItem();
            string query = "";
            string path = "";
            var callBackUrl = "";
            var ReportPath = "";
            var SqlCmd = "";
            var ConstrName = "";
            var ReportType = "";

            switch (aIncrementReport.ReportName)
            {
                case "Increment":

                    ReportPath = "/ReportViewer/HR/rptIncrList.rdlc";
                    SqlCmd = "Exec HR_rptIncrement '" + comid + "', '" + aIncrementReport.FromDate + "', '" + aIncrementReport.ToDate + "'," +
                          "" + aIncrementReport.DeptId + ", " + aIncrementReport.SectId + ", " + aIncrementReport.LId + "," + aIncrementReport.EmpId + ", " + aIncrementReport.EmpTypeId + ", '" + aIncrementReport.Criteria.ToLower() + "','Increment'";

                    ConstrName = "ApplicationServices";
                    ReportType = aIncrementReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
                    break;

                case "Promotion":

                    ReportPath = "/ReportViewer/HR/rptPromotionList.rdlc";
                    SqlCmd = "Exec HR_rptIncrement '" + comid + "', '" + aIncrementReport.FromDate + "', '" + aIncrementReport.ToDate + "'," +
                            "" + aIncrementReport.DeptId + ", " + aIncrementReport.SectId + ", " + aIncrementReport.LId + "," + aIncrementReport.EmpId + ", " + aIncrementReport.EmpTypeId + ", '" + aIncrementReport.Criteria.ToLower() + "','Promotion'";
                    ConstrName = "ApplicationServices";
                    ReportType = aIncrementReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;


                case "Increment with Promotion":

                    ReportPath = "/ReportViewer/HR/rptIncrPromoList.rdlc";
                    SqlCmd = "Exec HR_rptIncrement '" + comid + "', '" + aIncrementReport.FromDate + "', '" + aIncrementReport.ToDate + "'," +
                           "" + aIncrementReport.DeptId + ", " + aIncrementReport.SectId + ", " + aIncrementReport.LId + "," + aIncrementReport.EmpId + ", " + aIncrementReport.EmpTypeId + ", '" + aIncrementReport.Criteria.ToLower() + "','Increment with Promotion'";
                    ConstrName = "ApplicationServices";
                    ReportType = aIncrementReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
                    break;



                case "Increment Entitle":
                    ReportPath = "/ReportViewer/HR/rptIncrEntitle.rdlc";
                    SqlCmd = "Exec HR_rptIncrement '" + comid + "', '" + aIncrementReport.FromDate + "', '" + aIncrementReport.ToDate + "'," +
                            "" + aIncrementReport.DeptId + ", " + aIncrementReport.SectId + ", " + aIncrementReport.LId + "," + aIncrementReport.EmpId + ", " + aIncrementReport.EmpTypeId + ", '" + aIncrementReport.Criteria.ToLower() + "','Increment Entitle'";
                    ConstrName = "ApplicationServices";
                    ReportType = aIncrementReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
                    break;

                case "Promotion Entitle":

                    ReportPath = "/ReportViewer/HR/rptIPromotionEntitle.rdlc";
                    SqlCmd = "Exec HR_rptIncrement '" + comid + "', '" + aIncrementReport.FromDate + "', '" + aIncrementReport.ToDate + "'," +
                           "" + aIncrementReport.DeptId + ", " + aIncrementReport.SectId + ", " + aIncrementReport.LId + "," + aIncrementReport.EmpId + ", " + aIncrementReport.EmpTypeId + ", '" + aIncrementReport.Criteria.ToLower() + "','Promotion Entitle'";
                    ConstrName = "ApplicationServices";
                    ReportType = aIncrementReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
                    break;
            }

            HttpContext.Session.SetString("ReportPath", ReportPath.ToString());
            HttpContext.Session.SetString("reportquery", SqlCmd);
            string filename = aIncrementReport.ReportName + DateTime.Now.Date.ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
            callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
            return Redirect(callBackUrl);
        }

        public class IncrementReport
        {
            public string Criteria { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
            public int DeptId { get; set; }
            public int SectId { get; set; }
            public int EmpId { get; set; }
            public string EmpTypeId { get; set; }
            public int LId { get; set; }
            public string ReportName { get; set; }
            public string Format { get; set; }
        }
    }
}