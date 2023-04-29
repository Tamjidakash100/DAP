using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GTERP.Controllers.HR.HrReport
{
    [OverridableAuthorize]
    public class JobCardController : Controller
    {
        private GTRDBContext db;
        //public CommercialRepository repos;

        public JobCardController(GTRDBContext context)
        {
            db = context;
            //repos = repository;
        }

        private Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();

        public IActionResult Index()
        {
            List<Cat_Section> Cat_Sections = new List<Cat_Section>();
            Cat_Sections = db.Cat_Section.ToList();
            ViewBag.Sections = Cat_Sections;

            List<HR_Emp_Info> employee = new List<HR_Emp_Info>();
            employee = db.HR_Emp_Info.ToList();
            ViewBag.Employee = employee;

            return View();
        }


        public class JobCard
        {
            [DisplayName("From")]
            public string DtFrom { get; set; }
            [DisplayName("To")]
            public string DtTo { get; set; }
            public string EmpName { get; set; }
            public int EmpId { get; set; }
            public string SectName { get; set; }
            public int SectId { get; set; }

        }

        [HttpPost]
        public ActionResult Index(JobCard jobCard)
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

            ReportPath = "/ReportViewer/HR/rptJobCard.rdlc";
            SqlCmd = "Exec rptJobCard '" + comid + "', '" + jobCard.DtFrom + "', '" + jobCard.DtTo + "'," + jobCard.SectId + ", " + jobCard.EmpId + "";
            ConstrName = "ApplicationServices";
            ReportType = "PDF";
            //callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //repos.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);

            HttpContext.Session.SetString("ReportPath", ReportPath.ToString());
            HttpContext.Session.SetString("reportquery", SqlCmd);
            string filename = "JobCard".ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

            callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
            return Redirect(callBackUrl);
        }


    }
}