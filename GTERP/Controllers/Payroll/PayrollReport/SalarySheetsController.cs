
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
    public class SalarySheetsController : Controller
    {
        private readonly GTRDBContext _context;

        public SalarySheetsController(GTRDBContext context, PayrollRepository payrollRepos)
        {
            _context = context;
            // Repository = repository;
            PayrollRepository = payrollRepos;
        }

        //public CommercialRepository Repository { get; set; }
        public PayrollRepository PayrollRepository { get; set; }

        // GET: SalarySheets
        public async Task<IActionResult> Index()
        {
            string comid = HttpContext.Session.GetString("comid");
            string userid = HttpContext.Session.GetString("userid");


            ViewBag.UnitList = _context.Cat_Unit.ToList();
            ViewBag.EmpTypeList = _context.Cat_Emp_Type.ToList();

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
                    var report = _context.HR_ReportType.Where(r => r.ReportType == "Salary Report" && r.ReportId == item.ReportId).FirstOrDefault();
                    if (report != null)
                    {
                        reports.Add(report);
                    }
                }
                ViewBag.ReportList = reports;
            }
            else
            {
                ViewBag.ReportList = _context.HR_ReportType.Where(x => x.ReportType == "Salary Report").OrderBy(x => x.SLNo).ToList();
            }


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SalarySheet SalarySheetmodel)
        {
            string SqlCmd = "";
            string ReportPath = "";
            var ConstrName = "ApplicationServices";
            var ReportType = "PDF";
            //var JObject = new JObject();
            //var d = JObject.Parse(salarySheet);
            //string objct = d["salarySheet"].ToString();
            //var aSalarySheet = JsonConvert.DeserializeObject<SalarySheet>(objct);

            ReportItem item = new ReportItem();
            var comid = HttpContext.Session.GetString("comid");

            SalarySheetGrid aSalarySheet = SalarySheetmodel.SalarySheetPropGrid;
            ReportType = aSalarySheet.ReportFormat;
            switch (aSalarySheet.ReportType)
            {
                case "Salary Sheet":
                    SqlCmd = "Exec Payroll_rptSalarySheet '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" + aSalarySheet.EmpStatus + "'";

                    if (aSalarySheet.EmpType == "Officer")
                    {
                        ReportPath = "/ReportViewer/Payroll/rptSalarySheetOfficer.rdlc";
                    }
                    else if (aSalarySheet.EmpType == "Staff")
                    {
                        ReportPath = "/ReportViewer/Payroll/rptSalarySheetStaff.rdlc";
                    }
                    else
                    {
                        ReportPath = "/ReportViewer/Payroll/rptSalarySheetWorker.rdlc";
                    }

                    break;

                case "Payslip":
                    SqlCmd = "Exec Payroll_rptSalarySheet '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" + aSalarySheet.EmpStatus + "'";

                    if (aSalarySheet.EmpType == "Officer")
                    {
                        ReportPath = "/ReportViewer/Payroll/rptPaySlipOfficer.rdlc";
                    }
                    else if (aSalarySheet.EmpType == "Staff")
                    {
                        ReportPath = "/ReportViewer/Payroll/rptPaySlipStaff.rdlc";
                    }
                    else
                    {
                        ReportPath = "/ReportViewer/Payroll/rptPaySlipWorker.rdlc";
                    }

                    break;

                case "Summary Sheet":
                    SqlCmd = "Exec Payroll_rptSalarySum '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" + aSalarySheet.EmpStatus + "'";

                    if (aSalarySheet.EmpType == "Officer")
                    {
                        ReportPath = "/ReportViewer/Payroll/rptSummurySheetOfficer.rdlc";
                    }
                    else if (aSalarySheet.EmpType == "Staff")
                    {
                        ReportPath = "/ReportViewer/Payroll/rptSummurySheetStaff.rdlc";
                    }
                    else
                    {
                        ReportPath = "/ReportViewer/Payroll/rptSummurySheetWorker.rdlc";
                    }

                    break;

                case "Salary Top Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','Salary Top Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptSalaryTopSheet.rdlc";
                    break;

                case "Bank Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryBankSheet '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','Bank Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptSalaryBankSheet.rdlc";
                    break;

                case "Salary Addition Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','Salary Addition Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptSalaryAddition.rdlc";
                    break;


                case "Salary Deduction Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','Salary Deduction Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptSalaryDedcution.rdlc";
                    break;

                case "Salary Reconciliation":
                    SqlCmd = "Exec HR_rptSalaryReconciliation '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "'";
                    ReportPath = "/ReportViewer/Payroll/rptSalaryReconciliation.rdlc";
                    break;

                case "OT Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','OT Sheet'";

                    if (aSalarySheet.EmpType == "Staff")
                    {
                        ReportPath = "/ReportViewer/Payroll/rptOTSheetStaff.rdlc";
                    }
                    else
                    {
                        ReportPath = "/ReportViewer/Payroll/rptOTSheetWorker.rdlc";
                    }
                    break;

                case "OT Bank Sheet":

                    SqlCmd = "Exec Payroll_rptSalaryBankSheet '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','OT Bank Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptSalaryBankSheet.rdlc";
                    break;

                case "OT Top Sheet":

                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','OT Top Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptOTTopSheet.rdlc";
                    break;

                case "OT Top 10 Sheet":

                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','OT Top 10 Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptTop10OverTime.rdlc";
                    break;

                case "FC Sheet":

                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','FC Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptFCSheet.rdlc";
                    break;

                case "FC Bank Sheet":

                    SqlCmd = "Exec Payroll_rptSalaryBankSheet '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','FC Bank Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptSalaryBankSheet.rdlc";
                    break;

                case "FC Top Sheet":

                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','FC Top Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptFCSummarySheet.rdlc";
                    break;

                case "PF Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','PF Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptSalaryPF.rdlc";
                    break;

                case "BCIC PENSION FUND Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','BCIC PENSION FUND Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptPensionFund.rdlc";
                    break;

                case "PF (Local) Details":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','PF (Local) Details'";
                    ReportPath = "/ReportViewer/Payroll/rptPFDetails.rdlc";
                    break;

                case "PF (BCIC) Details":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','PF (BCIC) Details'";
                    ReportPath = "/ReportViewer/Payroll/rptPFDetailsBCIC.rdlc";
                    break;

                case "PF (O.P) Details":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','PF (O.P) Details'";
                    ReportPath = "/ReportViewer/Payroll/rptPFDetails.rdlc";
                    break;

                case "PF Loan (Local) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','PF Loan (Local) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptPFLoanStatement.rdlc";
                    break;
                case "PF Loan (O.P) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','PF Loan (O.P) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptPFLoanStatement.rdlc";
                    break;
                case "MC Loan (Local) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','MC Loan (Local) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptMCLoanStatement.rdlc";
                    break;
                case "MC Loan (O.P) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','MC Loan (O.P) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptMCLoanStatement.rdlc";
                    break;
                case "HB Loan (Local) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','HB Loan (Local) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptHBLoanStatement.rdlc";
                    break;
                case "HB Loan (O.P) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','HB Loan (O.P) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptHBLoanStatement.rdlc";
                    break;
                case "WFL Loan (Local) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','WFL Loan (Local) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptWFLLoanStatement.rdlc";
                    break;
                case "WFL Loan (O.P) Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','WFL Loan (O.P) Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptWFLLoanStatement.rdlc";
                    break;
                case "Loan Sheet":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','Loan Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanStatement.rdlc";
                    break;


                case "HB Loan Summary":
                    SqlCmd = "Exec rptLoanDeductionSum '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','HB Loan Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanHBSum.rdlc";
                    break;

                case "MC Loan Summary":
                    SqlCmd = "Exec rptLoanDeductionSum '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','MC Loan Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanMCSum.rdlc";
                    break;

                case "WF Loan Summary":
                    SqlCmd = "Exec rptLoanDeductionSum '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','WF Loan Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanWFSum.rdlc";
                    break;

                case "PF Loan Summary":
                    SqlCmd = "Exec rptLoanDeductionSum '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','PF Loan Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanPFSum.rdlc";
                    break;

                case "OTHER  Loan Summary":
                    SqlCmd = "Exec rptLoanDeductionSum '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','OTHER Loan Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptLoanOtherSum.rdlc";
                    break;


                case "Suppliment Salary ":
                    SqlCmd = "Exec Payroll_Suppliment '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','Suppliment Salary '";
                    ReportPath = "/ReportViewer/Payroll/rptSupplimentSheet.rdlc";
                    break;


                case "LPC Letter":
                    SqlCmd = "Exec Payroll_LPC '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','Suppliment Salary '";
                    ReportPath = "/ReportViewer/Payroll/rptLPC.rdlc";
                    break;

                case "Local Project Cost Statement":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','Local Project Cost Statement'";
                    ReportPath = "/ReportViewer/Payroll/rptOPCostStatement.rdlc";
                    break;

                case "Others Project Cost Statement":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','Others Project Cost Statement'";
                    ReportPath = "/ReportViewer/Payroll/rptOPCostStatement.rdlc";
                    break;


                case "Others Project Cost Summary":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','Others Project Cost Summary'";
                    ReportPath = "/ReportViewer/Payroll/rptOPCostSummary.rdlc";
                    break;

                case "Other Deduction Statement":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','Other Deduction Statement'";
                    ReportPath = "/ReportViewer/Payroll/rptOtherDedAssociation.rdlc";
                    break;

                case "Leave Encashment":
                    SqlCmd = "Exec Payroll_rptSalaryAll '" + comid + "', '" + aSalarySheet.ProssType + "', '" + aSalarySheet.Paymode + "','" + aSalarySheet.Unit + "','" +
                           "" + aSalarySheet.EmpType + "',  '" + aSalarySheet.DeptId + "'," + aSalarySheet.SectId + "," + aSalarySheet.EmpId + ", '" + aSalarySheet.LId + "','" +
                           aSalarySheet.EmpStatus + "','Leave Encashment'";
                    ReportPath = "/ReportViewer/Payroll/rptLeaveEncashment.rdlc";
                    break;
            }

            HttpContext.Session.SetString("ReportPath", ReportPath.ToString());
            HttpContext.Session.SetString("reportquery", SqlCmd);
            string filename = aSalarySheet.ReportType.ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

            //string callBackUrl =  this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
            string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
            return Redirect(callBackUrl);
        }

    }
}
