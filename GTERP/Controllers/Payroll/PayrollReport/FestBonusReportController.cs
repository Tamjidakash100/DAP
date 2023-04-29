
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
    public class FestBonusReportController : Controller
    {
        private readonly GTRDBContext _context;

        public FestBonusReportController(GTRDBContext context, PayrollRepository payrollRepos)
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

            ViewBag.PayModeList = _context.Cat_PayMode.ToList();

            ViewBag.UnitList = _context.Cat_Unit.ToList();

            //ViewBag.FestivalTypeList= await _context.HR_Emp_Info.Where(x=>x.s).ToListAsync();

            ViewBag.FestivalTypeList = _context.Cat_Variable.Where(x => x.VarType == "FestivalType").OrderBy(x => x.SLNo).ToList();

            ViewBag.ProcessTypeList = PayrollRepository.GetFestBonusProssTypes();

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
                    var report = _context.HR_ReportType.Where(r => r.ReportType == "Festival Report" && r.ReportId == item.ReportId).FirstOrDefault();
                    if (report != null)
                    {
                        reports.Add(report);
                    }
                }
                ViewBag.ReportList = reports;
            }
            else
            {
                ViewBag.ReportList = _context.HR_ReportType.Where(x => x.ReportType == "Festival Report").OrderBy(x => x.SLNo).ToList();
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(FestivalBonus FestivalBonusmodel)
        {
            string SqlCmd = "";
            string ReportPath = "";
            var ConstrName = "ApplicationServices";
            var ReportType = "PDF";

            ReportItem item = new ReportItem();
            var comid = HttpContext.Session.GetString("comid");

            FestivalBonusGrid aFestBonus = FestivalBonusmodel.FestivalBonusPropGrid;
            ReportType = aFestBonus.ReportFormat;
            switch (aFestBonus.ReportType)
            {
                case "Festival Bonus Sheet":
                    SqlCmd = "Exec Payroll_rptFestBonus '" + comid + "', '" + aFestBonus.ProssType + "', '" + aFestBonus.Paymode + "','" + aFestBonus.Unit + "','" +
                           "" + aFestBonus.EmpType + "',  '" + aFestBonus.DeptId + "', '" + aFestBonus.SectId + "'," + aFestBonus.EmpId + ", '" + aFestBonus.LId + "','" +
                           aFestBonus.FestivalType + "','Festival Bonus Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptFestBonusSheet.rdlc";
                    break;

                case "Festival Bonus Top Sheet":
                    SqlCmd = "Exec Payroll_rptFestBonus '" + comid + "', '" + aFestBonus.ProssType + "', '" + aFestBonus.Paymode + "','" + aFestBonus.Unit + "','" +
                           "" + aFestBonus.EmpType + "',  '" + aFestBonus.DeptId + "', '" + aFestBonus.SectId + "'," + aFestBonus.EmpId + ", '" + aFestBonus.LId + "','" +
                           aFestBonus.FestivalType + "','Festival Bonus Top Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptFestBonusTopSheet.rdlc";
                    break;

                case "Festival Bonus Bank Sheet":
                    SqlCmd = "Exec Payroll_rptFestBonus '" + comid + "', '" + aFestBonus.ProssType + "', '" + aFestBonus.Paymode + "','" + aFestBonus.Unit + "','" +
                           "" + aFestBonus.EmpType + "',  '" + aFestBonus.DeptId + "', '" + aFestBonus.SectId + "'," + aFestBonus.EmpId + ", '" + aFestBonus.LId + "','" +
                           aFestBonus.FestivalType + "','Festival Bonus Bank Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptFestBonusBankSheet.rdlc";
                    break;
                case "Gratuity Sheet":
                    SqlCmd = "Exec Payroll_rptFestBonus '" + comid + "', '" + aFestBonus.ProssType + "', '" + aFestBonus.Paymode + "','" + aFestBonus.Unit + "','" +
                           "" + aFestBonus.EmpType + "',  '" + aFestBonus.DeptId + "', '" + aFestBonus.SectId + "'," + aFestBonus.EmpId + ", '" + aFestBonus.LId + "','" +
                           aFestBonus.FestivalType + "','Gratuity Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptGratuitySheet.rdlc";
                    break;

                case "Gratuity Top Sheet":
                    SqlCmd = "Exec Payroll_rptFestBonus '" + comid + "', '" + aFestBonus.ProssType + "', '" + aFestBonus.Paymode + "','" + aFestBonus.Unit + "','" +
                           "" + aFestBonus.EmpType + "',  '" + aFestBonus.DeptId + "', '" + aFestBonus.SectId + "'," + aFestBonus.EmpId + ", '" + aFestBonus.LId + "','" +
                           aFestBonus.FestivalType + "','Gratuity Top Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptGratuityTopSheet.rdlc";
                    break;

                case "Nabo Barsha Vhata Sheet":
                    SqlCmd = "Exec Payroll_rptFestBonus '" + comid + "', '" + aFestBonus.ProssType + "', '" + aFestBonus.Paymode + "','" + aFestBonus.Unit + "','" +
                           "" + aFestBonus.EmpType + "',  '" + aFestBonus.DeptId + "', '" + aFestBonus.SectId + "'," + aFestBonus.EmpId + ", '" + aFestBonus.LId + "','" +
                           aFestBonus.FestivalType + "','Nabo Barsha Vhata Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptNaboBarshaSheet.rdlc";
                    break;
                case "Nabo Barsha Vhata Top Sheet":
                    SqlCmd = "Exec Payroll_rptFestBonus '" + comid + "', '" + aFestBonus.ProssType + "', '" + aFestBonus.Paymode + "','" + aFestBonus.Unit + "','" +
                           "" + aFestBonus.EmpType + "',  '" + aFestBonus.DeptId + "', '" + aFestBonus.SectId + "'," + aFestBonus.EmpId + ", '" + aFestBonus.LId + "','" +
                           aFestBonus.FestivalType + "','Nabo Barsha Vhata Top Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptNaboBarshaTopSheet.rdlc";
                    break;

                case "Recreation Allowance Sheet":
                    SqlCmd = "Exec Payroll_rptFestBonus '" + comid + "', '" + aFestBonus.ProssType + "', '" + aFestBonus.Paymode + "','" + aFestBonus.Unit + "','" +
                           "" + aFestBonus.EmpType + "',  '" + aFestBonus.DeptId + "', '" + aFestBonus.SectId + "'," + aFestBonus.EmpId + ", '" + aFestBonus.LId + "','" +
                           aFestBonus.FestivalType + "','Recreation Allowance Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptRecreationAllowanceSheet.rdlc";
                    break;
                case "Recreation Allowance Top Sheet":
                    SqlCmd = "Exec Payroll_rptFestBonus '" + comid + "', '" + aFestBonus.ProssType + "', '" + aFestBonus.Paymode + "','" + aFestBonus.Unit + "','" +
                           "" + aFestBonus.EmpType + "',  '" + aFestBonus.DeptId + "', '" + aFestBonus.SectId + "'," + aFestBonus.EmpId + ", '" + aFestBonus.LId + "','" +
                           aFestBonus.FestivalType + "','Recreation Allowance Top Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptRecreationAllowanceTopSheet.rdlc";
                    break;

                case "Summer Winter Allowance Sheet":
                    SqlCmd = "Exec Payroll_rptFestBonus '" + comid + "', '" + aFestBonus.ProssType + "', '" + aFestBonus.Paymode + "','" + aFestBonus.Unit + "','" +
                           "" + aFestBonus.EmpType + "',  '" + aFestBonus.DeptId + "', '" + aFestBonus.SectId + "'," + aFestBonus.EmpId + ", '" + aFestBonus.LId + "','" +
                           aFestBonus.FestivalType + "','Summer Winter Allowance Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptSummerWinterSheet.rdlc";
                    break;

                case "Summer Winter Bank Sheet":
                    SqlCmd = "Exec Payroll_rptFestBonus '" + comid + "', '" + aFestBonus.ProssType + "', '" + aFestBonus.Paymode + "','" + aFestBonus.Unit + "','" +
                           "" + aFestBonus.EmpType + "',  '" + aFestBonus.DeptId + "', '" + aFestBonus.SectId + "'," + aFestBonus.EmpId + ", '" + aFestBonus.LId + "','" +
                           aFestBonus.FestivalType + "','Summer Winter Bank Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptSummerWinterBankSheet.rdlc";
                    break;

                case "Summer Winter Top Sheet":
                    SqlCmd = "Exec Payroll_rptFestBonus '" + comid + "', '" + aFestBonus.ProssType + "', '" + aFestBonus.Paymode + "','" + aFestBonus.Unit + "','" +
                           "" + aFestBonus.EmpType + "',  '" + aFestBonus.DeptId + "', '" + aFestBonus.SectId + "'," + aFestBonus.EmpId + ", '" + aFestBonus.LId + "','" +
                           aFestBonus.FestivalType + "','Summer Winter Top Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptSummerWinterTopSheet.rdlc";
                    break;

                case "Incentive Bonus Sheet":
                    SqlCmd = "Exec Payroll_rptFestBonus '" + comid + "', '" + aFestBonus.ProssType + "', '" + aFestBonus.Paymode + "','" + aFestBonus.Unit + "','" +
                           "" + aFestBonus.EmpType + "',  '" + aFestBonus.DeptId + "', '" + aFestBonus.SectId + "'," + aFestBonus.EmpId + ", '" + aFestBonus.LId + "','" +
                           aFestBonus.FestivalType + "','Incentive Bonus Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptIncentiveBonusSheet.rdlc";
                    break;

                case "Incentive Bonus Top Sheet":
                    SqlCmd = "Exec Payroll_rptFestBonus '" + comid + "', '" + aFestBonus.ProssType + "', '" + aFestBonus.Paymode + "','" + aFestBonus.Unit + "','" +
                           "" + aFestBonus.EmpType + "',  '" + aFestBonus.DeptId + "', '" + aFestBonus.SectId + "'," + aFestBonus.EmpId + ", '" + aFestBonus.LId + "','" +
                           aFestBonus.FestivalType + "','Incentive Bonus Top Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptIncentiveBonusTopSheet.rdlc";
                    break;

                case "Advanced Incentive Bonus Sheet":
                    SqlCmd = "Exec Payroll_rptFestBonus '" + comid + "', '" + aFestBonus.ProssType + "', '" + aFestBonus.Paymode + "','" + aFestBonus.Unit + "','" +
                           "" + aFestBonus.EmpType + "',  '" + aFestBonus.DeptId + "', '" + aFestBonus.SectId + "'," + aFestBonus.EmpId + ", '" + aFestBonus.LId + "','" +
                           aFestBonus.FestivalType + "','Advanced Incentive Bonus Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptIncentiveBonusSheet.rdlc";
                    break;

                case "Adv. Incentive Bonus Top Sheet":
                    SqlCmd = "Exec Payroll_rptFestBonus '" + comid + "', '" + aFestBonus.ProssType + "', '" + aFestBonus.Paymode + "','" + aFestBonus.Unit + "','" +
                           "" + aFestBonus.EmpType + "',  '" + aFestBonus.DeptId + "', '" + aFestBonus.SectId + "'," + aFestBonus.EmpId + ", '" + aFestBonus.LId + "','" +
                           aFestBonus.FestivalType + "','Adv. Incentive Bonus Top Sheet'";
                    ReportPath = "/ReportViewer/Payroll/rptIncentiveBonusTopSheet.rdlc";
                    break;
            }


            HttpContext.Session.SetString("ReportPath", ReportPath.ToString());
            HttpContext.Session.SetString("reportquery", SqlCmd);
            string filename = aFestBonus.ReportType.ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
            //string callBackUrl =  this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
            string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
            return Redirect(callBackUrl);
        }

    }
}
