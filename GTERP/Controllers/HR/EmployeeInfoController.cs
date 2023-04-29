using DataTablesParser;
using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]

    public class EmployeeInfoController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;
        private readonly HrRepository _repos;

        public EmployeeInfoController(GTRDBContext context, HrRepository repository, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
            _repos = repository;
        }

        // GET: EmpInfoTemp
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            //var gTRDBContext = db.HR_Emp_Info.Include(h => h.Cat_BloodGroup).Include(h => h.Cat_Department).Include(h => h.Cat_Designation).Include(h => h.Cat_Floor).Include(h => h.Cat_Grade).Include(h => h.Cat_Line).Include(h => h.Cat_Religion).Include(h => h.Cat_Section).Include(h => h.Cat_Shift).Include(h => h.Cat_SubSection).Include(h => h.Cat_Unit);
            return View(await _repos.GetEmpAsync());
        }

        public class EmployeeInfo
        {
            public int EmpId { get; set; }
            public string EmpCode { get; set; }
            public string EmpName { get; set; }
            public string EmpNameB { get; set; }
            public string DesigName { get; set; }
            public string DeptName { get; set; }
            public string SectName { get; set; }
            public string EmpType { get; set; }
            public DateTime? DtJoin { get; set; }
            public string Email { get; set; }

        }

        [HttpPost]
        public IActionResult Get()
        {
            try
            {
                var comid = (HttpContext.Session.GetString("comid"));

                Microsoft.Extensions.Primitives.StringValues y = "";

                var x = Request.Form.TryGetValue("search[value]", out y);

                //if (y.ToString().Length > 0)
                //{

                var query = from e in db.HR_Emp_Info
                                //.Where(x => x.ComId == comid && x.IsInactive == false && x.IsCasual == false).OrderByDescending(x => x.EmpId)
                            select new EmployeeInfo
                            {
                                EmpId = e.EmpId,
                                EmpCode = e.EmpCode,
                                EmpName = e.EmpName,
                                EmpNameB = e.EmpNameB,
                                DesigName = e.Cat_Designation != null ? e.Cat_Designation.DesigName : "",
                                DeptName = e.Cat_Department != null ? e.Cat_Department.DeptName : "",
                                SectName = e.Cat_Section != null ? e.Cat_Section.SectName : "",
                                EmpType = e.Cat_Emp_Type != null ? e.Cat_Emp_Type.EmpTypeName : "",
                                DtJoin = e.DtJoin,
                                Email = e.EmpEmail

                            };


                var parser = new Parser<EmployeeInfo>(Request.Form, query);

                return Json(parser.Parse());

                //}
                //return Json("");

            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }





        public IActionResult EmpCodeExist(string code)
        {
            return Json(db.HR_Emp_Info.Any(e => e.EmpCode == code));
        }

        public async Task<IActionResult> EmployeeList()
        {
            //var gTRDBContext = db.HR_Emp_Info.Include(h => h.Cat_BloodGroup).Include(h => h.Cat_Department).Include(h => h.Cat_Designation).Include(h => h.Cat_Floor).Include(h => h.Cat_Grade).Include(h => h.Cat_Line).Include(h => h.Cat_Religion).Include(h => h.Cat_Section).Include(h => h.Cat_Shift).Include(h => h.Cat_SubSection).Include(h => h.Cat_Unit);
            return View(await _repos.GetEmpAsync());
        }



        // GET: EmpInfoTemp/Create
        public IActionResult Create()
        {
            string comid = HttpContext.Session.GetString("comid");
            ViewBag.Title = "Create";
            ViewData["BloodId"] = new SelectList(db.Cat_BloodGroup, "BloodId", "BloodName");
            ViewData["DeptId"] = new SelectList(db.Cat_Department, "DeptId", "DeptName");
            ViewData["DesigId"] = new SelectList(db.Cat_Designation, "DesigId", "DesigName");
            ViewData["EmpCurrDistId"] = new SelectList(db.Cat_District, "DistId", "DistName");
            ViewData["EmpPerDistId"] = new SelectList(db.Cat_District, "DistId", "DistName");

            ViewData["EmpCurrPSId"] = new SelectList(db.Cat_PoliceStation, "PStationId", "PStationName");
            ViewData["EmpPerPSId"] = new SelectList(db.Cat_PoliceStation, "PStationId", "PStationName");

            ViewData["EmpCurrPOId"] = new SelectList(db.Cat_PostOffice, "POId", "POName");
            ViewData["EmpPerPOId"] = new SelectList(db.Cat_PostOffice, "POId", "POName");

            ViewData["BId"] = new SelectList(db.Cat_BuildingType, "BId", "BuildingName");
            ViewData["GenderId"] = new SelectList(db.Cat_Gender, "GenderId", "GenderName");

            ViewData["EmpTypeId"] = new SelectList(db.Cat_Emp_Type, "EmpTypeId", "EmpTypeName");

            ViewData["PayModeId"] = new SelectList(db.Cat_PayMode, "PayModeId", "PayModeName");
            ViewData["BankId"] = new SelectList(db.Cat_Bank, "BankId", "BankName");
            ViewData["BranchId"] = new SelectList(db.Cat_BankBranch, "BranchId", "BranchName");
            ViewData["AccTypeId"] = new SelectList(db.Cat_AccountType, "AccTypeId", "AccTypeName");

            ViewData["FloorId"] = new SelectList(db.Cat_Floor, "FloorId", "FloorName");
            ViewData["GradeId"] = new SelectList(db.Cat_Grade, "GradeId", "GradeName");
            ViewData["LineId"] = new SelectList(db.Cat_Line, "LineId", "LineName");
            ViewData["RelgionId"] = new SelectList(db.Cat_Religion, "RelgionId", "ReligionName");
            ViewData["SectId"] = new SelectList(db.Cat_Section, "SectId", "SectName");
            ViewData["ShiftId"] = new SelectList(db.Cat_Shift, "ShiftId", "ShiftName");
            ViewData["SubSectId"] = new SelectList(db.Cat_SubSection, "SubSectId", "SubSectName");
            ViewData["UnitId"] = new SelectList(db.Cat_Unit, "UnitId", "UnitName");

            var year = db.Acc_FiscalYears.Where(f => f.comid == comid).Select(y => new { FiscalYearId = y.FiscalYearId, FYName = y.FYName });

            ViewData["PFFinalYId"] = new SelectList(year, "FiscalYearId", "FYName");
            ViewData["PFFundTransferYId"] = new SelectList(year, "FiscalYearId", "FYName");
            ViewData["WFFinalYId"] = new SelectList(year, "FiscalYearId", "FYName");
            ViewData["WFFundTransferYId"] = new SelectList(year, "FiscalYearId", "FYName");
            ViewData["GratuityFinalYId"] = new SelectList(year, "FiscalYearId", "FYName");
            ViewData["GratuityFundTransferYId"] = new SelectList(year, "FiscalYearId", "FYName");

            ViewData["SkillId"] = new SelectList(db.Cat_Skill, "SkillId", "SkillName");
            return View();
        }





        public Image _currentBitmap;
        string _FileName = "";
        string _path = "";
        string fileName = null;
        string Extension = null;

        // POST: EmpInfoTemp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[Bind("ComId,EmpId,EmpCode,EmpName,EmpFather,EmpMother,EmpSpouse,EmpCurrAdd,EmpCurrVill,EmpCurrPo,EmpCurrPs,EmpCurrDistId,EmpPerAdd,EmpPerVill,EmpPerPo,EmpPerPs,EmpPerCity,EmpPerDistId,EmpPerZip,EmpPhone,EmpMobile,EmpEmail,EmpPicLocation,EmpRemarks,Sex,RelgionId,Caste,BloodId,MaritalSts,DtBirth,DtJoin,DtReleased,DtIncrement,IsConfirm,DtConfirm,ConfDay,DeptId,SectId,SubSectId,DesigId,GradeId,FloorId,LineId,EmpCategory,WorkPlace,ShiftId,Nationality,PassportNo,VoterNo,BirthCertNo,IsAllowPf,DtPf,IsAllowOt,PaySource,PayMode,EmpType,EmpSts,CardNo,BankId,BankAcNo,Fpid,WeekDayId,OldEmpId,Approved,NickName,DtApprove,ChildNo,EmpCurrDist,EmpPerDist,EduLvl,EmpRef,EmpRefMob,IsTax,IsAcc,EmpCurrZip,EmpCurrCity,DtTransport,IsDisabled,EmpNomineeName,EmpNomineeMob,EmergencyName,EmergencyMob,EmployementType,EmpCatagory,Title,DtCardAssign,IsContract,WorkType,DtMarrige,CardNoOld,IsNid,ChildM,ChildF,EmpPflocation,EmpMclocation,EmpHblocation,EmpWflocation,IsInactive,PcName,UserId,DateAdded,UpdateByUserId,DateUpdated")]
        public async Task<IActionResult> Create(HR_Emp_Info hrEmpInfo, IFormFile file)
        {
            //var errors = ModelState.Where(x => x.Value.Errors.Any())
            //   .Select(x => new { x.Key, x.Value.Errors });
            string comid = HttpContext.Session.GetString("comid");
            if (ModelState.IsValid)
            {
                hrEmpInfo.UserId = HttpContext.Session.GetString("userid");
                hrEmpInfo.ComId = HttpContext.Session.GetString("comid");
                if (hrEmpInfo.EmpId > 0)
                {
                    hrEmpInfo.UpdateByUserId = HttpContext.Session.GetString("userid");
                    hrEmpInfo.DateUpdated = DateTime.Now;
                    db.Entry(hrEmpInfo).State = EntityState.Modified;

                    if (hrEmpInfo.HR_Emp_PersonalInfo.EmpPersInfoId > 0)
                        db.Entry(hrEmpInfo.HR_Emp_PersonalInfo).State = EntityState.Modified;
                    else
                        db.Add(hrEmpInfo.HR_Emp_PersonalInfo);

                    if (hrEmpInfo.HR_Emp_Address.EmpAddId > 0)
                        db.Entry(hrEmpInfo.HR_Emp_Address).State = EntityState.Modified;
                    else
                        db.Add(hrEmpInfo.HR_Emp_Address);

                    if (hrEmpInfo.HR_Emp_Family.EmpFamilyId > 0)
                        db.Entry(hrEmpInfo.HR_Emp_Family).State = EntityState.Modified;
                    else
                        db.Add(hrEmpInfo.HR_Emp_Family);

                    if (hrEmpInfo.HR_Emp_Nominee.EmpNomId > 0)
                        db.Entry(hrEmpInfo.HR_Emp_Nominee).State = EntityState.Modified;
                    else
                        db.Add(hrEmpInfo.HR_Emp_Nominee);

                    if (hrEmpInfo.HR_Emp_BankInfo.BankInfoId > 0)
                        db.Entry(hrEmpInfo.HR_Emp_BankInfo).State = EntityState.Modified;
                    else
                        db.Add(hrEmpInfo.HR_Emp_BankInfo);

                    if (hrEmpInfo.HR_Emp_Image.EmpImageId > 0 && file != null)
                    {
                        hrEmpInfo.HR_Emp_Image.EmpImage = SetImage(file);
                        db.Entry(hrEmpInfo.HR_Emp_Image).State = EntityState.Modified;
                    }
                    else if (file != null)
                    {
                        hrEmpInfo.HR_Emp_Image.EmpImage = SetImage(file);
                        db.Add(hrEmpInfo.HR_Emp_Image);
                    }

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), hrEmpInfo.EmpId.ToString(), "Update", hrEmpInfo.EmpName.ToString());

                }
                else
                {
                    hrEmpInfo.DateAdded = DateTime.Now;
                    db.Add(hrEmpInfo);

                    if (file != null)
                    {
                        hrEmpInfo.HR_Emp_Image.EmpImage = SetImage(file);
                        db.Add(hrEmpInfo.HR_Emp_Image);
                    }


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), hrEmpInfo.EmpId.ToString(), "Create", hrEmpInfo.EmpName.ToString());

                }
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BloodId"] = new SelectList(db.Cat_BloodGroup, "BloodId", "BloodName", hrEmpInfo.BloodId);
            ViewData["DeptId"] = new SelectList(db.Cat_Department, "DeptId", "DeptName", hrEmpInfo.DeptId);
            ViewData["DesigId"] = new SelectList(db.Cat_Designation, "DesigId", "DesigName", hrEmpInfo.DesigId);

            ViewData["EmpCurrDistId"] = new SelectList(db.Cat_District, "DistId", "DistName", hrEmpInfo.HR_Emp_Address.Cat_DistrictCurr.DistId);
            ViewData["EmpPerDistId"] = new SelectList(db.Cat_District, "DistId", "DistName", hrEmpInfo.HR_Emp_Address.Cat_DistrictPer.DistId);

            ViewData["EmpCurrPSId"] = new SelectList(db.Cat_PoliceStation, "PStationId", "PStationName", hrEmpInfo.HR_Emp_Address.Cat_PoliceStationCurr.PStationId);
            ViewData["EmpPerPSId"] = new SelectList(db.Cat_PoliceStation, "PStationId", "PStationName", hrEmpInfo.HR_Emp_Address.Cat_PoliceStationPer.PStationId);

            ViewData["EmpCurrPOId"] = new SelectList(db.Cat_PostOffice, "POId", "POName", hrEmpInfo.HR_Emp_Address.Cat_PostOfficeCurr.POId);
            ViewData["EmpPerPOId"] = new SelectList(db.Cat_PostOffice, "POId", "POName", hrEmpInfo.HR_Emp_Address.Cat_PostOfficePer.POId);

            ViewData["BId"] = new SelectList(db.Cat_BuildingType, "BId", "BuildingName", hrEmpInfo.HR_Emp_PersonalInfo.BId);
            ViewData["GenderId"] = new SelectList(db.Cat_Gender, "GenderId", "GenderName", hrEmpInfo.GenderId);

            ViewData["EmpTypeId"] = new SelectList(db.Cat_Emp_Type, "EmpTypeId", "EmpTypeName", hrEmpInfo.EmpTypeId);

            ViewData["PayModeId"] = new SelectList(db.Cat_PayMode, "PayModeId", "PayModeName", hrEmpInfo.HR_Emp_BankInfo.PayModeId);
            ViewData["BankId"] = new SelectList(db.Cat_Bank, "BankId", "BankName", hrEmpInfo.HR_Emp_BankInfo.BankId);
            ViewData["BranchId"] = new SelectList(db.Cat_BankBranch, "BranchId", "BranchName", hrEmpInfo.HR_Emp_BankInfo.BranchId);
            ViewData["AccTypeId"] = new SelectList(db.Cat_AccountType, "AccTypeId", "AccTypeName", hrEmpInfo.HR_Emp_BankInfo.AccTypeId);


            ViewData["FloorId"] = new SelectList(db.Cat_Floor, "FloorId", "FloorName", hrEmpInfo.FloorId);
            ViewData["GradeId"] = new SelectList(db.Cat_Grade, "GradeId", "GradeName", hrEmpInfo.GradeId);
            ViewData["LineId"] = new SelectList(db.Cat_Line, "LineId", "LineName", hrEmpInfo.LineId);
            ViewData["RelgionId"] = new SelectList(db.Cat_Religion, "RelgionId", "ReligionName", hrEmpInfo.RelgionId);
            ViewData["SectId"] = new SelectList(db.Cat_Section, "SectId", "SectName", hrEmpInfo.SectId);
            ViewData["ShiftId"] = new SelectList(db.Cat_Shift, "ShiftId", "ShiftName", hrEmpInfo.ShiftId);
            ViewData["SubSectId"] = new SelectList(db.Cat_SubSection, "SubSectId", "SubSectName", hrEmpInfo.SubSectId);
            ViewData["UnitId"] = new SelectList(db.Cat_Unit, "UnitId", "UnitName", hrEmpInfo.UnitId);
            ViewData["SkillId"] = new SelectList(db.Cat_Skill, "SkillId", "SkillName", hrEmpInfo.SkillId);


            var year = db.Acc_FiscalYears.Where(f => f.comid == comid).Select(y => new { FiscalYearId = y.FiscalYearId, FYName = y.FYName });

            ViewData["PFFinalYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.PFFinalYId);
            ViewData["PFFundTransferYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.PFFundTransferYId);
            ViewData["WFFinalYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.WFFinalYId);
            ViewData["WFFundTransferYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.WFFundTransferYId);
            ViewData["GratuityFinalYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.GratuityFinalYId);
            ViewData["GratuityFundTransferYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.GratuityFundTransferYId);


            return View(hrEmpInfo);
        }


        [HttpGet]
        public ActionResult GetPoliceStation(int id)
        {
            string comid = HttpContext.Session.GetString("comid");

            var policeStation = db.Cat_PoliceStation
                .Select(p => new
                {
                    DistId = p.DistId,
                    Id = p.PStationId,
                    Name = p.PStationName,
                    ComId = p.ComId
                })
                .Where(p => p.DistId == id).ToList();
            //.Where(p => p.DistId == id && p.ComId == comid).ToList();

            //var postOffice = db.Cat_PostOffice
            //   .Select(p=> new {
            //       DistId=p.DistId,
            //       Id=p.POId,
            //       Name=p.POName,
            //       ComId=p.ComId
            //   })
            //   .Where(p => p.DistId == id).ToList();
            //   //.Where(p => p.DistId == id && p.ComId == comid).ToList();

            return Json(new { PoliceStation = policeStation });
        }

        [HttpGet]
        public ActionResult GetPostOffice(int id)
        {
            string comid = HttpContext.Session.GetString("comid");
            var postOffice = db.Cat_PostOffice
               .Select(p => new
               {
                   PStationId = p.PStationId,
                   Id = p.POId,
                   Name = p.POName,
                   ComId = p.ComId
               })
               .Where(p => p.PStationId == id).ToList();
            //.Where(p => p.DistId == id && p.ComId == comid).ToList();
            return Json(postOffice);
        }


        // for image 
        private byte[] SetImage(IFormFile file)
        {
            byte[] image = null;
            using (var fs = file.OpenReadStream())
            using (var ms = new MemoryStream())
            {
                fs.CopyTo(ms);
                image = ms.ToArray();
            }
            return image;
        }

        // GET: EmpInfoTemp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string comid = HttpContext.Session.GetString("comid");
            var hrEmpInfo = await db.HR_Emp_Info
                .Include(h => h.HR_Emp_PersonalInfo)
                .Include(h => h.Cat_Skill)
                .Include(h => h.HR_Emp_Address)
                .Include(h => h.Cat_Department)
                .Include(h => h.Cat_Designation)
                .Include(h => h.HR_Emp_Address.Cat_DistrictCurr)
                .Include(h => h.HR_Emp_Address.Cat_DistrictPer)
                .Include(h => h.HR_Emp_Address.Cat_PoliceStationCurr)
                .Include(h => h.HR_Emp_Address.Cat_PoliceStationPer)
                .Include(h => h.HR_Emp_Address.Cat_PostOfficeCurr)
                .Include(h => h.HR_Emp_Address.Cat_PostOfficePer)
                .Include(h => h.HR_Emp_Educations)
                .Include(h => h.HR_Emp_Family)
                .Include(h => h.HR_Emp_Experiences)
                .Include(h => h.HR_Emp_Image)
                .Include(h => h.HR_Emp_Nominee)
                .Include(h => h.HR_Emp_BankInfo)
                .Include(h => h.HR_Emp_BankInfo.Cat_PayMode)
                .Include(h => h.HR_Emp_BankInfo.Cat_Bank)
                .Include(h => h.HR_Emp_BankInfo.Cat_BankBranch)
                .Include(h => h.HR_Emp_BankInfo.Cat_AccountType).Where(e => e.EmpId == id).FirstOrDefaultAsync();//.FindAsync(id);

            if (hrEmpInfo == null)
            {
                return NotFound();
            }

            //ViewBag.DtJoin = DateTime.Parse(hrEmpInfo.DtJoin).ToString("dd-MMM-yy");
            ViewBag.Title = "Edit";
            ViewData["BloodId"] = new SelectList(db.Cat_BloodGroup, "BloodId", "BloodName", hrEmpInfo.BloodId);
            ViewData["DeptId"] = new SelectList(db.Cat_Department, "DeptId", "DeptName", hrEmpInfo.DeptId);
            ViewData["DesigId"] = new SelectList(db.Cat_Designation, "DesigId", "DesigName", hrEmpInfo.DesigId);

            var year = db.Acc_FiscalYears.Where(f => f.comid == comid).Select(y => new { FiscalYearId = y.FiscalYearId, FYName = y.FYName });

            ViewData["PFFinalYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.PFFinalYId);
            ViewData["PFFundTransferYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.PFFundTransferYId);
            ViewData["WFFinalYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.WFFinalYId);
            ViewData["WFFundTransferYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.WFFundTransferYId);
            ViewData["GratuityFinalYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.GratuityFinalYId);
            ViewData["GratuityFundTransferYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.GratuityFundTransferYId);



            if (hrEmpInfo.HR_Emp_Address != null)
            {
                ViewData["EmpCurrDistId"] = new SelectList(db.Cat_District, "DistId", "DistName", hrEmpInfo.HR_Emp_Address.EmpCurrDistId);
                ViewData["EmpPerDistId"] = new SelectList(db.Cat_District, "DistId", "DistName", hrEmpInfo.HR_Emp_Address.EmpPerDistId);

                ViewData["EmpCurrPSId"] = new SelectList(db.Cat_PoliceStation
                    .Where(p => p.DistId == hrEmpInfo.HR_Emp_Address.EmpCurrDistId), "PStationId", "PStationName", hrEmpInfo.HR_Emp_Address.EmpCurrPSId);
                ViewData["EmpPerPSId"] = new SelectList(db.Cat_PoliceStation
                    .Where(p => p.DistId == hrEmpInfo.HR_Emp_Address.EmpPerDistId), "PStationId", "PStationName", hrEmpInfo.HR_Emp_Address.EmpPerPSId);


                ViewData["EmpCurrPOId"] = new SelectList(db.Cat_PostOffice
                    .Where(p => p.PStationId == hrEmpInfo.HR_Emp_Address.EmpCurrPSId), "POId", "POName", hrEmpInfo.HR_Emp_Address.EmpCurrPOId);
                ViewData["EmpPerPOId"] = new SelectList(db.Cat_PostOffice
                    .Where(p => p.PStationId == hrEmpInfo.HR_Emp_Address.EmpPerPSId), "POId", "POName", hrEmpInfo.HR_Emp_Address.EmpPerPOId);
            }
            else
            {
                ViewData["EmpCurrDistId"] = new SelectList(db.Cat_District, "DistId", "DistName");
                ViewData["EmpPerDistId"] = new SelectList(db.Cat_District, "DistId", "DistName");

                ViewData["EmpCurrPSId"] = new SelectList(db.Cat_PoliceStation, "PStationId", "PStationName");
                ViewData["EmpPerPSId"] = new SelectList(db.Cat_PoliceStation, "PStationId", "PStationName");


                ViewData["EmpCurrPOId"] = new SelectList(db.Cat_PostOffice, "POId", "POName");
                ViewData["EmpPerPOId"] = new SelectList(db.Cat_PostOffice, "POId", "POName");
            }
            if (hrEmpInfo.HR_Emp_PersonalInfo != null)
            {
                ViewData["BId"] = new SelectList(db.Cat_BuildingType, "BId", "BuildingName", hrEmpInfo.HR_Emp_PersonalInfo.BId);
            }
            else
            {
                ViewData["BId"] = new SelectList(db.Cat_BuildingType, "BId", "BuildingName");
            }

            ViewData["GenderId"] = new SelectList(db.Cat_Gender, "GenderId", "GenderName", hrEmpInfo.GenderId);

            ViewData["EmpTypeId"] = new SelectList(db.Cat_Emp_Type, "EmpTypeId", "EmpTypeName", hrEmpInfo.EmpTypeId);


            if (hrEmpInfo.HR_Emp_BankInfo != null)
            {
                ViewData["PayModeId"] = new SelectList(db.Cat_PayMode, "PayModeId", "PayModeName", hrEmpInfo.HR_Emp_BankInfo.PayModeId);
                ViewData["BankId"] = new SelectList(db.Cat_Bank, "BankId", "BankName", hrEmpInfo.HR_Emp_BankInfo.BankId);
                ViewData["BranchId"] = new SelectList(db.Cat_BankBranch, "BranchId", "BranchName", hrEmpInfo.HR_Emp_BankInfo.BranchId);
                ViewData["AccTypeId"] = new SelectList(db.Cat_AccountType, "AccTypeId", "AccTypeName", hrEmpInfo.HR_Emp_BankInfo.AccTypeId);
            }
            else
            {
                ViewData["PayModeId"] = new SelectList(db.Cat_PayMode, "PayModeId", "PayModeName");
                ViewData["BankId"] = new SelectList(db.Cat_Bank, "BankId", "BankName");
                ViewData["BranchId"] = new SelectList(db.Cat_BankBranch, "BranchId", "BranchName");
                ViewData["AccTypeId"] = new SelectList(db.Cat_AccountType, "AccTypeId", "AccTypeName");
            }

            HttpContext.Session.SetInt32("empid", (int)id);

            ViewData["FloorId"] = new SelectList(db.Cat_Floor, "FloorId", "FloorName", hrEmpInfo.FloorId);
            ViewData["GradeId"] = new SelectList(db.Cat_Grade, "GradeId", "GradeName", hrEmpInfo.GradeId);
            ViewData["LineId"] = new SelectList(db.Cat_Line, "LineId", "LineName", hrEmpInfo.LineId);
            ViewData["RelgionId"] = new SelectList(db.Cat_Religion, "RelgionId", "ReligionName", hrEmpInfo.RelgionId);
            ViewData["SectId"] = new SelectList(db.Cat_Section, "SectId", "SectName", hrEmpInfo.SectId);
            ViewData["ShiftId"] = new SelectList(db.Cat_Shift, "ShiftId", "ShiftName", hrEmpInfo.ShiftId);
            ViewData["SubSectId"] = new SelectList(db.Cat_SubSection, "SubSectId", "SubSectName", hrEmpInfo.SubSectId);
            ViewData["UnitId"] = new SelectList(db.Cat_Unit, "UnitId", "UnitName", hrEmpInfo.UnitId);

            ViewData["SkillId"] = new SelectList(db.Cat_Skill, "SkillId", "SkillName", hrEmpInfo.SkillId);
            return View("Create", hrEmpInfo);
        }


        // GET: EmpInfoTemp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string comid = HttpContext.Session.GetString("comid");
            var hrEmpInfo = await db.HR_Emp_Info
                .Include(h => h.HR_Emp_PersonalInfo)
                .Include(h => h.Cat_Skill)
                .Include(h => h.HR_Emp_Address)
                .Include(h => h.Cat_Department)
                .Include(h => h.Cat_Designation)
                .Include(h => h.HR_Emp_Address.Cat_DistrictCurr)
                .Include(h => h.HR_Emp_Address.Cat_DistrictPer)
                .Include(h => h.HR_Emp_Address.Cat_PoliceStationCurr)
                .Include(h => h.HR_Emp_Address.Cat_PoliceStationPer)
                .Include(h => h.HR_Emp_Address.Cat_PostOfficeCurr)
                .Include(h => h.HR_Emp_Address.Cat_PostOfficePer)
                .Include(h => h.HR_Emp_Educations)
                .Include(h => h.HR_Emp_Family)
                .Include(h => h.HR_Emp_Experiences)
                .Include(h => h.HR_Emp_Image)
                .Include(h => h.HR_Emp_Nominee)
                .Include(h => h.HR_Emp_BankInfo)
                .Include(h => h.HR_Emp_BankInfo.Cat_PayMode)
                .Include(h => h.HR_Emp_BankInfo.Cat_Bank)
                .Include(h => h.HR_Emp_BankInfo.Cat_BankBranch)
                .Include(h => h.HR_Emp_BankInfo.Cat_AccountType).Where(e => e.EmpId == id).FirstOrDefaultAsync();

            if (hrEmpInfo == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";

            var year = db.Acc_FiscalYears.Where(f => f.comid == comid).Select(y => new { FiscalYearId = y.FiscalYearId, FYName = y.FYName });

            ViewData["PFFinalYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.PFFinalYId);
            ViewData["PFFundTransferYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.PFFundTransferYId);
            ViewData["WFFinalYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.WFFinalYId);
            ViewData["WFFundTransferYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.WFFundTransferYId);
            ViewData["GratuityFinalYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.GratuityFinalYId);
            ViewData["GratuityFundTransferYId"] = new SelectList(year, "FiscalYearId", "FYName", hrEmpInfo.HR_Emp_PersonalInfo.GratuityFundTransferYId);


            ViewData["BloodId"] = new SelectList(db.Cat_BloodGroup, "BloodId", "BloodName", hrEmpInfo.BloodId);
            ViewData["DeptId"] = new SelectList(db.Cat_Department, "DeptId", "DeptName", hrEmpInfo.DeptId);
            ViewData["DesigId"] = new SelectList(db.Cat_Designation, "DesigId", "DesigName", hrEmpInfo.DesigId);
            if (hrEmpInfo.HR_Emp_Address != null)
            {
                ViewData["EmpCurrDistId"] = new SelectList(db.Cat_District, "DistId", "DistName", hrEmpInfo.HR_Emp_Address.EmpCurrDistId);
                ViewData["EmpPerDistId"] = new SelectList(db.Cat_District, "DistId", "DistName", hrEmpInfo.HR_Emp_Address.EmpPerDistId);

                ViewData["EmpCurrPSId"] = new SelectList(db.Cat_PoliceStation
                   .Where(p => p.DistId == hrEmpInfo.HR_Emp_Address.EmpCurrDistId), "PStationId", "PStationName", hrEmpInfo.HR_Emp_Address.EmpCurrPSId);
                ViewData["EmpPerPSId"] = new SelectList(db.Cat_PoliceStation
                    .Where(p => p.DistId == hrEmpInfo.HR_Emp_Address.EmpPerDistId), "PStationId", "PStationName", hrEmpInfo.HR_Emp_Address.EmpPerPSId);


                ViewData["EmpCurrPOId"] = new SelectList(db.Cat_PostOffice
                    .Where(p => p.PStationId == hrEmpInfo.HR_Emp_Address.EmpCurrPSId), "POId", "POName", hrEmpInfo.HR_Emp_Address.EmpCurrPOId);
                ViewData["EmpPerPOId"] = new SelectList(db.Cat_PostOffice
                    .Where(p => p.PStationId == hrEmpInfo.HR_Emp_Address.EmpPerPSId), "POId", "POName", hrEmpInfo.HR_Emp_Address.EmpPerPOId);
            }
            else
            {
                ViewData["EmpCurrDistId"] = new SelectList(db.Cat_District, "DistId", "DistName");
                ViewData["EmpPerDistId"] = new SelectList(db.Cat_District, "DistId", "DistName");

                ViewData["EmpCurrPSId"] = new SelectList(db.Cat_PoliceStation, "PStationId", "PStationName");
                ViewData["EmpPerPSId"] = new SelectList(db.Cat_PoliceStation, "PStationId", "PStationName");


                ViewData["EmpCurrPOId"] = new SelectList(db.Cat_PostOffice, "POId", "POName");
                ViewData["EmpPerPOId"] = new SelectList(db.Cat_PostOffice, "POId", "POName");
            }
            if (hrEmpInfo.HR_Emp_PersonalInfo != null)
            {
                ViewData["BId"] = new SelectList(db.Cat_BuildingType, "BId", "BuildingName", hrEmpInfo.HR_Emp_PersonalInfo.BId);
            }
            else
            {
                ViewData["BId"] = new SelectList(db.Cat_BuildingType, "BId", "BuildingName");
            }

            ViewData["GenderId"] = new SelectList(db.Cat_Gender, "GenderId", "GenderName", hrEmpInfo.GenderId);

            ViewData["EmpTypeId"] = new SelectList(db.Cat_Emp_Type, "EmpTypeId", "EmpTypeName", hrEmpInfo.EmpTypeId);


            if (hrEmpInfo.HR_Emp_BankInfo != null)
            {
                ViewData["PayModeId"] = new SelectList(db.Cat_PayMode, "PayModeId", "PayModeName", hrEmpInfo.HR_Emp_BankInfo.PayModeId);
                ViewData["BankId"] = new SelectList(db.Cat_Bank, "BankId", "BankName", hrEmpInfo.HR_Emp_BankInfo.BankId);
                ViewData["BranchId"] = new SelectList(db.Cat_BankBranch, "BranchId", "BranchName", hrEmpInfo.HR_Emp_BankInfo.BranchId);
                ViewData["AccTypeId"] = new SelectList(db.Cat_AccountType, "AccTypeId", "AccTypeName", hrEmpInfo.HR_Emp_BankInfo.AccTypeId);
            }
            else
            {
                ViewData["PayModeId"] = new SelectList(db.Cat_PayMode, "PayModeId", "PayModeName");
                ViewData["BankId"] = new SelectList(db.Cat_Bank, "BankId", "BankName");
                ViewData["BranchId"] = new SelectList(db.Cat_BankBranch, "BranchId", "BranchName");
                ViewData["AccTypeId"] = new SelectList(db.Cat_AccountType, "AccTypeId", "AccTypeName");
            }

            HttpContext.Session.SetInt32("empid", (int)id);

            ViewData["FloorId"] = new SelectList(db.Cat_Floor, "FloorId", "FloorName", hrEmpInfo.FloorId);
            ViewData["GradeId"] = new SelectList(db.Cat_Grade, "GradeId", "GradeName", hrEmpInfo.GradeId);
            ViewData["LineId"] = new SelectList(db.Cat_Line, "LineId", "LineName", hrEmpInfo.LineId);
            ViewData["RelgionId"] = new SelectList(db.Cat_Religion, "RelgionId", "ReligionName", hrEmpInfo.RelgionId);
            ViewData["SectId"] = new SelectList(db.Cat_Section, "SectId", "SectName", hrEmpInfo.SectId);
            ViewData["ShiftId"] = new SelectList(db.Cat_Shift, "ShiftId", "ShiftName", hrEmpInfo.ShiftId);
            ViewData["SubSectId"] = new SelectList(db.Cat_SubSection, "SubSectId", "SubSectName", hrEmpInfo.SubSectId);
            ViewData["UnitId"] = new SelectList(db.Cat_Unit, "UnitId", "UnitName", hrEmpInfo.UnitId);
            ViewData["SkillId"] = new SelectList(db.Cat_Skill, "SkillId", "SkillName", hrEmpInfo.SkillId);
            return View("Create", hrEmpInfo);
        }

        // POST: EmpInfoTemp/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                var hrEmpInfo = await db.HR_Emp_Info.FindAsync(id);
                db.HR_Emp_Info.Remove(hrEmpInfo);
                await db.SaveChangesAsync();


                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), hrEmpInfo.EmpId.ToString(), "Delete", hrEmpInfo.EmpName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, EmpId = hrEmpInfo.EmpId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool HrEmpInfoExists(int id)
        {
            return db.HR_Emp_Info.Any(e => e.EmpId == id);
        }

        [HttpPost]
        //[IgnoreAntiforgeryToken]
        public ActionResult EmpEducation(string HR_Emp_Educations)
        {
            try
            {
                var JObject = new JObject();
                var data = JObject.Parse(HR_Emp_Educations);
                string objct = data["HR_Emp_Educations"].ToString();
                var emp_Educations = JsonConvert.DeserializeObject<List<HR_Emp_Education>>(objct);

                if (emp_Educations.Count < 1)
                {
                    var odlData = db.HR_Emp_Education.Where(e => e.EmpId == HttpContext.Session.GetInt32("empid")).ToList();
                    db.RemoveRange(odlData);
                }
                else
                {
                    var odlData = db.HR_Emp_Education.Where(e => e.EmpId == emp_Educations.FirstOrDefault().EmpId).ToList();
                    db.RemoveRange(odlData);
                    db.AddRange(emp_Educations);
                }

                db.SaveChanges();

                TempData["Message"] = "Education create/update Successfully";
                return Json(new { Success = 1, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        [HttpPost]
        public ActionResult EmpExperience(string HR_Emp_Experiences)
        {
            try
            {
                var JObject = new JObject();
                var data = JObject.Parse(HR_Emp_Experiences);
                string objct = data["HR_Emp_Experiences"].ToString();
                var emp_Experiences = JsonConvert.DeserializeObject<List<HR_Emp_Experience>>(objct);

                if (emp_Experiences.Count < 1)
                {
                    var odlData = db.HR_Emp_Experience.Where(e => e.EmpId == HttpContext.Session.GetInt32("empid")).ToList();
                    db.RemoveRange(odlData);
                }
                else
                {
                    var odlData = db.HR_Emp_Experience.Where(e => e.EmpId == emp_Experiences.FirstOrDefault().EmpId).ToList();
                    db.RemoveRange(odlData);
                    db.AddRange(emp_Experiences);
                }

                db.SaveChanges();

                TempData["Message"] = "Experience create/update Successfully";
                return Json(new { Success = 1, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }
    }
}