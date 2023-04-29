
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
    public class BoardPaperController : Controller
    {
        private readonly GTRDBContext _context;

        public BoardPaperController(GTRDBContext context, PayrollRepository payrollRepos)
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
                    var report = _context.HR_ReportType.Where(r => r.ReportType == "Board Paper Report" && r.ReportId == item.ReportId).FirstOrDefault();
                    if (report != null)
                    {
                        reports.Add(report);
                    }
                }
                ViewBag.ReportList = reports;
            }
            else
            {
                ViewBag.ReportList = _context.HR_ReportType.Where(x => x.ReportType == "Board Paper Report").OrderBy(x => x.SLNo).ToList();
            }


            return View();
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(BoardPaper BoardPapermodel)
        {
            string SqlCmd = "";
            string ReportPath = "";
            var ConstrName = "ApplicationServices";
            var ReportType = "PDF";

            ReportItem item = new ReportItem();
            var comid = HttpContext.Session.GetString("comid");

            BoardPaperGrid aBoardPaper = BoardPapermodel.BoardPaperPropGrid;
            ReportType = aBoardPaper.ReportFormat;

            switch (aBoardPaper.ReportType)
            {
                case "ফুড এন্ড কনভেন্স ব্যয় বিবরণী":
                    SqlCmd = "Exec Payroll_rptBoardPaper '" + comid + "', '" + aBoardPaper.ProssType + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth + "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "', '" + aBoardPaper.EmpType + "','" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" + aBoardPaper.EmpStatus + "','ফুড এন্ড কনভেন্স ব্যয় বিবরণী'";
                    ReportPath = "/ReportViewer/Payroll/rptBoardPaperFC.rdlc";
                    break;

                case "ওভারটাইম ব্যয় বিবরণী":
                    SqlCmd = "Exec Payroll_rptBoardPaper '" + comid + "', '" + aBoardPaper.ProssType + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                           "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" + aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                           aBoardPaper.EmpStatus + "','ওভারটাইম ব্যয় বিবরণী'";
                    ReportPath = "/ReportViewer/Payroll/rptBoardPaperOT.rdlc";
                    break;


                case "অতিরিক্ত শ্রমঘন্টা বিবরণী":
                    SqlCmd = "Exec Payroll_rptBoardPaper '" + comid + "', '" + aBoardPaper.ProssType + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                           "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" +
                           aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                           aBoardPaper.EmpStatus + "','অতিরিক্ত শ্রমঘন্টা বিবরণী'";
                    ReportPath = "/ReportViewer/Payroll/rptBoardPaperOTHour.rdlc";
                    break;

                case "ওভারটাইম ব্যয় বিবরণী (শাখা অনুযায়ী)":
                    SqlCmd = "Exec Payroll_rptBoardPaper '" + comid + "', '" + aBoardPaper.ProssType + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                           "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" + aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                           aBoardPaper.EmpStatus + "','ওভারটাইম ব্যয় বিবরণী (শাখা অনুযায়ী)'";
                    ReportPath = "/ReportViewer/Payroll/rptBoardPaperOTSectWise.rdlc";
                    break;

                case "অতিরিক্ত শ্রমঘন্টা বিবরণী (শাখা অনুযায়ী)":
                    SqlCmd = "Exec Payroll_rptBoardPaper '" + comid + "', '" + aBoardPaper.ProssType + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                           "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" +
                           aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                           aBoardPaper.EmpStatus + "','অতিরিক্ত শ্রমঘন্টা বিবরণী (শাখা অনুযায়ী)'";
                    ReportPath = "/ReportViewer/Payroll/rptBoardPaperOTHourSectWise.rdlc";
                    break;

                case "Salary Summary Overview":
                    SqlCmd = "Exec Payroll_rptSalaryOverview '" + comid + "', '" + aBoardPaper.ProssType + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                           "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" +
                           aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                           aBoardPaper.EmpStatus + "','Salary Summary Overview'";
                    ReportPath = "/ReportViewer/Payroll/rptSalarySumOverview.rdlc";
                    break;

                case "Income Tax Certificate":
                    SqlCmd = "Exec Payroll_rptIncomeTaxCert '" + comid + "', '" + aBoardPaper.ProssType + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                           "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" +
                           aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                           aBoardPaper.EmpStatus + "'";
                    ReportPath = "/ReportViewer/Payroll/rptIncomeTaxCert.rdlc";
                    break;

                case "Income Tax Sheet":
                    SqlCmd = "Exec Payroll_rptIncomeTaxSheet '" + comid + "', '" + aBoardPaper.ProssType + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                           "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" +
                           aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                           aBoardPaper.EmpStatus + "'";
                    ReportPath = "/ReportViewer/Payroll/rptIncomeTax.rdlc";
                    break;

                case "ITax Statement":
                    ReportPath = "/ReportViewer/Payroll/rptITStatement.rdlc";
                    SqlCmd = "Exec Payroll_rptITaxStatement'" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                            "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "', '" + aBoardPaper.EmpType + "','" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                            aBoardPaper.EmpStatus + "','ITax Statement'";
                    break;

                case "ITax Summary":
                    ReportPath = "/ReportViewer/Payroll/rptITSummary.rdlc";
                    SqlCmd = "Exec Payroll_rptITaxStatement'" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                            "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "', '" + aBoardPaper.EmpType + "','" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                            aBoardPaper.EmpStatus + "','ITax Summary'";
                    break;

                case "MotorCycle Loan Letter":
                    SqlCmd = "Exec HR_rptLoanLetter '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth + "','" + aBoardPaper.EmpType + "', " +
                          "" + aBoardPaper.SectId + ", " + aBoardPaper.EmpId + ",  'MotorCycle Loan Letter'";
                    ReportPath = "/ReportViewer/Payroll/rptRecoveryMCLoan.rdlc"; ;
                    break;

                case "Welfare Loan Letter ":
                    SqlCmd = "Exec HR_rptLoanLetter '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth + "','" + aBoardPaper.EmpType + "', " +
                          "" + aBoardPaper.SectId + ", " + aBoardPaper.EmpId + ",  'Welfare Loan Letter'";
                    ReportPath = "/ReportViewer/Payroll/rptRecoveryWFLoan.rdlc";
                    break;

                case "House Building Loan Letter":
                    SqlCmd = "Exec HR_rptLoanLetter '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth + "','" + aBoardPaper.EmpType + "', " +
                          "" + aBoardPaper.SectId + ", " + aBoardPaper.EmpId + ",  'House Building Loan Letter'";
                    ReportPath = "/ReportViewer/Payroll/rptRecoveryHBLoan.rdlc"; ;
                    break;

                case "PF Loan Letter":
                    SqlCmd = "Exec HR_rptLoanLetter '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth + "','" + aBoardPaper.EmpType + "', " +
                          "" + aBoardPaper.SectId + ", " + aBoardPaper.EmpId + ",  'PF Loan Letter'";
                    ReportPath = "/ReportViewer/Payroll/rptRecoveryPFLoan.rdlc"; ;
                    break;

                case "Other Loan Letter":
                    SqlCmd = "Exec HR_rptLoanLetter '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth + "','" + aBoardPaper.EmpType + "', " +
                          "" + aBoardPaper.SectId + ", " + aBoardPaper.EmpId + ",  'Other Loan Letter'";
                    ReportPath = "/ReportViewer/Payroll/rptRecoveryOtherLoan.rdlc"; ;
                    break;

                case "PF Statement Of Member's Account (Total))":
                    SqlCmd = "Exec Payroll_rptPFIndividual'" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                            "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "', '" + aBoardPaper.EmpType + "','" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                            aBoardPaper.EmpStatus + "','PF Individual Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptPFYearlyIndividualSheet.rdlc";
                    break;

                case "Member PF Fund Transfer to O.P.":
                    SqlCmd = "Exec Payroll_rptPFIndividual'" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                            "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "', '" + aBoardPaper.EmpType + "','" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                            aBoardPaper.EmpStatus + "','Member PF Fund Transfer to O.P.'";
                    ReportPath = "/ReportViewer/Payroll/rptPFFundTransferSheet.rdlc";
                    break;

                case "PF Members Ledger":
                    SqlCmd = "Exec Payroll_rptPFMLedger'" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                            "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "', '" + aBoardPaper.EmpType + "','" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                            aBoardPaper.EmpStatus + "','PF Members Ledger'";

                    ReportPath = "/ReportViewer/Payroll/rptPFMembersLedger.rdlc";
                    break;


                case "PF Individual Loan Statement":
                    SqlCmd = "Exec Payroll_rptPFStatement '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                          "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" + aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                          aBoardPaper.EmpStatus + "','PF Individual Loan Statement'";
                    ReportPath = "/ReportViewer/Payroll/rptPFStatement.rdlc";
                    break;

                case "PF Individual Ledger":
                    SqlCmd = "Exec Payroll_rptPFIndividual '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                          "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" + aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                          aBoardPaper.EmpStatus + "','PF Individual Ledger'";
                    ReportPath = "/ReportViewer/Payroll/rptSalaryPFIndLedger.rdlc";
                    break;

                case "PF Final Settlement":
                    SqlCmd = "Exec Payroll_rptPFIndividual'" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                            "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "', '" + aBoardPaper.EmpType + "','" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                            aBoardPaper.EmpStatus + "','PF Final Settlement'";
                    ReportPath = "/ReportViewer/Payroll/rptPFFinalSettlement.rdlc";
                    break;

                case "PF Loan Ledger":
                    SqlCmd = "Exec Payroll_rptPFLoanLedger '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                          "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" + aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                          aBoardPaper.EmpStatus + "','PF Loan Ledger'";
                    ReportPath = "/ReportViewer/Payroll/rptPFLoanLedger.rdlc";
                    break;

                case "HB Loan Individual Ledger":
                    SqlCmd = "Exec Payroll_rptPFIndividual '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                          "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" + aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                          aBoardPaper.EmpStatus + "','HB Loan Individual Ledger'";
                    ReportPath = "/ReportViewer/Payroll/rptIndLoanLedger.rdlc";
                    break;

                case "HB Loan Ledger":
                    SqlCmd = "Exec Payroll_rptHBLoanLedger '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                          "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" + aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                          aBoardPaper.EmpStatus + "','HB Loan Ledger'";
                    ReportPath = "/ReportViewer/Payroll/rptHBLoanLedger.rdlc";
                    break;

                case "MC Loan Individual Ledger":
                    SqlCmd = "Exec Payroll_rptPFIndividual '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                          "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" + aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                          aBoardPaper.EmpStatus + "','MC Loan Individual Ledger'";
                    ReportPath = "/ReportViewer/Payroll/rptIndLoanLedger.rdlc";
                    break;

                case "MC Loan Ledger":
                    SqlCmd = "Exec Payroll_rptMCLoanLedger '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                          "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" + aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                          aBoardPaper.EmpStatus + "','MC Loan Ledger'";
                    ReportPath = "/ReportViewer/Payroll/rptMCLoanLedger.rdlc";
                    break;

                case "PF Loan Individual Ledger":
                    SqlCmd = "Exec Payroll_rptPFIndividual '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                          "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" + aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                          aBoardPaper.EmpStatus + "','PF Loan Individual Ledger'";
                    ReportPath = "/ReportViewer/Payroll/rptIndLoanLedger.rdlc";
                    break;

                case "WF Loan Individual Ledger":
                    SqlCmd = "Exec Payroll_rptPFIndividual '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                          "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" + aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                          aBoardPaper.EmpStatus + "','WF Loan Individual Ledger'";
                    ReportPath = "/ReportViewer/Payroll/rptIndLoanLedger.rdlc";
                    break;

                case "WF Loan Ledger":
                    SqlCmd = "Exec Payroll_rptWFLoanLedger '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                          "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" + aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                          aBoardPaper.EmpStatus + "','WF Loan Ledger'";
                    ReportPath = "/ReportViewer/Payroll/rptWFLoanLedger.rdlc";
                    break;

                case "Gratuity Ledger":
                    SqlCmd = "Exec Payroll_rptGratuityIndividual '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                          "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" + aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                          aBoardPaper.EmpStatus + "','Gratuity Ledger'";
                    ReportPath = "/ReportViewer/Payroll/rptIndGratuityLedger.rdlc";
                    break;
                case "Member Gratuity Fund Transfer to O.P.":
                    SqlCmd = "Exec Payroll_rptPFIndividual'" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                            "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "', '" + aBoardPaper.EmpType + "','" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                            aBoardPaper.EmpStatus + "','Member Gratuity Fund Transfer to O.P.'";
                    ReportPath = "/ReportViewer/Payroll/rptGratuityFundTransferSheet.rdlc";
                    break;

                case "Arrear Wages / Salary Bill":
                    SqlCmd = "Exec Payroll_rptArriarBill '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                          "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" + aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                          aBoardPaper.EmpStatus + "','Arrear Wages / Salary Bill'";
                    ReportPath = "/ReportViewer/Payroll/rptArrearBill.rdlc";
                    break;

                case "Arrear Wages / Salary Bank Advice":
                    SqlCmd = "Exec Payroll_rptArriarBill '" + comid + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                          "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" + aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                          aBoardPaper.EmpStatus + "','Arrear Wages / Salary Bank Advice'";
                    ReportPath = "/ReportViewer/Payroll/rptSalaryBankSheet.rdlc";
                    break;
                case "Others Project Cost Summary Range Wise":
                    SqlCmd = "Exec Payroll_rptBoardPaper '" + comid + "', '" + aBoardPaper.ProssType + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                           "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" +
                           aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                           aBoardPaper.EmpStatus + "','Others Project Cost Summary Range Wise'";
                    ReportPath = "/ReportViewer/Payroll/rptOPCostSummary.rdlc";
                    break;

                case "Recreation Allowance Sheet Range Wise":
                    SqlCmd = "Exec Payroll_rptBoardPaper '" + comid + "', '" + aBoardPaper.ProssType + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                           "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" +
                           aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                            aBoardPaper.EmpStatus + "','Recreation Allowance Sheet Range Wise'";
                    ReportPath = "/ReportViewer/Payroll/rptRecreationAllowanceSheet.rdlc";
                    break;
                case "Recreation Allowance Top Sheet Range Wise":
                    SqlCmd = "Exec Payroll_rptBoardPaper '" + comid + "', '" + aBoardPaper.ProssType + "', '" + BoardPapermodel.FromMonth + "', '" + BoardPapermodel.ToMonth +
                           "', '" + aBoardPaper.Paymode + "','" + aBoardPaper.Unit + "','" +
                           aBoardPaper.EmpType + "',  '" + aBoardPaper.DeptId + "','" + aBoardPaper.SectId + "'," + aBoardPaper.EmpId + ", '" + aBoardPaper.LId + "','" +
                            aBoardPaper.EmpStatus + "','Recreation Allowance Top Sheet Range Wise'";
                    ReportPath = "/ReportViewer/Payroll/rptRecreationAllowanceTopSheet.rdlc";
                    break;
            }
            HttpContext.Session.SetString("ReportPath", ReportPath.ToString());
            HttpContext.Session.SetString("reportquery", SqlCmd);
            string filename = aBoardPaper.ReportType.ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

            //string callBackUrl =  this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
            string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
            return Redirect(callBackUrl);
        }

    }
}
