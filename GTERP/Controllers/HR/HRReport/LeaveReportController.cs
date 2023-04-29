using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GTERP.Controllers.HR.HrReport
{
    [OverridableAuthorize]
    public class LeaveReportController : Controller
    {
        private readonly GTRDBContext db;
        //public CommercialRepository repos;

        public LeaveReportController(GTRDBContext context)
        {
            db = context;
            //repos = repository;
        }


        //Action to generate report 
        //[HttpPost]
        public ActionResult Index()
        {
            string comid = HttpContext.Session.GetString("comid");
            string userid = HttpContext.Session.GetString("userid");

            List<Cat_Section> Cat_Sections = new List<Cat_Section>();
            Cat_Sections = db.Cat_Section.Where(a => a.ComId == comid).ToList();
            ViewBag.Sections = Cat_Sections;

            List<HR_Emp_Info> employee = new List<HR_Emp_Info>();
            employee = db.HR_Emp_Info.Where(a => a.ComId == comid).ToList();
            ViewBag.Employee = employee;

            List<Cat_Leave_Type> LeaveTypes = new List<Cat_Leave_Type>();
            LeaveTypes = db.Cat_Leave_Type.Where(a => a.ComId == comid).ToList();
            ViewBag.LeaveType = LeaveTypes;

            List<Cat_Emp_Type> EmpTypes = new List<Cat_Emp_Type>();
            EmpTypes = db.Cat_Emp_Type.Where(a => a.ComId == comid).ToList();
            ViewBag.EmpType = EmpTypes;

            //List<HR_ReportType> reports = db.HR_ReportType.Where(a => a.ComId == comid && a.ReportType=="Leave Report").OrderBy(a=>a.SLNo).ToList();
            //ViewBag.ReportTypes = reports;

            //List<string> Reporttype = PayrollRepository.ReportName();
            var permission = db.ReportPermissions.Where(r => r.UserId == userid && r.ComId == comid).ToList();
            var reports = new List<HR_ReportType>();
            if (permission.Count > 0)
            {
                foreach (var item in permission)
                {
                    var report = db.HR_ReportType.Where(r => r.ReportType == "Leave Report" && r.ReportId == item.ReportId).FirstOrDefault();
                    if (report != null)
                    {
                        reports.Add(report);
                    }
                }
                ViewBag.ReportList = reports;
            }
            else
            {
                ViewBag.ReportList = db.HR_ReportType.Where(x => x.ReportType == "Leave Report").OrderBy(x => x.SLNo).ToList();
            }

            return View();
        }

        [HttpPost]

        public ActionResult Index(LeaveReport aLeaveReport)
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

            switch (aLeaveReport.ReportName)
            {
                case "General":
                    ReportPath = "/ReportViewer/HR/rptLeaveList.rdlc";
                    SqlCmd = "Exec HR_rptLeave '" + comid + "', '" + aLeaveReport.FromDate + "', '" + aLeaveReport.ToDate + "'," +
                          "" + aLeaveReport.SectId + ", '" + aLeaveReport.LTypeId + "'," + aLeaveReport.EmpId + ", '" + aLeaveReport.EmpTypeId + "', '" + aLeaveReport.ReportName + "'";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";


                    break;

                case "ML":
                    ReportPath = "/ReportViewer/HR/rptLeaveList.rdlc";
                    SqlCmd = "Exec HR_rptLeave '" + comid + "', '" + aLeaveReport.FromDate + "', '" + aLeaveReport.ToDate + "'," +
                          "" + aLeaveReport.SectId + ", '" + aLeaveReport.LTypeId + "'," + aLeaveReport.EmpId + ", '" + aLeaveReport.EmpTypeId + "', '" + aLeaveReport.ReportName + "'";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";


                    break;
                case "First ML":
                    ReportPath = "/ReportViewer/HR/rptLeaveList.rdlc";
                    SqlCmd = "Exec HR_rptLeave '" + comid + "', '" + aLeaveReport.FromDate + "', '" + aLeaveReport.ToDate + "'," +
                          "" + aLeaveReport.SectId + ", '" + aLeaveReport.LTypeId + "'," + aLeaveReport.EmpId + ", '" + aLeaveReport.EmpTypeId + "',  '" + aLeaveReport.ReportName + "'";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";


                    break;
                case "Last ML":
                    ReportPath = "/ReportViewer/HR/rptLeaveList.rdlc";
                    SqlCmd = "Exec HR_rptLeave '" + comid + "', '" + aLeaveReport.FromDate + "', '" + aLeaveReport.ToDate + "'," +
                          "" + aLeaveReport.SectId + ", '" + aLeaveReport.LTypeId + "'," + aLeaveReport.EmpId + ", '" + aLeaveReport.EmpTypeId + "',  '" + aLeaveReport.ReportName + "'";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";


                    break;
                case "Yearly Leave Details":
                    ReportPath = "/ReportViewer/HR/rptLeaveDetails.rdlc";
                    SqlCmd = "Exec HR_rptLeaveBalance '" + comid + "', '" + aLeaveReport.FromDate + "', '" + aLeaveReport.ToDate + "'," +
                          "" + aLeaveReport.SectId + ", '" + aLeaveReport.LTypeId + "'," + aLeaveReport.EmpId + ", '" + aLeaveReport.EmpTypeId + "',  '" + aLeaveReport.ReportName + "'";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";


                    break;

                case "Yearly Leave Summary":
                    ReportPath = "/ReportViewer/HR/rptLeaveSum.rdlc";
                    SqlCmd = "Exec HR_rptLeaveBalance '" + comid + "', '" + aLeaveReport.FromDate + "', '" + aLeaveReport.ToDate + "'," +
                          "" + aLeaveReport.SectId + ", '" + aLeaveReport.LTypeId + "'," + aLeaveReport.EmpId + ", '" + aLeaveReport.EmpTypeId + "',  '" + aLeaveReport.ReportName + "'";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";


                    break;

                case "Leave Form":
                    ReportPath = "/ReportViewer/HR/rptLeaveForm.rdlc";
                    SqlCmd = "Exec HR_rptLeaveForm '" + comid + "', '" + aLeaveReport.FromDate + "', '" + aLeaveReport.ToDate + "'," +
                          "" + aLeaveReport.SectId + ", '" + aLeaveReport.LTypeId + "'," + aLeaveReport.EmpId + ", '" + aLeaveReport.EmpTypeId + "',  '" + aLeaveReport.ReportName + "'";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";


                    break;

                case "EL Details":
                    ReportPath = "/ReportViewer/HR/rptELDetails.rdlc";
                    SqlCmd = "Exec HR_rptLeave '" + comid + "', '" + aLeaveReport.FromDate + "', '" + aLeaveReport.ToDate + "'," +
                             "" + aLeaveReport.SectId + ", '" + aLeaveReport.LTypeId + "'," + aLeaveReport.EmpId + ", '" + aLeaveReport.EmpTypeId + "', '" + aLeaveReport.ReportName + "'";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";


                    break;

                case "Leave Encashment":
                    ReportPath = "/ReportViewer/HR/rptLeaveEncashmentOrder.rdlc";
                    SqlCmd = "Exec HR_rptLeave_Encashment '" + comid + "', '" + aLeaveReport.FromDate + "', '" + aLeaveReport.ToDate + "'," +
                             "" + aLeaveReport.SectId + ", '" + aLeaveReport.LTypeId + "'," + aLeaveReport.EmpId + ", '" + aLeaveReport.EmpTypeId + "', '" + aLeaveReport.ReportName + "'";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";


                    break;


                case "SL Details":
                    SqlCmd = "Exec HR_rptLeave '" + comid + "', '" + aLeaveReport.FromDate + "', '" + aLeaveReport.ToDate + "'," +
                             "" + aLeaveReport.SectId + ", '" + aLeaveReport.LTypeId + "'," + aLeaveReport.EmpId + ", '" + aLeaveReport.EmpTypeId + "', '" + aLeaveReport.ReportName + "'";
                    ConstrName = "ApplicationServices";
                    ReportType = "PDF";


                    break;
            }
            HttpContext.Session.SetString("ReportPath", ReportPath.ToString());
            HttpContext.Session.SetString("reportquery", SqlCmd);
            string filename = aLeaveReport.ReportName.ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
            callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
            return Redirect(callBackUrl);
        }

        public class LeaveReport
        {
            public string Criteria { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
            public int SectId { get; set; }
            public int EmpId { get; set; }
            public string EmpTypeId { get; set; }
            public int LTypeId { get; set; }
            public string ReportName { get; set; }
            public string Format { get; set; }
        }
    }
}