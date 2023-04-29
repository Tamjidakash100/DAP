using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GTERP.Controllers.HR.HrReport
{
    [OverridableAuthorize]
    public class DailyAttendanceReportController : Controller
    {
        private readonly GTRDBContext db;
        //public CommercialRepository repos;

        public DailyAttendanceReportController(GTRDBContext context)
        {
            db = context;
            //repos = repository;
        }

        // GET: DailyAttendanceReport
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

            List<HR_Emp_Increment> Increment = new List<HR_Emp_Increment>();
            Increment = db.HR_Emp_Increment.ToList();
            ViewBag.Increment = Increment;

            List<Cat_Shift> Shifts = new List<Cat_Shift>();
            Shifts = db.Cat_Shift.ToList();
            ViewBag.Shifts = Shifts;

            return View();
        }

        [HttpPost]

        public ActionResult Index(DailyAttendance aDailyAttendAnce)
        {
            string comid = HttpContext.Session.GetString("comid");

            if (HttpContext.Session.GetString("userid") == null)
            {
                return RedirectToRoute("GTR");
            }

            ReportItem item = new ReportItem();

            var callBackUrl = "";
            var ReportPath = "";
            var SqlCmd = "";
            var ConstrName = "";
            var ReportType = "";



            switch (aDailyAttendAnce.ButtonString)
            {

                case "attendance":
                    //query = "Exec rptAttend " + comid + ", '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "'," +
                    //        "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Attend', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    //path = "~/Report/Attendence/rptAttendPresent.rdlc";
                    //var ReportPath = "CommercialReport/rptMasterLCSalesContact.rdlc";
                    ReportPath = "/ReportViewer/HR/rptAttendPresent.rdlc";
                    SqlCmd = "Exec HR_RptAttend '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.FromDate + "'," +
                          "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Attendance', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "present":
                    //query = "Exec rptAttend " + comid + ", '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "'," +
                    //        "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Present', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    //path = "~/Report/Attendence/rptAttendPresent.rdlc";

                    ReportPath = "/ReportViewer/HR/rptAttendPresent.rdlc";
                    SqlCmd = "Exec HR_RptAttend '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.FromDate + "'," +
                          "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Present', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "absent":
                    //query = "Exec rptAttend " + comid + ", '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "'," +
                    //        "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Absent', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    //path = "~/Report/Attendence/rptAttendAbsent.rdlc";

                    ReportPath = "/ReportViewer/HR/rptAttendAbsent.rdlc";
                    SqlCmd = "Exec HR_RptAttend '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.FromDate + "'," +
                          "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Absent', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "late":

                    //query = "Exec rptAttend " + comid + ", '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "'," +
                    //        "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Late', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    //path = "~/Report/Attendence/rptAttendLate.rdlc";

                    ReportPath = "/ReportViewer/HR/rptAttendLate.rdlc";
                    SqlCmd = "Exec HR_RptAttend '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.FromDate + "'," +
                          "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Late', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "missing":

                    //query = "Exec rptAttend " + comid + ", '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "'," +
                    //        "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Missing Out', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    //path = "~/Report/Attendence/rptAttendMissing.rdlc";

                    ReportPath = "/ReportViewer/HR/rptAttendMissing.rdlc";
                    SqlCmd = "Exec HR_RptAttend '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.FromDate + "'," +
                          "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Missing Out', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "overtime":

                    //query = "Exec rptAttend " + comid + ", '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "'," +
                    //        "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Overtime', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    //path = "~/Report/Attendence/rptAttendOvertime.rdlc";

                    ReportPath = "/ReportViewer/HR/rptAttendOvertime.rdlc";
                    SqlCmd = "Exec HR_RptAttend '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.FromDate + "'," +
                          "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Overtime', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "summarydesig":

                    //query = "Exec rptAttendSum " + comid + ", '"+aDailyAttendAnce.FromDate+"', '"+aDailyAttendAnce.ToDate+"', "+aDailyAttendAnce.ShiftId+"," +
                    //        "'"+aDailyAttendAnce.EmployeeType+"', 'Desig','"+aDailyAttendAnce.LineId+"'";
                    //path = "~/Report/Attendence/rptAttendSumDesig.rdlc";


                    ReportPath = "/ReportViewer/HR/rptAttendSumDesig.rdlc";
                    SqlCmd = "Exec HR_RptAttendSum '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "', " + aDailyAttendAnce.ShiftId + "," +
                           "'" + aDailyAttendAnce.EmployeeType + "', 'Section','" + aDailyAttendAnce.LineId + "'";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "inout":

                    //query = "Exec rptAttend " + comid + ", '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "'," +
                    //        "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Attend', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    //path = "~/Report/Attendence/rptAttendInOut.rdlc";

                    ReportPath = "/ReportViewer/HR/rptAttendInOut.rdlc";
                    SqlCmd = "Exec HR_RptAttend '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.FromDate + "'," +
                          "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Attendance', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "movement":

                    //query = "Exec rptDailyMovement " + comid + ", '"+aDailyAttendAnce.FromDate+"', '"+aDailyAttendAnce.ToDate + "'," +
                    //        ""+aDailyAttendAnce.SectionId+", "+aDailyAttendAnce.EmployeeId;
                    //path = "~/Report/Attendence/rptDailyMovement.rdlc";

                    ReportPath = "/ReportViewer/HR/rptDailyMovement.rdlc";
                    SqlCmd = "Exec HR_RptDailyMovement '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "'," +
                           "" + aDailyAttendAnce.SectionId + ", " + aDailyAttendAnce.EmployeeId;
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "summarysec":

                    //query = "Exec rptAttendSumSec " + comid + ", '"+aDailyAttendAnce.FromDate+"','"+aDailyAttendAnce.ToDate+"', '"+aDailyAttendAnce.EmployeeType+"', "+aDailyAttendAnce.ShiftId;
                    //path = "~/Report/Attendence/rptAttendSumSec.rdlc";

                    ReportPath = "/ReportViewer/HR/rptAttendSum.rdlc";

                    SqlCmd = "Exec HR_RptAttendSum '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "', " + aDailyAttendAnce.ShiftId + "," +
                          "'" + aDailyAttendAnce.EmployeeType + "', 'Department','" + aDailyAttendAnce.LineId + "'";

                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "leave":

                    //query = "Exec rptAttend " + comid + ", '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.FromDate + "'," +
                    //        "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Leave', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    //path = "~/Report/Attendence/rptAttendLeave.rdlc";

                    ReportPath = "/ReportViewer/HR/rptAttendLeave.rdlc";
                    SqlCmd = "Exec HR_RptAttend '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.FromDate + "'," +
                          "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Leave', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "conabsent":

                    //query = "Exec rptAttend " + comid + ", '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "'," +
                    //        "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Absent Continuous', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    //path = "~/Report/Attendence/rptAttendAbsentCont.rdlc";

                    ReportPath = "/ReportViewer/HR/rptAbsentCont.rdlc";
                    SqlCmd = "Exec HR_RptAttend '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.FromDate + "'," +
                          "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Absent Continuous', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
                    break;
                case "manual":

                    //query = "Exec rptAttendFixedManual " + comid + ", '" + aDailyAttendAnce.FromDate + "', '" +
                    //        aDailyAttendAnce.ToDate + "','"+aDailyAttendAnce.SectionId+"','"+aDailyAttendAnce.EmployeeId+"','"+aDailyAttendAnce.LineId+"'";
                    //path = "~/Report/Attendence/rptAttendFixed.rdlc";

                    ReportPath = "/ReportViewer/HR/rptAttendFixed.rdlc";

                    SqlCmd = "Exec HR_RptAttendFixedManual '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" +
                            aDailyAttendAnce.ToDate + "','" + aDailyAttendAnce.SectionId + "','" + aDailyAttendAnce.EmployeeId + "','" + aDailyAttendAnce.LineId + "'";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "holiday":

                    //query = "Exec rptAttendHolidayAllw " + comid + ", '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "'," +
                    //       "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Holiday Allownce', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    //path = "~/Report/Attendence/rptAttendHolidayAllw.rdlc";

                    ReportPath = "/ReportViewer/HR/rptAttendLate.rdlc";
                    SqlCmd = "Exec HR_RptAttendHolidayAllw '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "'," +
                            "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Holiday Allownce', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "night":

                    //query = "Exec rptAttendNightAllw " + comid + ", '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "'," +
                    //       "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Night Allownce', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    //path = "~/Report/Attendence/rptAttendNightAllw.rdlc";

                    ReportPath = "/ReportViewer/HR/rptAttendLate.rdlc";
                    SqlCmd = "Exec HR_RptAttendHolidayAllw '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "'," +
                            "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Holiday Allownce', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "overnight":

                    //query = "Exec rptAttendOverNightAllw " + comid + ", '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "'," +
                    //       "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Over Night Allownce', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    //path = "~/Report/Attendence/rptAttendOverNightAllw.rdlc";

                    ReportPath = "/ReportViewer/HR/rptAttendLate.rdlc";
                    SqlCmd = "Exec HR_RptAttendOverNightAllw '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "'," +
                          "" + aDailyAttendAnce.ShiftId + ", 0, " + aDailyAttendAnce.SectionId + ", '0', '" + aDailyAttendAnce.LineId + "'," + aDailyAttendAnce.EmployeeId + ", '" + aDailyAttendAnce.EmployeeType + "', 'Over Night Allownce', '" + aDailyAttendAnce.Criteria.ToLower() + "','=ALL='";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    ////callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "summaryLine":

                    //query = "Exec rptAttendSum " + comid + ", '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "', " + aDailyAttendAnce.ShiftId + "," +
                    //       "'" + aDailyAttendAnce.EmployeeType + "', 'Line','"+aDailyAttendAnce.LineId+"'";
                    //path = "~/Report/Attendence/rptAttendSumLine.rdlc";

                    ReportPath = "/ReportViewer/HR/rptAttendLate.rdlc";
                    SqlCmd = "Exec HR_RptAttendSum '" + comid + "', '" + aDailyAttendAnce.FromDate + "', '" + aDailyAttendAnce.ToDate + "', " + aDailyAttendAnce.ShiftId + "," +
                        "'" + aDailyAttendAnce.EmployeeType + "', 'Line','" + aDailyAttendAnce.LineId + "'";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";
                    ////callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
            }
            HttpContext.Session.SetString("ReportPath", ReportPath.ToString());
            HttpContext.Session.SetString("reportquery", SqlCmd);
            string filename = aDailyAttendAnce.ButtonString.ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
            callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
            return Redirect(callBackUrl);


            //item.Databinds(path, query);

            //return RedirectToAction("Index", "ReportViewer");
        }
        public class DailyAttendance
        {
            public string Criteria { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
            public int SectionId { get; set; }
            public int EmployeeId { get; set; }
            public int ShiftId { get; set; }
            public string EmployeeType { get; set; }
            public int LineId { get; set; }
            public string ButtonString { get; set; }


        }

    }
}