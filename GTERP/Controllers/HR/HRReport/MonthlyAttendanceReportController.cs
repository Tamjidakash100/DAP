using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GTERP.Controllers.HR.HrReport
{
    [OverridableAuthorize]
    public class MonthlyAttendanceReportController : Controller
    {
        private readonly GTRDBContext db;
        //public CommercialRepository repos;

        public MonthlyAttendanceReportController(GTRDBContext context)
        {
            db = context;
            //repos = repository;
        }

        // GET: DailyAttendanceReport
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("userid") == null)
            {
                return RedirectToRoute("default");
            }
            string comid = HttpContext.Session.GetString("comid");


            ViewBag.Sections = db.Cat_Section.ToList();

            ViewBag.Employee = db.HR_Emp_Info.ToList();

            ViewBag.Location = db.Cat_Location.Where(a => a.ComId == comid).ToList();

            ViewBag.EmpType = db.Cat_Emp_Type.Where(a => a.ComId == comid).ToList();


            ViewBag.ReportTypes = db.HR_ReportType.Where(a => a.ComId == comid && a.ReportType == "Monthly Attendance").OrderBy(a => a.SLNo).ToList();

            return View();
        }

        [HttpPost]

        public ActionResult Index(MonthlyAttendance aMonthlyAttendance)
        {
            string comid = HttpContext.Session.GetString("comid");

            if (HttpContext.Session.GetString("userid") == null)
            {
                return RedirectToRoute("default");
            }



            var callBackUrl = "";
            var ReportPath = "";
            var SqlCmd = "";
            var ConstrName = "ApplicationServices";
            var ReportType = "PDF";



            switch (aMonthlyAttendance.ReportName)
            {

                case "Monthly Attendance Summary":

                    ReportPath = "/ReportViewer/HR/rptAttendMonthly.rdlc";
                    SqlCmd = "Exec HR_rptAttendMonthly '" + comid + "', '" + aMonthlyAttendance.FromDate + "', '" + aMonthlyAttendance.ToDate + "'," +
                          "" + aMonthlyAttendance.SectionId + ",  '" + aMonthlyAttendance.LId + "'," + aMonthlyAttendance.EmpId + ", '" + aMonthlyAttendance.EmpTypeId + "', 'Monthlyattendance', '" + aMonthlyAttendance.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = aMonthlyAttendance.Format;


                    break;
                case "Monthly Absent":
                    ReportPath = "/ReportViewer/HR/rptAttendMonthlyAbsent.rdlc";
                    SqlCmd = "Exec HR_rptMonthlyAttend  '" + comid + "', '" + aMonthlyAttendance.FromDate + "', '" + aMonthlyAttendance.ToDate + "'," +
                          "" + aMonthlyAttendance.SectionId + ",  '" + aMonthlyAttendance.LId + "'," + aMonthlyAttendance.EmpId + ", '" + aMonthlyAttendance.EmpTypeId + "', 'MonthlyAbsent', '" + aMonthlyAttendance.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = aMonthlyAttendance.Format;


                    break;
                case "Monthly Late":
                    ReportPath = "/ReportViewer/HR/rptAttendMonthlyLate.rdlc";
                    SqlCmd = "Exec HR_rptMonthlyAttend  '" + comid + "', '" + aMonthlyAttendance.FromDate + "', '" + aMonthlyAttendance.ToDate + "'," +
                          "" + aMonthlyAttendance.SectionId + ",  '" + aMonthlyAttendance.LId + "'," + aMonthlyAttendance.EmpId + ", '" + aMonthlyAttendance.EmpTypeId + "', 'MonthlyLate', '" + aMonthlyAttendance.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = aMonthlyAttendance.Format;



                    break;
                case "Monthly Job Card":


                    ReportPath = "/ReportViewer/HR/rptJobCardMonthlyDetails.rdlc";
                    SqlCmd = "Exec HR_rptMonthlyAttend  '" + comid + "', '" + aMonthlyAttendance.FromDate + "', '" + aMonthlyAttendance.ToDate + "'," +
                          "" + aMonthlyAttendance.SectionId + ",  '" + aMonthlyAttendance.LId + "'," + aMonthlyAttendance.EmpId + ", '" + aMonthlyAttendance.EmpTypeId + "', 'MonthlyJobCard', '" + aMonthlyAttendance.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = aMonthlyAttendance.Format;


                    break;
                case "Yearly Full Present":


                    ReportPath = "/ReportViewer/HR/rptYearlyPresent.rdlc";
                    SqlCmd = "Exec HR_RptYearlyFullPresent  '" + comid + "', '" + aMonthlyAttendance.FromDate + "', '" + aMonthlyAttendance.ToDate + "'," +
                          "" + aMonthlyAttendance.SectionId + ",  '" + aMonthlyAttendance.LId + "'," + aMonthlyAttendance.EmpId + ", '" + aMonthlyAttendance.EmpTypeId + "', 'YearlyFullPresent', '" + aMonthlyAttendance.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = aMonthlyAttendance.Format;


                    break;
                case "Yearly Maximum Present":


                    ReportPath = "/ReportViewer/HR/rptYearlyPresent.rdlc";
                    SqlCmd = "Exec HR_RptYearlyFullPresent  '" + comid + "', '" + aMonthlyAttendance.FromDate + "', '" + aMonthlyAttendance.ToDate + "'," +
                          "" + aMonthlyAttendance.SectionId + ",  '" + aMonthlyAttendance.LId + "'," + aMonthlyAttendance.EmpId + ", '" + aMonthlyAttendance.EmpTypeId + "', 'YearlyMaximumPresent', '" + aMonthlyAttendance.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = aMonthlyAttendance.Format;


                    break;
            }
            HttpContext.Session.SetString("ReportPath", ReportPath.ToString());
            HttpContext.Session.SetString("reportquery", SqlCmd);
            string filename = aMonthlyAttendance.ReportName.ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
            //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
            callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
            return Redirect(callBackUrl);


        }
        public class MonthlyAttendance
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