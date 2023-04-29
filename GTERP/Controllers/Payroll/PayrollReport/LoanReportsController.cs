
using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using GTERP.Models.Payroll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.Payroll.PayrollReport
{
    [OverridableAuthorize]
    public class LoanReportsController : Controller
    {
        private readonly GTRDBContext _context;

        public LoanReportsController(GTRDBContext context, PayrollRepository payrollRepos)
        {
            _context = context;
            // Repository = repository;
            PayrollRepository = payrollRepos;
        }

        //public CommercialRepository Repository { get; set; }
        public PayrollRepository PayrollRepository { get; set; }

        // GET: LoanReports
        public async Task<IActionResult> Index()
        {
            string comid = HttpContext.Session.GetString("comid");
            string userid = HttpContext.Session.GetString("userid");

            ViewBag.EmpTypeList = _context.Cat_Emp_Type.ToList();

            ViewBag.UnitList = _context.Cat_Unit.ToList();

            ViewBag.PayModeList = _context.Cat_PayMode.ToList();

            ViewBag.EmpStatusList = _context.Cat_Variable.Where(x => x.VarType == "EmpStatus").ToList();

            ViewBag.ProcessTypeList = PayrollRepository.GetProssTypes();

            ViewBag.DepartmentList = _context.Cat_Department.ToList();

            ViewBag.SectionList = _context.Cat_Section.ToList();

            ViewBag.EmpList = _context.HR_Emp_Info.Include(d => d.Cat_Designation).OrderBy(o => o.EmpCode).ToList();

            ViewBag.LocationList = _context.Cat_Location.ToList();

            //List<string> Reporttype = PayrollRepository.ReportName();
            var permission = _context.ReportPermissions.Where(r => r.UserId == userid && r.ComId == comid).ToList();
            var reports = new List<HR_ReportType>();
            if (permission.Count > 0)
            {
                foreach (var item in permission)
                {
                    var report = _context.HR_ReportType.Where(r => r.ReportType == "Loan Report" && r.ReportId == item.ReportId).FirstOrDefault();
                    if (report != null)
                    {
                        reports.Add(report);
                    }
                }
                ViewBag.ReportList = reports;
            }
            else
            {
                ViewBag.ReportList = _context.HR_ReportType.Where(x => x.ReportType == "Loan Report").OrderBy(x => x.SLNo).ToList();
            }


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoanReport LoanReportmodel)
        {
            string SqlCmd = "";
            string ReportPath = "";
            var ConstrName = "ApplicationServices";
            var ReportType = "PDF";


            ReportItem item = new ReportItem();
            var comid = HttpContext.Session.GetString("comid");

            LoanReportGrid aLoanReport = LoanReportmodel.LoanReportPropGrid;
            ReportType = aLoanReport.ReportFormat;
            switch (aLoanReport.ReportType)
            {

                case "PF Loan (Local) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','PF Loan (Local) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptPFLoanStatement.rdlc";
                    break;
                case "PF Loan (BCIC) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','PF Loan (BCIC) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptPFLoanStatement.rdlc";
                    break;

                case "PF Loan (O.P) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','PF Loan (O.P) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptPFLoanStatement.rdlc";
                    break;
                case "MC Loan (Local) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','MC Loan (Local) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptMCLoanStatement.rdlc";
                    break;
                case "MC Loan (O.P) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','MC Loan (O.P) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptMCLoanStatement.rdlc";
                    break;
                case "HB Loan (Local) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','HB Loan (Local) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptHBLoanStatement.rdlc";
                    break;
                case "HB Loan (O.P) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','HB Loan (O.P) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptHBLoanStatement.rdlc";
                    break;
                case "WFL Loan (Local) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','WFL Loan (Local) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptWFLLoanStatement.rdlc";
                    break;
                case "WFL Loan (O.P) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','WFL Loan (O.P) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptWFLLoanStatement.rdlc";
                    break;
                case "Loan Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','Loan Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanStatement.rdlc";
                    break;


                case "HB Loan (Local) Summary":
                    SqlCmd = "Exec rptLoanDeductionSum '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','HB Loan (Local) Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanHBSum.rdlc";
                    break;

                case "HB Loan (Other) Summary":
                    SqlCmd = "Exec rptLoanDeductionSum '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','HB Loan (Other) Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanHBSum.rdlc";
                    break;

                case "MC Loan (Local) Summary":
                    SqlCmd = "Exec rptLoanDeductionSum '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','MC Loan (Local) Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanMCSum.rdlc";
                    break;

                case "MC Loan (Other) Summary":
                    SqlCmd = "Exec rptLoanDeductionSum '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','MC Loan (Other) Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanMCSum.rdlc";
                    break;

                case "WF Loan (Local) Summary":
                    SqlCmd = "Exec rptLoanDeductionSum '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','WF Loan (Local) Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanWFSum.rdlc";
                    break;

                case "WF Loan (Other) Summary":
                    SqlCmd = "Exec rptLoanDeductionSum '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','WF Loan (Other) Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanWFSum.rdlc";
                    break;

                case "PF and PF Loan (Local) Summary":
                    SqlCmd = "Exec rptLoanDeductionSum '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','PF and PF Loan (Local) Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanPFSum.rdlc";
                    break;

                case "PF and PF Loan (Other) Summary":
                    SqlCmd = "Exec rptLoanDeductionSum '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','PF and PF Loan (Other) Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanPFSum.rdlc";
                    break;
                case "PF and PF Loan (BCIC) Summary":
                    SqlCmd = "Exec rptLoanDeductionSum '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','PF and PF Loan (BCIC) Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanPFSum.rdlc";
                    break;

                case "BCIC PENSION FUND Summary":
                    SqlCmd = "Exec rptLoanDeductionSum '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','BCIC PENSION FUND Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptPFSumBCIC.rdlc";
                    break;

                case "OTHER  Loan Summary":
                    SqlCmd = "Exec rptLoanDeductionSum '" + comid + "', '" + aLoanReport.ProssType + "', '" + aLoanReport.Paymode + "','" + aLoanReport.Unit + "','" +
                           "" + aLoanReport.EmpType + "',  '" + aLoanReport.DeptId + "'," + aLoanReport.SectId + "," + aLoanReport.EmpId + ", '" + aLoanReport.LId + "','" +
                           aLoanReport.EmpStatus + "','OTHER Loan Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanOtherSum.rdlc";
                    break;
            }
            HttpContext.Session.SetString("ReportPath", ReportPath.ToString());
            HttpContext.Session.SetString("reportquery", SqlCmd);
            string filename = aLoanReport.ReportType.ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

            //string callBackUrl =  this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
            string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
            return Redirect(callBackUrl);
        }

    }
}
