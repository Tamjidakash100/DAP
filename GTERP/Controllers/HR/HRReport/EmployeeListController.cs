using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]
    public class EmployeeListController : Controller
    {
        private readonly GTRDBContext _context;

        private TransactionLogRepository tranlog;
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        public clsProcedure clsProc { get; }
        //public CommercialRepository Repository { get; set; }

        public EmployeeListController(GTRDBContext context)
        {
            _context = context;
            // Repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            string comid = HttpContext.Session.GetString("comid");

            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@ComId", comid);
            List<EmpList> EmployeeListData = Helper.ExecProcMapTList<EmpList>("HR_prcGetEmployee", parameter);
            //ViewBag.EmpList = Employee;
            return View(EmployeeListData);
            //var gTRDBContext = await _context.HR_Emp_Salary
            //    .Include(h => h.HR_Emp_Info)
            //    .Include(h => h.HR_Emp_Info.HR_Emp_Address).ThenInclude(h=>h.Cat_DistrictCurr)
            //    .Include(h => h.HR_Emp_Info.HR_Emp_Address).ThenInclude(h => h.Cat_DistrictPer)
            //    .Include(h => h.HR_Emp_Info.Cat_BloodGroup)
            //    .Include(h => h.HR_Emp_Info.Cat_Department)
            //    .Include(h => h.HR_Emp_Info.Cat_Designation)
            //    .Include(h => h.HR_Emp_Info.Cat_Emp_Type)
            //    .Include(h => h.HR_Emp_Info.Cat_Floor)
            //    .Include(h => h.HR_Emp_Info.Cat_Gender)
            //    .Include(h => h.HR_Emp_Info.Cat_Grade)
            //    .Include(h => h.HR_Emp_Info.Cat_Line)
            //    .Include(h => h.HR_Emp_Info.Cat_Religion)
            //    .Include(h => h.HR_Emp_Info.Cat_Section)
            //    .Include(h => h.HR_Emp_Info.Cat_Shift)
            //    .Include(h => h.HR_Emp_Info.Cat_SubSection)
            //    .Include(h => h.HR_Emp_Info.Cat_Unit)
            //    .Include(h => h.HR_Emp_Info.HR_Emp_Educations)
            //    .Include(h => h.HR_Emp_Info.HR_Emp_Experiences)
            //    .Include(h => h.HR_Emp_Info.HR_Emp_Nominee)
            //    .Include(h => h.HR_Emp_Info.HR_Emp_Family)
            //    .Select(a=> new EmpList
            //    {
            //        EmpCode = a.HR_Emp_Info.EmpCode,
            //        EmpName = a.HR_Emp_Info.EmpName,
            //        EmpNameB = a.HR_Emp_Info.EmpNameB,
            //        EmpSpouse = a.HR_Emp_Info.HR_Emp_Family.EmpSpouse,
            //        EmpSpouseB = a.HR_Emp_Info.HR_Emp_Family.EmpSpouseB,
            //        EmpFather = a.HR_Emp_Info.HR_Emp_Family.EmpFather,
            //        EmpFatherB = a.HR_Emp_Info.HR_Emp_Family.EmpFatherB,
            //        EmpMother = a.HR_Emp_Info.HR_Emp_Family.EmpMother,
            //        EmpMotherB = a.HR_Emp_Info.HR_Emp_Family.EmpMotherB,
            //        HouseType = _context.Cat_BuildingType.Where(b=>b.BId==a.BId).Select(b=>b.BuildingName).FirstOrDefault(),
            //        ReligionName = a.HR_Emp_Info.Cat_Religion.ReligionName,
            //        BloodName = a.HR_Emp_Info.Cat_BloodGroup.BloodName,
            //        UnitName = a.HR_Emp_Info.Cat_Unit.UnitName,
            //        DeptName = a.HR_Emp_Info.Cat_Department.DeptName,
            //        ShiftName = a.HR_Emp_Info.Cat_Shift.ShiftName,
            //        CurrVillName = a.HR_Emp_Info.HR_Emp_Address.EmpCurrCityVill,
            //        CurrDistName = a.HR_Emp_Info.HR_Emp_Address.Cat_DistrictCurr!=null ? a.HR_Emp_Info.HR_Emp_Address.Cat_DistrictCurr.DistName:"Not Assigned",
            //        CurrPStationName = a.HR_Emp_Info.HR_Emp_Address.Cat_PoliceStationCurr!=null? a.HR_Emp_Info.HR_Emp_Address.Cat_PoliceStationCurr.PStationName: "Not Assigned",
            //        CurrPOName = a.HR_Emp_Info.HR_Emp_Address.Cat_PostOfficeCurr!=null? a.HR_Emp_Info.HR_Emp_Address.Cat_PostOfficeCurr.POName: "Not Assigned",

            //        PerVillName = a.HR_Emp_Info.HR_Emp_Address.EmpCurrCityVill,
            //        PerDistName = a.HR_Emp_Info.HR_Emp_Address.Cat_DistrictPer !=null? a.HR_Emp_Info.HR_Emp_Address.Cat_DistrictPer.DistName: "Not Assigned",
            //        PerPStationName = a.HR_Emp_Info.HR_Emp_Address.Cat_PoliceStationPer!=null ? a.HR_Emp_Info.HR_Emp_Address.Cat_PoliceStationPer.PStationName: "Not Assigned",
            //        PerPOName = a.HR_Emp_Info.HR_Emp_Address.Cat_PostOfficePer.POName,
            //        Educations = a.HR_Emp_Info.HR_Emp_Educations.ToList(),
            //        Experiences = a.HR_Emp_Info.HR_Emp_Experiences.ToList(),
            //        DesigName = a.HR_Emp_Info.Cat_Designation !=null? a.HR_Emp_Info.Cat_Designation.DesigName: "Not Assigned",
            //        SectName = a.HR_Emp_Info.Cat_Section!=null ? a.HR_Emp_Info.Cat_Section.SectName:"",
            //        SubSectName = a.HR_Emp_Info.Cat_SubSection!=null? a.HR_Emp_Info.Cat_SubSection.SubSectName: "Not Assigned",
            //        DtBirth = a.HR_Emp_Info.DtBirth,
            //        DtJoin = a.HR_Emp_Info.DtJoin,
            //        DtIncrement = a.HR_Emp_Info.DtIncrement,
            //        DtConfirm = a.HR_Emp_Info.DtConfirm,
            //        //DtPf = a.HR_Emp_Info.DtPf,
            //        EmpTypeName = a.HR_Emp_Info.Cat_Emp_Type != null ? a.HR_Emp_Info.Cat_Emp_Type.EmpTypeName: "Not Assigned",
            //        GenderName = a.HR_Emp_Info.Cat_Gender!=null? a.HR_Emp_Info.Cat_Gender.GenderName:"",
            //        NID = a.HR_Emp_Info.NID,
            //        FingerId = a.HR_Emp_Info.FingerId,
            //        EmpPhone1 = a.HR_Emp_Info.EmpPhone1,
            //        EmpPhone2 = a.HR_Emp_Info.EmpPhone2,
            //        IsInactive = a.HR_Emp_Info.IsInactive,
            //        EmpPerZip = a.HR_Emp_Info.EmpPerZip,
            //        EmpEmail = a.HR_Emp_Info.EmpEmail,
            //        EmpRemarks = a.HR_Emp_Info.EmpRemarks,
            //        GradeName = a.HR_Emp_Info.Cat_Grade!=null? a.HR_Emp_Info.Cat_Grade.GradeName: "Not Assigned",
            //        FloorName = a.HR_Emp_Info.Cat_Floor!=null? a.HR_Emp_Info.Cat_Floor.FloorName: "Not Assigned",
            //        LineName = a.HR_Emp_Info.Cat_Line!=null? a.HR_Emp_Info.Cat_Line.LineName: "Not Assigned",
            //        IsAllowOT = a.HR_Emp_Info.IsAllowOT,
            //        DtLocalJoin = a.HR_Emp_Info.DtLocalJoin,
            //        ManageType = a.HR_Emp_Info.ManageType,
            //        EmpNomineeName1 = a.HR_Emp_Info.HR_Emp_Nominee.EmpNomineeName1,
            //        EmpNomineeMobile1 = a.HR_Emp_Info.HR_Emp_Nominee.EmpNomineeMobile1,
            //        EmpNomineeNID1 = a.HR_Emp_Info.HR_Emp_Nominee.EmpNomineeNID1,
            //        EmpNomineeRelation1 = a.HR_Emp_Info.HR_Emp_Nominee.EmpNomineeRelation1,
            //        EmpNomineeAddress1 = a.HR_Emp_Info.HR_Emp_Nominee.EmpNomineeAddress1,

            //        EmpNomineeName2 = a.HR_Emp_Info.HR_Emp_Nominee.EmpNomineeName2,                    
            //        EmpNomineeMobile2 = a.HR_Emp_Info.HR_Emp_Nominee.EmpNomineeMobile2,                    
            //        EmpNomineeNID2 = a.HR_Emp_Info.HR_Emp_Nominee.EmpNomineeNID2,                    
            //        EmpNomineeRelation2 = a.HR_Emp_Info.HR_Emp_Nominee.EmpNomineeRelation2,                    
            //        EmpNomineeAddress2 = a.HR_Emp_Info.HR_Emp_Nominee.EmpNomineeAddress2,

            //    }).ToListAsync();
            //ViewBag.EmpList = gTRDBContext;
            //return View();
        }


        public ActionResult Print(int? id, string reporttype = "pdf")
        {
            string SqlCmd = "";
            string ReportPath = "";
            //var ConstrName = "ApplicationServices";
            //var ReportType = "PDF";
            var comid = HttpContext.Session.GetString("comid");

            var reportname = "rptEmployeeDetails";
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/HR/" + reportname + ".rdlc");
            HttpContext.Session.SetString("reportquery", "Exec [HR_rptEmployeeDetails] '" + comid + "','" + id + "'");

            string filename = _context.HR_Emp_Info.Where(x => x.EmpId == id).Select(x => x.EmpName).Single().ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

            string DataSourceName = "DataSet1";
            HttpContext.Session.SetObject("rptList", postData);

            clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
            clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
            clsReport.strDSNMain = DataSourceName;


            SqlCmd = clsReport.strQueryMain;
            ReportPath = clsReport.strReportPathMain;
            //ReportType = "PDF";

            //string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); // this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
            string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = reporttype });
            return Redirect(callBackUrl);

        }


        public class EmpList
        {
            public int EmpId { get; set; }

            public string EmpName { get; set; }
            public string EmpCode { get; set; }
            public string EmpNameB { get; set; }
            public string EmpFather { get; set; }
            public string EmpFatherB { get; set; }
            public string EmpMother { get; set; }
            public string EmpMotherB { get; set; }
            public string EmpSpouse { get; set; }
            public string EmpSpouseB { get; set; }

            public string HouseType { get; set; }
            public string ReligionName { get; set; }
            public string BloodName { get; set; }
            public string UnitName { get; set; }
            public string ShitfName { get; set; }
            public string DeptName { get; set; }
            public string ShiftName { get; set; }
            public string CurrVillName { get; set; }
            public string CurrDistName { get; set; }
            public string CurrPStationName { get; set; }
            public string CurrPOName { get; set; }
            public string PresentAddress { get; set; }
            public string PermanentAddress { get; set; }

            public string PerVillName { get; set; }
            public string PerDistName { get; set; }
            public string PerPStationName { get; set; }
            public string PerPOName { get; set; }
            //public List<HR_Emp_Experience> Experiences { get; set; }
            //public List<HR_Emp_Education> Educations { get; set; }

            public string Experiences { get; set; }
            public string Educations { get; set; }
            public string DesigName { get; set; }
            public string SectName { get; set; }
            public string SubSectName { get; set; }
            [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
            public DateTime? DtBirth { get; set; }
            [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
            public DateTime? DtJoin { get; set; }
            [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
            public DateTime? DtIncrement { get; set; }
            [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
            public DateTime? DtConfirm { get; set; }
            [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
            public DateTime? DtPf { get; set; }
            public string EmpTypeName { get; set; }
            public string GenderName { get; set; }
            public string NID { get; set; }
            public string FingerId { get; set; }
            public string EmpPhone1 { get; set; }
            public string EmpPhone2 { get; set; }
            public bool IsInactive { get; set; }
            public string EmpPerZip { get; set; }
            public string EmpEmail { get; set; }
            public string EmpRemarks { get; set; }
            public string GradeName { get; set; }
            public string FloorName { get; set; }
            public string LineName { get; set; }
            public bool IsAllowOT { get; set; }
            public int ManageType { get; set; }
            [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
            public DateTime? DtLocalJoin { get; set; }
            public string EmpNomineeName1 { get; set; }
            public string EmpNomineeMobile1 { get; set; }
            public string EmpNomineeNID1 { get; set; }
            public string EmpNomineeRelation1 { get; set; }
            public string EmpNomineeAddress1 { get; set; }
            public string EmpNomineeName2 { get; set; }
            public string EmpNomineeMobile2 { get; set; }
            public string EmpNomineeNID2 { get; set; }
            public string EmpNomineeRelation2 { get; set; }
            public string EmpNomineeAddress2 { get; set; }

        }

    }
}
