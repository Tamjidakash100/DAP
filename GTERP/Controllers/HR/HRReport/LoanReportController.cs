using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GTERP.Controllers.HR.HrReport
{
    [OverridableAuthorize]
    public class LoanReportController : Controller
    {
        private readonly GTRDBContext db;
        //public CommercialRepository repos;

        public LoanReportController(GTRDBContext context)
        {
            db = context;
            //repos = repository;
        }


        //Action to generate report 
        //[HttpPost]
        public ActionResult Index()
        {
            string comid = HttpContext.Session.GetString("comid");

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


            List<HR_ReportType> reports = new List<HR_ReportType>();
            reports = db.HR_ReportType.Where(a => a.ComId == comid && a.ReportType == "Loan Report")
                .OrderBy(v => v.SLNo).ToList();
            ViewBag.ReportTypes = reports;

            //List<HR_ReportType> reports = db.HR_ReportType.Where(a => a.ComId == comid && a.ReportType=="Employee Report").OrderBy(a=>a.SLNo).ToList();
            //ViewBag.ReportTypes = reports;

            return View();
        }

        [HttpPost]

        public ActionResult Index(LoanReport aLoanReport)
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

            switch (aLoanReport.ReportName)
            {
                case "HB Loan Report":

                    ReportPath = "/ReportViewer/Payroll/rptITStatement.rdlc";
                    SqlCmd = "Exec rptITaxStatement '" + comid + "', '" + aLoanReport.FromDate + "', '" + aLoanReport.ToDate + "','" + aLoanReport.EmpTypeId + "', " +
                          "" + aLoanReport.SectionId + ", " + aLoanReport.EmpId + ",  'HB Loan Report'";
                    ConstrName = "ApplicationServices";
                    ReportType = aLoanReport.Format;
                    callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "MC Loan Report":

                    ReportPath = "/ReportViewer/Payroll/rptLoanMC.rdlc";
                    SqlCmd = "Exec rptLoanDeduction '" + comid + "', '" + aLoanReport.FromDate + "', '" + aLoanReport.ToDate + "','" + aLoanReport.EmpTypeId + "', " +
                          "" + aLoanReport.SectionId + ", " + aLoanReport.EmpId + ",  'MC Loan Report'";
                    ConstrName = "ApplicationServices";
                    ReportType = aLoanReport.Format;
                    callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;


                case "WF Loan Report":

                    ReportPath = "/ReportViewer/Payroll/rptLoanMC.rdlc"; ;
                    SqlCmd = "Exec rptLoanDeduction '" + comid + "', '" + aLoanReport.FromDate + "', '" + aLoanReport.ToDate + "','" + aLoanReport.EmpTypeId + "', " +
                          "" + aLoanReport.SectionId + ", " + aLoanReport.EmpId + ",  'WF Loan Report'";
                    ConstrName = "ApplicationServices";
                    ReportType = aLoanReport.Format;
                    callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "PF Loan Report":

                    ReportPath = "/ReportViewer/Payroll/rptLoanPF.rdlc"; ;
                    SqlCmd = "Exec rptLoanDeduction '" + comid + "', '" + aLoanReport.FromDate + "', '" + aLoanReport.ToDate + "','" + aLoanReport.EmpTypeId + "', " +
                          "" + aLoanReport.SectionId + ", " + aLoanReport.EmpId + ",  'PF Loan Report'";
                    ConstrName = "ApplicationServices";
                    ReportType = aLoanReport.Format;
                    callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "OTHER Loan Report":

                    ReportPath = "/ReportViewer/Payroll/rptLoanOther.rdlc"; ;
                    SqlCmd = "Exec rptLoanDeduction '" + comid + "', '" + aLoanReport.FromDate + "', '" + aLoanReport.ToDate + "','" + aLoanReport.EmpTypeId + "', " +
                          "" + aLoanReport.SectionId + ", " + aLoanReport.EmpId + ",  'OTHER Loan Report'";
                    ConstrName = "ApplicationServices";
                    ReportType = aLoanReport.Format;
                    callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;


                case "MotorCycle Loan Letter":

                    ReportPath = "/ReportViewer/Payroll/rptRecoveryMCLoan.rdlc"; ;
                    SqlCmd = "Exec rptLoanLetter '" + comid + "', '" + aLoanReport.FromDate + "', '" + aLoanReport.ToDate + "','" + aLoanReport.EmpTypeId + "', " +
                          "" + aLoanReport.SectionId + ", " + aLoanReport.EmpId + ",  'MotorCycle Loan Letter'";
                    ConstrName = "ApplicationServices";
                    ReportType = aLoanReport.Format;
                    callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "Welfare Loan Letter":

                    ReportPath = "/ReportViewer/Payroll/rptRecoveryWFLoan.rdlc"; ;
                    SqlCmd = "Exec rptLoanLetter '" + comid + "', '" + aLoanReport.FromDate + "', '" + aLoanReport.ToDate + "','" + aLoanReport.EmpTypeId + "', " +
                          "" + aLoanReport.SectionId + ", " + aLoanReport.EmpId + ",  'Welfare Loan Letter'";
                    ConstrName = "ApplicationServices";
                    ReportType = aLoanReport.Format;
                    callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "House Building Loan Letter":

                    ReportPath = "/ReportViewer/Payroll/rptRecoveryHBLoan.rdlc"; ;
                    SqlCmd = "Exec rptLoanLetter '" + comid + "', '" + aLoanReport.FromDate + "', '" + aLoanReport.ToDate + "','" + aLoanReport.EmpTypeId + "', " +
                          "" + aLoanReport.SectionId + ", " + aLoanReport.EmpId + ",  'House Building Loan Letter'";
                    ConstrName = "ApplicationServices";
                    ReportType = aLoanReport.Format;
                    callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "PF Loan Letter":

                    ReportPath = "/ReportViewer/Payroll/rptRecoveryPFLoan.rdlc"; ;
                    SqlCmd = "Exec rptLoanLetter '" + comid + "', '" + aLoanReport.FromDate + "', '" + aLoanReport.ToDate + "','" + aLoanReport.EmpTypeId + "', " +
                          "" + aLoanReport.SectionId + ", " + aLoanReport.EmpId + ",  'PF Loan Letter'";
                    ConstrName = "ApplicationServices";
                    ReportType = aLoanReport.Format;
                    callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "Other Loan Letter":

                    ReportPath = "/ReportViewer/Payroll/rptRecoveryOtherLoan.rdlc"; ;
                    SqlCmd = "Exec rptLoanLetter '" + comid + "', '" + aLoanReport.FromDate + "', '" + aLoanReport.ToDate + "','" + aLoanReport.EmpTypeId + "', " +
                          "" + aLoanReport.SectionId + ", " + aLoanReport.EmpId + ",  'Other Loan Letter'";
                    ConstrName = "ApplicationServices";
                    ReportType = aLoanReport.Format;
                    callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                    //case "Loan Details Report":

                    //    ReportPath = "/ReportViewer/Payroll/rptLoanDetails.rdlc";
                    //    SqlCmd = "Exec rptLoanHouseBuilding '" + comid + "', '" + aLoanReport.FromDate + "', '" + aLoanReport.ToDate + "','" + aLoanReport.EmpTypeId + "', " +
                    //          "" + aLoanReport.SectionId + ", " + aLoanReport.EmpId + ",  'Loan Details Report'";
                    //    ConstrName = "ApplicationServices";
                    //    ReportType = aLoanReport.Format;
                    //    callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    //    break;



            }
            return Redirect(callBackUrl);
        }

        public class LoanReport
        {
            public string Criteria { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
            public int SectionId { get; set; }
            public int EmpId { get; set; }
            public string EmpTypeId { get; set; }
            public int LId { get; set; }
            public string ReportName { get; set; }
            public string Format { get; set; }
        }
    }
}