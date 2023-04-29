using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]
    public class EmployeeArrearBillController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext _context;

        public EmployeeArrearBillController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            _context = context;
        }

        // GET: hR_Emp_ArrearBill
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");


            var gTRDBContext = _context.HR_Emp_ArrearBill
                .Include(h => h.HR_Emp_Info);

            return View(gTRDBContext);
        }

        public class SalaryInfo
        {
            public int SalaryId { get; set; }
            public string EmpCode { get; set; }
            public string EmpName { get; set; }
            public string DesigName { get; set; }
            public float BasicSalary { get; set; }
            public float? HouseRent { get; set; }
            public float? HRExp { get; set; }
            public string EmpTypeName { get; set; }
            public string LocationName { get; set; }
            public string BuildingName { get; set; }
        }

        //[HttpPost]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        var comid = (HttpContext.Session.GetString("comid"));

        //        Microsoft.Extensions.Primitives.StringValues y = "";

        //        var x = Request.Form.TryGetValue("search[value]", out y);

        //        //if (y.ToString().Length > 0)
        //        //{

        //        var query = from e in _context.hR_Emp_ArrearBill
        //                //.Include(h => h.Cat_BuildingTypeHC).Include(h => h.Cat_Location1)
        //                //.Include(h => h.Cat_LocationHB).Include(h => h.HR_Emp_Info.Cat_Designation)
        //                //.Include(h => h.HR_Emp_Info).Include(h => h.HR_Emp_Info.Cat_Emp_Type)
        //                .Where(x => x.ComId == comid && x.HR_Emp_Info.IsInactive == false && x.HR_Emp_Info.IsCasual == false).OrderByDescending(x => x.SalaryId)
        //                        select new SalaryInfo
        //                        {
        //                            SalaryId = e.SalaryId,
        //                            EmpCode = e.HR_Emp_Info.EmpCode,
        //                            EmpName = e.HR_Emp_Info.EmpName,
        //                            DesigName = e.HR_Emp_Info.Cat_Designation!=null? e.HR_Emp_Info.Cat_Designation.DesigName:"",
        //                            BasicSalary = e.BasicSalary,
        //                            HouseRent = e.HouseRent,
        //                            HRExp = e.HrExp,
        //                            EmpTypeName = e.HR_Emp_Info.Cat_Emp_Type != null ? e.HR_Emp_Info.Cat_Emp_Type.EmpTypeName : "",
        //                            LocationName = e.Cat_Location1 != null ? e.Cat_Location1.LocationName:"",
        //                            BuildingName = e.Cat_BuildingTypeHC != null ? e.Cat_BuildingTypeHC.BuildingName: ""
        //                        };


        //            var parser = new Parser<SalaryInfo>(Request.Form, query);

        //            return Json(parser.Parse());

        //        //}
        //        //return Json("");

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = "0", error = ex.Message });
        //        //throw ex;
        //    }

        //}

        // GET: hR_Emp_ArrearBill/Create
        public IActionResult Create()
        {
            string comid = HttpContext.Session.GetString("comid");
            ViewBag.Title = "Create";

            var empInfo = (from emp in _context.HR_Emp_Info
                           join d in _context.Cat_Department on emp.DeptId equals d.DeptId
                           join s in _context.Cat_Section on emp.SectId equals s.SectId
                           join des in _context.Cat_Designation on emp.DesigId equals des.DesigId
                           where emp.ComId == comid
                           select new
                           {
                               Value = emp.EmpId,
                               Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                           }).ToList();

            ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text");

            //ViewData["EmpId"] = new SelectList(_context.HR_Emp_Info
            //   .Where(s => s.ComId == comid)
            //   .Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
            //   .ToList(), "Value", "Text");


            return View();
        }

        // POST: hR_Emp_ArrearBill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[Bind("SalaryId,ComId,EmpId,LId1,LId2,LId3,BId,PFLId,WelfareLId,MCLId,HBLId,BasicSalary,IsBS,HouseRent,IsHr,MadicalAllow,IsMa,ConveyanceAllow,IsConvAllow,DearnessAllow,IsDearAllow,GasAllow,IsGasAllow,PersonalPay,IsPersonalPay,ArrearBasic,IsArrearBasic,ArrearBonus,IsArrearBonus,WashingAllow,IsWashingAllow,SiftAllow,ChargeAllow,IsChargAllow,MiscAdd,IsMiscAdd,ContainSub,IsContainSub,ComPfCount,IsComPfcount,EduAllow,IsEduAllow,TiffinAllow,IsTiffinAllow,CanteenAllow,IsCanteenAllow,AttAllow,IsAttAllow,FestivalBonus,IsFestivalBonus,RiskAllow,IsRiskAllow,NightAllow,IsNightAllow,MobileAllow,IsMobileAllow,Pf,IsPf,PfAdd,IsPfAdd,HrExp,IsHrexp,FesBonusDed,IsFesBonus,Transportcharge,IsTrncharge,TeliphoneCharge,IsTelcharge,TAExpense,IsTAExp,SalaryAdv,IsSalaryAdv,PurchaseAdv,McloanDed,IsMcloan,HbloanDed,IsHbloan,PfloannDed,IsPfloann,WfloanLocal,IsWfloanLocal,WfloanOther,IsWfloanOther,WpfloanDed,IsWpfloanDed,MaterialLoanDed,IsMaterialLoan,MiscDed,IsMiscDed,AdvAgainstExp,IsAdvAgainstExp,AdvFacility,IsAdvFacility,ElectricCharge,IsElectricCharge,Gascharge,IsGascharge,HazScheme,IsHazScheme,Donaton,IsDonaton,Dishantenna,IsDishantenna,RevenueStamp,IsRevenueStamp,OwaSub,IsOwaSub,DedIncBns,IsDedIncBns,DapEmpClub,IsDapEmpClub,Moktab,IsMoktab,ChemicalForum,IsChemicalForum,DiplomaassoDed,IsDiplomaassoDed,EnggassoDed,IsEnggassoDed,Wfsub,IsWfsub,EduAlloDed,IsEduAlloDed,PurChange,IsPurChange,IncomeTax,IsIncomeTax,ArrearInTaxDed,IsArrearInTaxDed,OffWlfareAsso,IsOffWlfareAsso,OfficeclubDed,IsOfficeclubDed,IncBonusDed,IsIncBonusDed,Watercharge,IsWatercharge,ChemicalAsso,IsChemicalAsso,AdvInTaxDed,IsAdvInTaxDed,ConvAllowDed,IsConvAllowDed,DedIncBonusOf,IsDedIncBonusOf,UnionSubDed,IsUnionSubDed,EmpClubDed,IsEmpClubDed,MedicalExp,IsMedicalExp,WagesaAdv,IsWagesaAdv,MedicalLoanDed,IsMedicalLoanDed,AdvWagesDed,IsAdvWagesDed,WFL,IsWFL,CheForum,IsCheForum")]
        public async Task<IActionResult> Create(HR_Emp_ArrearBill hR_Emp_ArrearBill)
        {
            string comid = HttpContext.Session.GetString("comid");
            if (ModelState.IsValid)
            {
                hR_Emp_ArrearBill.UserId = HttpContext.Session.GetString("userid");
                hR_Emp_ArrearBill.ComId = HttpContext.Session.GetString("comid");
                if (hR_Emp_ArrearBill.ArrBillId > 0)
                {
                    hR_Emp_ArrearBill.UpdateByUserId = HttpContext.Session.GetString("userid");
                    hR_Emp_ArrearBill.DateUpdated = DateTime.Now;
                    _context.Entry(hR_Emp_ArrearBill).State = EntityState.Modified;

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), hR_Emp_ArrearBill.EmpId.ToString(), "Update", hR_Emp_ArrearBill.EmpId.ToString());
                }
                else
                {
                    hR_Emp_ArrearBill.DateAdded = DateTime.Now;
                    _context.Add(hR_Emp_ArrearBill);

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), hR_Emp_ArrearBill.EmpId.ToString(), "Create", hR_Emp_ArrearBill.EmpId.ToString());

                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var empInfo = (from emp in _context.HR_Emp_Info
                           join d in _context.Cat_Department on emp.DeptId equals d.DeptId
                           join s in _context.Cat_Section on emp.SectId equals s.SectId
                           join des in _context.Cat_Designation on emp.DesigId equals des.DesigId
                           where emp.ComId == comid
                           select new
                           {
                               Value = emp.EmpId,
                               Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + s.SectName + " ] - [ " + d.DeptName + " ]"
                           }).ToList();

            ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text", hR_Emp_ArrearBill.EmpId);

            //ViewData["EmpId"] = new SelectList(_context.HR_Emp_Info
            //  .Where(s => s.ComId == comid)
            //  .Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
            //  .ToList(), "Value", "Text", hR_Emp_ArrearBill.EmpId);

            return View(hR_Emp_ArrearBill);
        }

        // GET: hR_Emp_ArrearBill/Edit/5


        [HttpPost]
        public IActionResult AutoSalaryCalculation(int EmpId, int LId1, int BId, Double BS)
        {
            int? empTypeId = _context.HR_Emp_Info.Find(EmpId).EmpTypeId;
            Cat_HRSetting hr = null;
            Cat_HRExpSetting hrExp = null;

            if (empTypeId != null)
            {
                hr = _context.Cat_HRSetting
                    .Where(h => h.EmpTypeId == empTypeId && h.LId == LId1 && h.BS <= BS && h.BId == BId)
                    .OrderByDescending(h => h.BS).FirstOrDefault();                    //.ToList();
                hrExp = _context.Cat_HRExpSetting
                   .Where(h => h.EmpTypeId == empTypeId && h.LId == LId1 && h.BId == BId && h.BS <= BS)
                   .OrderByDescending(h => h.BS).FirstOrDefault();

            }

            var gasCharge = _context.Cat_GasChargeSetting
             .Where(h => h.LId == LId1 && h.BId == BId).FirstOrDefault();

            var electricCharge = _context.Cat_ElectricChargeSetting
             .Where(h => h.LId == LId1 && h.BId == BId).FirstOrDefault();

            return Json(new { HR = hr, HRExp = hrExp, GasCharge = gasCharge, ElectricCharge = electricCharge });

        }

        [HttpGet]
        public IActionResult FamilyOCalculation(int EmpId, int LId2, int BId, Double BS)
        {
            int? empTypeId = _context.HR_Emp_Info.Find(EmpId).EmpTypeId;
            Cat_HRSetting hr = null;
            Cat_HRExpSetting hrExp = null;

            if (empTypeId != null)
            {
                hr = _context.Cat_HRSetting
                    .Where(h => h.EmpTypeId == empTypeId && h.LId == LId2 && h.BS <= BS && h.BId == BId)
                    .OrderByDescending(h => h.BS).FirstOrDefault();                    //.ToList();
                hrExp = _context.Cat_HRExpSetting
                   .Where(h => h.EmpTypeId == empTypeId && h.LId == LId2 && h.BId == BId && h.BS <= BS)
                   .OrderByDescending(h => h.BS).FirstOrDefault();

            }

            return Json(new { HR = hr, HRExp = hrExp });

        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string comid = HttpContext.Session.GetString("comid");
            //var hR_Emp_ArrearBill = await _context.hR_Emp_ArrearBill.FindAsync(id);
            var hR_Emp_ArrearBill = await _context.HR_Emp_ArrearBill
                .Include(h => h.HR_Emp_Info)
                .FirstOrDefaultAsync(m => m.ArrBillId == id);

            if (hR_Emp_ArrearBill == null)
            {
                ViewBag.Title = "Create";

                var empInfos = (from emp in _context.HR_Emp_Info
                                join d in _context.Cat_Department on emp.DeptId equals d.DeptId
                                join s in _context.Cat_Section on emp.SectId equals s.SectId
                                join des in _context.Cat_Designation on emp.DesigId equals des.DesigId
                                where emp.ComId == comid
                                select new
                                {
                                    Value = emp.EmpId,
                                    Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + s.SectName + " ] - [ " + d.DeptName + " ]"
                                }).ToList();

                ViewData["EmpId"] = new SelectList(empInfos, "Value", "Text", hR_Emp_ArrearBill.EmpId);

                //  ViewData["EmpId"] = new SelectList(_context.HR_Emp_Info
                //.Where(s => s.ComId == comid)
                //.Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
                //.ToList(), "Value", "Text", hR_Emp_ArrearBill.EmpId);

                return View("Create", hR_Emp_ArrearBill);
            }

            ViewBag.Title = "Edit";


            var empInfo = (from emp in _context.HR_Emp_Info
                           join d in _context.Cat_Department on emp.DeptId equals d.DeptId
                           join s in _context.Cat_Section on emp.SectId equals s.SectId
                           join des in _context.Cat_Designation on emp.DesigId equals des.DesigId
                           where emp.ComId == comid
                           select new
                           {
                               Value = emp.EmpId,
                               Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + s.SectName + " ] - [ " + d.DeptName + " ]"
                           }).ToList();

            ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text", hR_Emp_ArrearBill.EmpId);

            //ViewData["EmpId"] = new SelectList(_context.HR_Emp_Info
            //.Where(s => s.ComId == comid)
            //.Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
            //.ToList(), "Value", "Text", hR_Emp_ArrearBill.EmpId);

            return View("Create", hR_Emp_ArrearBill);
        }

        // GET: hR_Emp_ArrearBill/Delete/5
        //[Route("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Delete";
            string comid = HttpContext.Session.GetString("comid");
            var hR_Emp_ArrearBill = await _context.HR_Emp_ArrearBill
                .Include(h => h.HR_Emp_Info)
                .FirstOrDefaultAsync(m => m.ArrBillId == id);
            if (hR_Emp_ArrearBill == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Edit";

            var empInfo = (from emp in _context.HR_Emp_Info
                           join d in _context.Cat_Department on emp.DeptId equals d.DeptId
                           join s in _context.Cat_Section on emp.SectId equals s.SectId
                           join des in _context.Cat_Designation on emp.DesigId equals des.DesigId
                           where emp.ComId == comid
                           select new
                           {
                               Value = emp.EmpId,
                               Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + s.SectName + " ] - [ " + d.DeptName + " ]"
                           }).ToList();

            ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text", hR_Emp_ArrearBill.EmpId);

            // ViewData["EmpId"] = new SelectList(_context.HR_Emp_Info
            //.Where(s => s.ComId == comid)
            //.Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
            //.ToList(), "Value", "Text", hR_Emp_ArrearBill.EmpId);
            return View("Create", hR_Emp_ArrearBill);
        }

        // POST: hR_Emp_ArrearBill/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var hR_Emp_ArrearBill = await _context.HR_Emp_ArrearBill.FindAsync(id);
                _context.HR_Emp_ArrearBill.Remove(hR_Emp_ArrearBill);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), hR_Emp_ArrearBill.EmpId.ToString(), "Delete", hR_Emp_ArrearBill.EmpId.ToString());

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, EmpId = hR_Emp_ArrearBill.ArrBillId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool hR_Emp_ArrearBillExists(int id)
        {
            return _context.HR_Emp_ArrearBill.Any(e => e.ArrBillId == id);
        }
    }
}
