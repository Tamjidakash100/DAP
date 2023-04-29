using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using GTERP.Models.Payroll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GTERP.Controllers.Payroll.PayrollReport
{
    [OverridableAuthorize]
    public class EarnLeaveSheetController : Controller
    {
        private readonly GTRDBContext _context;
        public EarnLeaveSheetController(GTRDBContext context, PayrollRepository repository)
        {
            _context = context;
            Repository = repository;
            //Repos = repos;
        }

        public GTRDBContext Context { get; }
        public PayrollRepository Repository { get; }
        //public CommercialRepository Repos { get; }

        // GET: EarnLeaveSheet
        [HttpGet]
        public ActionResult Index()
        {

            //ViewBag.EmpTypeList = _context.Cat_Emp_Type.ToList();

            //ViewBag.PayModeList = _context.Cat_PayMode.ToList();

            ////ViewBag.EmpStatusList= await _context.HR_Emp_Info.Where(x=>x.s).ToListAsync();

            //ViewBag.EmpStatusList = _context.Cat_Variable.Where(x => x.VarType == "EmpStatus").ToList();

            //ViewBag.ProcessTypeList = PayrollRepository.GetFestBonusProssTypes();

            //ViewBag.DepartmentList = _context.Cat_Department.ToList();

            //ViewBag.EmpList = _context.HR_Emp_Info.ToList();

            //ViewBag.LocationList = _context.Cat_Location.ToList();

            ////List<string> Reporttype = PayrollRepository.ReportName();
            //ViewBag.ReportList = _context.HR_ReportType.Where(x => x.ReportType == "Festival Report").OrderBy(x => x.SLNo).ToList();

            //return View();


            ViewBag.EmpTypeList = _context.Cat_Emp_Type.ToList();

            ViewBag.PayModeList = _context.Cat_PayMode.ToList();

            //ViewBag.EmpStatusList= await _context.HR_Emp_Info.Where(x=>x.s).ToListAsync();

            ViewBag.EmpStatusList = _context.Cat_Variable.Where(x => x.VarType == "EmpStatus").ToList();

            ViewBag.ProcessTypeList = PayrollRepository.GetElProssTypes();

            ViewBag.DepartmentList = _context.Cat_Department.ToList();

            ViewBag.EmpList = _context.HR_Emp_Info.ToList();

            ViewBag.LocationList = _context.Cat_Location.ToList();

            //List<string> Reporttype = PayrollRepository.ReportName();
            ViewBag.ReportList = _context.HR_ReportType.Where(x => x.ReportType == "EarnLvSheet Report").OrderBy(x => x.SLNo).ToList();

            return View();
        }


        [HttpPost]
        public ActionResult Index(EarnLeaveSheet earnLeaveSheet)
        {

            string SqlCmd = "";
            string ReportPath = "";
            var ConstrName = "ApplicationServices";
            var ReportType = "PDF";
            ReportItem item = new ReportItem();
            var comid = HttpContext.Session.GetString("comid");

            EarnLeaveSheetGrid aEarnLeaveSheet = earnLeaveSheet.EarnLeaveSheetPropGrid;



            switch (aEarnLeaveSheet.ReportType)
            {


                case "Leave Encashment":
                    SqlCmd = "Exec Payroll_rptEarnLeaveEncashment '" + comid + "', '" + aEarnLeaveSheet.ProssType + "', '" + aEarnLeaveSheet.Paymode + "','" + "" + aEarnLeaveSheet.EmpType + "',  '" + aEarnLeaveSheet.DeptId + "'," + aEarnLeaveSheet.EmpId + ", '" + aEarnLeaveSheet.LId + "','" +
                           aEarnLeaveSheet.EmpStatus + "','Leave Encashment'";
                    ReportPath = "/ReportViewer/Payroll/rptLeaveEncashment.rdlc";
                    break;

            }
            HttpContext.Session.SetString("ReportPath", ReportPath.ToString());
            HttpContext.Session.SetString("reportquery", SqlCmd);
            string filename = aEarnLeaveSheet.ReportType.ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
            string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
            return Redirect(callBackUrl);
        }
    }

}