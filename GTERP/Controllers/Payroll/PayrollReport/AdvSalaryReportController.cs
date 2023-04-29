using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GTERP.Controllers.Payroll.PayrollReport
{
    [OverridableAuthorize]
    public class AdvSalaryReportController : Controller
    {
        private readonly GTRDBContext db;
        //public CommercialRepository repos;

        public AdvSalaryReportController(GTRDBContext context)
        {
            db = context;
            //repos = repository;
        }


        //Action to generate report 
        //[HttpPost]
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("userid") == null)
            {
                return RedirectToRoute("GTR");
            }

            List<Cat_Section> Cat_Sections = new List<Cat_Section>();
            Cat_Sections = db.Cat_Section.ToList();
            ViewBag.Sections = Cat_Sections;

            List<HR_Emp_Info> employee = new List<HR_Emp_Info>();
            employee = db.HR_Emp_Info.ToList();
            ViewBag.Employee = employee;

            List<Cat_Line> Lines = new List<Cat_Line>();
            Lines = db.Cat_Line.ToList();
            ViewBag.EmpLine = Lines;

            return View();
        }

        [HttpPost]

        public ActionResult Index(AdvSalaryReport aAdvSalaryReport)
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

            switch (aAdvSalaryReport.ButtonString)
            {
                case "AdvSalarySheet":

                    ReportPath = "/ReportViewer/Payroll/rptAdvSalarySheet.rdlc";
                    SqlCmd = "Exec Payroll_rptFestAdvanceSheet '" + comid + "', " +
                          "" + aAdvSalaryReport.SectionId + ", '" + aAdvSalaryReport.LineId + "'," + aAdvSalaryReport.EmployeeId + ", '" + aAdvSalaryReport.EmployeeType + "', 'AdvSalarySheet', '" + aAdvSalaryReport.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "AdvSalaryPayslip":
                    ReportPath = "/ReportViewer/Payroll/rptAdvSalarySheet.rdlc";
                    SqlCmd = "Exec Payroll_rptFestAdvanceSheet '" + comid + "', " +
                          "" + aAdvSalaryReport.SectionId + ", '" + aAdvSalaryReport.LineId + "'," + aAdvSalaryReport.EmployeeId + ", '" + aAdvSalaryReport.EmployeeType + "', 'AdvSalaryPayslip', '" + aAdvSalaryReport.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "AdvSalaryTopSheet":

                    ReportPath = "/ReportViewer/Payroll/rptAdvSalaryTopSheet.rdlc";
                    SqlCmd = "Exec Payroll_rptFestAdvanceSheet '" + comid + "', " +
                          "" + aAdvSalaryReport.SectionId + ", '" + aAdvSalaryReport.LineId + "'," + aAdvSalaryReport.EmployeeId + ", '" + aAdvSalaryReport.EmployeeType + "', 'AdvSalaryTopSheet', '" + aAdvSalaryReport.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "AdvSalaryBankSheet":

                    ReportPath = "/ReportViewer/Payroll/rptAdvSalaryBankSheet.rdlc";
                    SqlCmd = "Exec Payroll_rptFestAdvanceSheet '" + comid + "', " +
                          "" + aAdvSalaryReport.SectionId + ", '" + aAdvSalaryReport.LineId + "'," + aAdvSalaryReport.EmployeeId + ", '" + aAdvSalaryReport.EmployeeType + "', 'AdvSalaryBankSheet', '" + aAdvSalaryReport.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "Denomination":

                    ReportPath = "/ReportViewer/Payroll/rptDenomination.rdlc";
                    SqlCmd = "Exec Payroll_rptFestAdvanceSheet '" + comid + "', " +
                          "" + aAdvSalaryReport.SectionId + ", '" + aAdvSalaryReport.LineId + "'," + aAdvSalaryReport.EmployeeId + ", '" + aAdvSalaryReport.EmployeeType + "', 'Denomination', '" + aAdvSalaryReport.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
            }
            HttpContext.Session.SetString("ReportPath", ReportPath.ToString());
            HttpContext.Session.SetString("reportquery", SqlCmd);
            string filename = aAdvSalaryReport.ButtonString.ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
            callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
            return Redirect(callBackUrl);
        }

        public class AdvSalaryReport
        {
            public string Criteria { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
            public int SectionId { get; set; }
            public int EmployeeId { get; set; }
            public string EmployeeType { get; set; }
            public int LineId { get; set; }
            public string ButtonString { get; set; }
        }
    }
}