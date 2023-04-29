using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GTERP.Controllers.HR.HrReport
{
    [OverridableAuthorize]
    public class EmployeeReportController : Controller
    {
        private readonly GTRDBContext db;
        //public CommercialRepository repos;

        public EmployeeReportController(GTRDBContext context)
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

            List<Cat_Department> Cat_Departments = new List<Cat_Department>();
            Cat_Departments = db.Cat_Department.Where(a => a.ComId == comid).ToList();
            ViewBag.Departments = Cat_Departments;

            List<Cat_Section> Cat_Sections = new List<Cat_Section>();
            Cat_Sections = db.Cat_Section.Where(a => a.ComId == comid).ToList();
            ViewBag.Sections = Cat_Sections;

            List<HR_Emp_Info> employee = new List<HR_Emp_Info>();
            employee = db.HR_Emp_Info.Include(d => d.Cat_Designation).Where(a => a.ComId == comid).ToList();
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

            var permission = db.ReportPermissions.Where(r => r.UserId == userid && r.ComId == comid).ToList();
            var reports = new List<HR_ReportType>();
            if (permission.Count > 0)
            {
                foreach (var item in permission)
                {
                    var report = db.HR_ReportType.Where(r => r.ReportType == "Employee Report" && r.ReportId == item.ReportId).FirstOrDefault();
                    if (report != null)
                    {
                        reports.Add(report);
                    }

                }
                ViewBag.ReportName = reports; // db.HR_ReportType.Where(r=>r.ReportType == "Sales Report" && r.IsActive == true).OrderBy(x=>x.SLNo).ToList();
            }
            else
            {
                List<HR_ReportType> PFreport = db.HR_ReportType.Where(a => a.ComId == comid && a.ReportType == "Employee Report").OrderBy(a => a.SLNo).ToList();
                ViewBag.ReportName = PFreport;
            }

            return View();
        }

        [HttpPost]

        public ActionResult Index(EmployeeReport aEmployeeReport)
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

            switch (aEmployeeReport.ReportName)
            {
                case "Employee List":

                    ReportPath = "/ReportViewer/HR/rptEmpList.rdlc";
                    SqlCmd = "Exec HR_RptEmployee '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ", '" + aEmployeeReport.Criteria.ToLower() + "','AllEmployee'";

                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
                    break;

                case "Active Employee List":
                    ReportPath = "/ReportViewer/HR/rptEmpList.rdlc";
                    SqlCmd = "Exec HR_RptEmployee '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ", '" + aEmployeeReport.Criteria.ToLower() + "','Active'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "Inactive Employee List":

                    ReportPath = "/ReportViewer/HR/rptEmpListReleased.rdlc";
                    SqlCmd = "Exec HR_RptEmployee '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ",  '" + aEmployeeReport.Criteria.ToLower() + "','InActive'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "New Joining Employee List":

                    ReportPath = "/ReportViewer/HR/rptEmpListJoin.rdlc";
                    SqlCmd = "Exec HR_RptEmployee '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ",  '" + aEmployeeReport.Criteria.ToLower() + "','NewJoining'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "Released Employee List":

                    ReportPath = "/ReportViewer/HR/rptEmpListReleased.rdlc";
                    SqlCmd = "Exec HR_RptEmployee '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ",  '" + aEmployeeReport.Criteria.ToLower() + "','Released'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "Retirement List":

                    ReportPath = "/ReportViewer/HR/rptEmpListRetirement.rdlc";
                    SqlCmd = "Exec HR_RptEmployee '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ",  '" + aEmployeeReport.Criteria.ToLower() + "','Retirement'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "PRL List":

                    ReportPath = "/ReportViewer/HR/rptEmpListPRL.rdlc";
                    SqlCmd = "Exec HR_RptEmployee '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ",  '" + aEmployeeReport.Criteria.ToLower() + "','PRL'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "PFEntitle":
                    ReportPath = "/ReportViewer/HR/rptEmpListPF.rdlc";
                    SqlCmd = "Exec HR_RptEmployee '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ",  '" + aEmployeeReport.Criteria.ToLower() + "','PFEntitle'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                //case "ProEntitle":
                //    ReportPath = "/ReportViewer/HR/rptIPromotionEntitle.rdlc";
                //    SqlCmd = "Exec HR_RptEmployee '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                //          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ",  '" + aEmployeeReport.Criteria.ToLower() + "','ProEntitle'";
                //    ConstrName = "ApplicationServices";
                //    ReportType = aEmployeeReport.Format;
                //    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                //    break;

                //case "IncrEntitle":
                //    ReportPath = "/ReportViewer/HR/rptIncrEntitle.rdlc";
                //    SqlCmd = "Exec HR_RptEmployee '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                //          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ",  '" + aEmployeeReport.Criteria.ToLower() + "','ImctEntitle'";
                //    ConstrName = "ApplicationServices";
                //    ReportType = aEmployeeReport.Format;
                //    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                //    break;
                case "Employee List with Picture":
                    ReportPath = "/ReportViewer/HR/rptEmpListPicture.rdlc";
                    SqlCmd = "Exec HR_RptEmployee '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ",  '" + aEmployeeReport.Criteria.ToLower() + "','EmployeeListwithPicture'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "BCIC_Jonobol_Data":

                    ReportPath = "/ReportViewer/HR/rptBCIC.rdlc";
                    SqlCmd = "Exec HR_RptBCIC '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ", '" + aEmployeeReport.Criteria.ToLower() + "','BCIC_Jonobol_Data'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;


                case "All_Jonobol_data":

                    ReportPath = "/ReportViewer/HR/rptAllJonobol.rdlc";
                    SqlCmd = "Exec HR_AllJonobolData '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ", '" + aEmployeeReport.Criteria.ToLower() + "','All_Jonobol_data'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "monthly_manpower":

                    ReportPath = "/ReportViewer/HR/rptManpower.rdlc";
                    SqlCmd = "Exec HR_Rpt_Manpower_monthly '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ", '" + aEmployeeReport.Criteria.ToLower() + "','monthly_manpower'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "manpower_worker":

                    ReportPath = "/ReportViewer/HR/rptManpowerWorker.rdlc";
                    SqlCmd = "Exec HR_Rptthree_month '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ", '" + aEmployeeReport.Criteria.ToLower() + "','manpower_worker'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "manpower_Staff":

                    ReportPath = "/ReportViewer/HR/rptManpowerStaff.rdlc";
                    SqlCmd = "Exec HR_Rptthree_month '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ", '" + aEmployeeReport.Criteria.ToLower() + "','manpower_Staff'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "manpower_Officer":

                    ReportPath = "/ReportViewer/HR/rptManpowerOfficer.rdlc";
                    SqlCmd = "Exec HR_Rptthree_month '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ", '" + aEmployeeReport.Criteria.ToLower() + "','manpower_Officer'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "List_of_Casual_worker":

                    ReportPath = "/ReportViewer/HR/rptCasuals_employee.rdlc";
                    SqlCmd = "Exec HR_empinfo '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ",  '" + aEmployeeReport.Criteria.ToLower() + "','List_of_Casual_worker'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "List_of_Officer":

                    ReportPath = "/ReportViewer/HR/rptOfficer.rdlc";
                    SqlCmd = "Exec HR_empinfo '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ",  '" + aEmployeeReport.Criteria.ToLower() + "','List_of_Officer'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "List_of_Staff":

                    ReportPath = "/ReportViewer/HR/rptStaff.rdlc";
                    SqlCmd = "Exec HR_empinfo '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ",  '" + aEmployeeReport.Criteria.ToLower() + "','List_of_Staff'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "List_of_Worker":

                    ReportPath = "/ReportViewer/HR/rptworker.rdlc";
                    SqlCmd = "Exec HR_empinfo '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ",  '" + aEmployeeReport.Criteria.ToLower() + "','List_of_Worker'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;

                case "Manpower_monthly_report":

                    ReportPath = "/ReportViewer/HR/rptManpower_monthly_report.rdlc";
                    SqlCmd = "Exec HR_Rptmonthly_manpower '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ",  '" + aEmployeeReport.Criteria.ToLower() + "','Manpower_monthly_report'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
                case "Departmentwise_monthly_report":

                    ReportPath = "/ReportViewer/HR/rptDepartmentwise_monthly.rdlc";
                    SqlCmd = "Exec HR_Departmentwise_monthly '" + comid + "', '" + aEmployeeReport.FromDate + "', '" + aEmployeeReport.ToDate + "'," +
                          "" + aEmployeeReport.DeptId + ", " + aEmployeeReport.SectId + ", " + aEmployeeReport.LId + "," + aEmployeeReport.EmpId + ", " + aEmployeeReport.EmpTypeId + ",  '" + aEmployeeReport.Criteria.ToLower() + "','Departmentwise_monthly_report'";
                    ConstrName = "ApplicationServices";
                    ReportType = aEmployeeReport.Format;
                    //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

                    break;
            }

            HttpContext.Session.SetString("ReportPath", ReportPath.ToString());
            HttpContext.Session.SetString("reportquery", SqlCmd);
            string filename = aEmployeeReport.ReportName.ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
            callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
            return Redirect(callBackUrl);
        }

        public class EmployeeReport
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