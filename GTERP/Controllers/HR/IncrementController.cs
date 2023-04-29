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
    public class IncrementController : Controller
    {
        private readonly GTRDBContext db;

        public IncrementController(GTRDBContext context)
        {
            db = context;
        }

        // GET: HR_Emp_Increment
        public async Task<IActionResult> Index()
        {
            string comid = HttpContext.Session.GetString("comid");

            ViewBag.increment = new List<HR_Emp_Increment>();
            ViewBag.NewDeptId = new SelectList(db.Cat_Department, "DeptId", "DeptName");
            ViewBag.OldDeptId = new SelectList(db.Cat_Department, "DeptId", "DeptName");
            ViewBag.NewDesigId = new SelectList(db.Cat_Designation, "DesigId", "DesigName");
            ViewBag.OldDesigId = new SelectList(db.Cat_Designation, "DesigId", "DesigName");
            ViewBag.NewSectId = new SelectList(db.Cat_Section, "SectId", "SectName");
            ViewBag.OldSectId = new SelectList(db.Cat_Section, "SectId", "SectName");
            ViewBag.NewUnitId = new SelectList(db.Cat_Unit, "UnitId", "UnitName");
            ViewBag.OldUnitId = new SelectList(db.Cat_Unit, "UnitId", "UnitName");
            ViewBag.EmpId = new SelectList(db.HR_Emp_Info.Select(e => new { Text = e.EmpName + "- [" + e.EmpCode + "]", Value = e.EmpId }).OrderBy(e => e.Value).ToList(), "Value", "Text");

            var empInfo = (from emp in db.HR_Emp_Info
                           join d in db.Cat_Department on emp.DeptId equals d.DeptId
                           join s in db.Cat_Section on emp.SectId equals s.SectId
                           join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                           join EI in db.HR_Emp_PersonalInfo on emp.EmpId equals EI.EmpId
                           where emp.ComId == comid
                           select new
                           {
                               Value = emp.EmpId,
                               Text = emp.EmpCode + " - [ " + EI.EmployeeCodeBCIC + " ] - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                           }).ToList();

            ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text");

            ViewBag.IncTypeId = new SelectList(db.HR_IncType, "IncTypeId", "IncType");
            ViewBag.OldEmpTypeId = new SelectList(db.Cat_Emp_Type, "EmpTypeId", "EmpTypeName");
            ViewBag.NewEmpTypeId = new SelectList(db.Cat_Emp_Type, "EmpTypeId", "EmpTypeName");

            return View();
        }



        [HttpPost]
        public JsonResult GetEmployeeInfo(int empid)
        {
            var comid = HttpContext.Session.GetString("comid");
            var dtincrement = DateTime.Now.ToString("dd-MMM-yyyy");

            var EmpInfo = db.HR_Emp_Info.Select(e => new
            {
                e.EmpId,
                e.EmpCode,
                e.EmpName,
                DtJoin = Convert.ToDateTime(e.DtJoin).ToString("dd-MMM-yyyy"),
                DesigName = e.Cat_Designation.DesigName,
                SectName = e.Cat_Section.SectName,
                DesigId = e.DesigId,
                SectId = e.SectId,
                EmpTypeId = e.EmpTypeId,
                e.ComId,
                DtIncrement = Convert.ToDateTime(e.DtIncrement).ToString("dd-MMM-yyyy"),
                IncTypeId = e.HR_Emp_Increment.IncTypeId
            }).Where(e => e.EmpId == empid && e.ComId == comid).ToList();

            var SalaryInfo = db.HR_Emp_Salary.Select(s => new
            {
                s.BasicSalary,
                s.HouseRent,
                s.HrExp,
                s.HRExpensesOther,
                //s.FoodAllow,
                s.MadicalAllow,
                //s.ConveyanceAllow,
                s.EmpId
            }).Where(s => s.EmpId == empid).ToList();

            return Json(new { EmpInfo, SalaryInfo });
        }


        [HttpPost]  // Get Salary info for auto calculation
        public IActionResult GetSalaryInfo(int empId, float BS)
        {
            var empTypeId = db.HR_Emp_Info.Find(empId).EmpTypeId;
            var empSalary = db.HR_Emp_Salary.Where(s => s.EmpId == empId).FirstOrDefault();

            Cat_HRSetting hr = null;
            Cat_HRExpSetting hrExp = null;

            if (empSalary.BId == 11)
            {
                if (empTypeId != null)
                {
                    hr = db.Cat_HRSetting
                        .Where(h => h.EmpTypeId == empTypeId && h.LId == empSalary.LId2 && h.BS <= BS && h.BId == empSalary.BId)
                        .OrderByDescending(h => h.BS).FirstOrDefault();                    //.ToList();
                    hrExp = db.Cat_HRExpSetting
                       .Where(h => h.EmpTypeId == empTypeId && h.LId == empSalary.LId2 && h.BId == empSalary.BId && h.BS <= BS)
                       .OrderByDescending(h => h.BS).FirstOrDefault();
                }

            }
            else
            {
                if (empTypeId != null && empSalary != null)
                {
                    hr = db.Cat_HRSetting
                        .Where(h => h.EmpTypeId == empTypeId && h.LId == empSalary.LId1 && h.BS <= BS && h.BId == empSalary.BId)
                        .OrderByDescending(h => h.BS).FirstOrDefault();                    //.ToList();
                    hrExp = db.Cat_HRExpSetting
                       .Where(h => h.EmpTypeId == empTypeId && h.LId == empSalary.LId1 && h.BId == empSalary.BId && h.BS <= BS)
                       .OrderByDescending(h => h.BS).FirstOrDefault();
                }
            }


            return Json(new { HR = hr, HRExp = hrExp, EmpSalary = empSalary });
        }



        [HttpPost]
        public JsonResult LoadIncrementGrid(int empid)
        {
            var comid = HttpContext.Session.GetString("comid");
            var increment = db.HR_Emp_Increment
                .Include(i => i.HR_IncType)
                .Where(i => i.EmpId == empid && i.ComId == comid)
                .Select(ei => new
                {
                    IncrementId = ei.IncId,
                    IncrementType = ei.HR_IncType.IncType,
                    DtIncrement = Convert.ToDateTime(ei.DtIncrement).ToString("dd-MMM-yyyy"),
                    Amount = ei.Amount,
                    ei.NewBS
                }).ToList().OrderBy(i => i.IncrementId);
            return Json(increment);
        }

        [HttpPost]
        public ActionResult SaveIncrementInfo(HR_Emp_Increment hR_Emp_Increment)
        {
            try
            {
                string comid = HttpContext.Session.GetString("comid");
                string userid = HttpContext.Session.GetString("userid");
                hR_Emp_Increment.UserId = userid;

                hR_Emp_Increment.ComId = comid;

                hR_Emp_Increment.DtInput = DateTime.Now;
                if (hR_Emp_Increment.IncId > 0)
                {



                    HR_Emp_Salary salary = db.HR_Emp_Salary.Where(s => s.EmpId == hR_Emp_Increment.EmpId && s.ComId == hR_Emp_Increment.ComId).FirstOrDefault();
                    hR_Emp_Increment.OldSalary = salary.BasicSalary + salary.HouseRent + salary.MadicalAllow;
                    hR_Emp_Increment.NewSalary = (hR_Emp_Increment.NewBS + hR_Emp_Increment.NewHR + hR_Emp_Increment.NewMA);

                    hR_Emp_Increment.BSDiff = (float)(hR_Emp_Increment.NewBS - hR_Emp_Increment.OldBS);
                    hR_Emp_Increment.HRDiff = (float)(hR_Emp_Increment.NewHR - hR_Emp_Increment.OldHR);
                    hR_Emp_Increment.HRExpDiff = (float)(hR_Emp_Increment.NewHRExp - hR_Emp_Increment.OldHRExp);
                    hR_Emp_Increment.HRExpOtherDiff = (float)(hR_Emp_Increment.NewHRExpOther - hR_Emp_Increment.OldHRExpOther);
                    hR_Emp_Increment.MADiff = (float)(hR_Emp_Increment.NewMA - hR_Emp_Increment.OldMA);

                    //var oldsalary = hR_Emp_Increment.OldSalary;
                    //var newsalary = hR_Emp_Increment.NewSalary;

                    //hR_Emp_Increment.Amount = (newsalary - oldsalary);

                    //var incamount = hR_Emp_Increment.Amount;

                    //hR_Emp_Increment.Percentage = ((float)((incamount / oldsalary) * 100));
                    HR_Emp_Salary empsal = db.HR_Emp_Salary
                        .Include(e => e.HR_Emp_Info)
                        .Where(s => s.EmpId == hR_Emp_Increment.EmpId && s.ComId == comid).FirstOrDefault();
                    if (empsal != null)
                    {
                        empsal.BasicSalary = (float)hR_Emp_Increment.NewBS;
                        empsal.HouseRent = (float)hR_Emp_Increment.NewHR;
                        empsal.HrExp = (float)hR_Emp_Increment.NewHRExp;
                        empsal.HRExpensesOther = (float)hR_Emp_Increment.NewHRExpOther;
                        empsal.MadicalAllow = (float)hR_Emp_Increment.NewMA;
                        //empsal.FoodAllow = (float)hR_Emp_Increment.NewFA;
                        //empsal.ConveyanceAllow = (float)hR_Emp_Increment.NewTA;
                        var newdesigid = Convert.ToInt32(hR_Emp_Increment.NewDesigId);
                        if (newdesigid > 0)
                        {
                            empsal.HR_Emp_Info.DesigId = newdesigid;
                        }

                        var newsectid = Convert.ToInt32(hR_Emp_Increment.NewSectId);
                        if (newsectid > 0)
                        {
                            empsal.HR_Emp_Info.SectId = newsectid;
                        }
                        var newemptypeid = Convert.ToInt32(hR_Emp_Increment.NewEmpTypeId);
                        if (newemptypeid > 0)
                        {
                            empsal.HR_Emp_Info.EmpTypeId = newemptypeid;
                        }
                        empsal.HR_Emp_Info.DtIncrement = hR_Emp_Increment.DtIncrement;
                        db.Entry(empsal.HR_Emp_Info).State = EntityState.Modified;
                        db.Entry(empsal).State = EntityState.Modified;
                    }

                    hR_Emp_Increment.UpdateByUserId = userid;
                    hR_Emp_Increment.DateUpdated = DateTime.Now;
                    db.Entry(hR_Emp_Increment).State = EntityState.Modified;
                }
                else
                {


                    var check = db.HR_Emp_Increment.Where(i => i.EmpId == hR_Emp_Increment.EmpId
                            && i.DtIncrement == hR_Emp_Increment.DtIncrement
                            && i.IncTypeId == hR_Emp_Increment.IncTypeId).FirstOrDefault();

                    if (check != null)
                    {
                        return Json(new { Success = 2, ex = "The employee has Incremen or Promotion this date" });
                    }

                    HR_Emp_Salary salary = db.HR_Emp_Salary.Where(s => s.EmpId == hR_Emp_Increment.EmpId && s.ComId == hR_Emp_Increment.ComId).FirstOrDefault();
                    hR_Emp_Increment.OldSalary = salary.BasicSalary + salary.HouseRent + salary.MadicalAllow;
                    hR_Emp_Increment.NewSalary = (hR_Emp_Increment.NewBS + hR_Emp_Increment.NewHR + hR_Emp_Increment.NewMA);

                    hR_Emp_Increment.BSDiff = (float)(hR_Emp_Increment.NewBS - hR_Emp_Increment.OldBS);
                    hR_Emp_Increment.HRDiff = (float)(hR_Emp_Increment.NewHR - hR_Emp_Increment.OldHR);
                    hR_Emp_Increment.HRExpDiff = (float)(hR_Emp_Increment.NewHRExp - hR_Emp_Increment.OldHRExp);
                    hR_Emp_Increment.HRExpOtherDiff = (float)(hR_Emp_Increment.NewHRExpOther - hR_Emp_Increment.OldHRExpOther);
                    hR_Emp_Increment.MADiff = (float)(hR_Emp_Increment.NewMA - hR_Emp_Increment.OldMA);

                    //var oldsalary = hR_Emp_Increment.OldSalary;
                    //var newsalary = hR_Emp_Increment.NewSalary;

                    //hR_Emp_Increment.Amount = (newsalary - oldsalary);

                    //var incamount = hR_Emp_Increment.Amount;

                    //hR_Emp_Increment.Percentage = (float)((incamount / oldsalary) * 100);
                    HR_Emp_Salary empsal = db.HR_Emp_Salary
                        .Include(e => e.HR_Emp_Info)
                        .Where(s => s.EmpId == hR_Emp_Increment.EmpId && s.ComId == comid).FirstOrDefault();
                    if (empsal != null)
                    {
                        empsal.BasicSalary = (float)hR_Emp_Increment.NewBS;
                        empsal.HouseRent = (float)hR_Emp_Increment.NewHR;
                        empsal.HrExp = (float)hR_Emp_Increment.NewHRExp;
                        empsal.HRExpensesOther = (float)hR_Emp_Increment.NewHRExpOther;
                        empsal.MadicalAllow = (float)hR_Emp_Increment.NewMA;
                        //empsal.FoodAllow = (float)hR_Emp_Increment.NewFA;
                        //empsal.ConveyanceAllow = (float)hR_Emp_Increment.NewTA;
                        var newdesigid = Convert.ToInt32(hR_Emp_Increment.NewDesigId);
                        if (newdesigid > 0)
                        {
                            empsal.HR_Emp_Info.DesigId = newdesigid;
                        }

                        var newsectid = Convert.ToInt32(hR_Emp_Increment.NewSectId);
                        if (newsectid > 0)
                        {
                            empsal.HR_Emp_Info.SectId = newsectid;
                        }

                        var newemptypeid = Convert.ToInt32(hR_Emp_Increment.NewEmpTypeId);
                        if (newemptypeid > 0)
                        {
                            empsal.HR_Emp_Info.EmpTypeId = newemptypeid;
                        }

                        empsal.HR_Emp_Info.DtIncrement = hR_Emp_Increment.DtIncrement;
                        db.Entry(empsal.HR_Emp_Info).State = EntityState.Modified;
                        db.Entry(empsal).State = EntityState.Modified;
                        //db.SaveChanges();
                    }

                    hR_Emp_Increment.DateAdded = DateTime.Now;
                    db.Add(hR_Emp_Increment);
                }
                db.SaveChanges();
                TempData["Message"] = "Data Saved / Update Successfully";
                return Json(new { Success = 1, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.Message });
            }

        }

        public ActionResult GetIncrementId(int incId)
        {
            var inc = db.HR_Emp_Increment.Where(i => i.IncId == incId);
            db.Remove(inc);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public JsonResult GetIncrementInfo(int IncId)
        {
            var IncrementInfo = db.HR_Emp_Increment.Select(i => new
            {
                IncId = i.IncId,
                EmpCode = i.HR_Emp_Info.EmpCode,
                EmpName = i.HR_Emp_Info.EmpName,
                SectName = i.HR_Emp_Info.Cat_Section.SectName,
                DeptName = i.Cat_DepartmentOld.DeptName,
                DesigName = i.Cat_DesignationOld.DesigName,
                OldEmpTypeId = i.OldEmpTypeId,
                NewEmpTypeId = i.NewEmpTypeId,
                IncType = i.HR_IncType.IncType,
                DtIncrement = Convert.ToDateTime(i.DtIncrement).ToString("dd-MMM-yyyy"),
                DtInput = i.DtInput,
                IncTypeId = i.IncTypeId,
                OldBS = i.OldBS,
                OldHR = i.OldHR,
                OldHRExp = i.OldHRExp,
                OldHRExpOther = i.OldHRExpOther,
                OldMA = i.OldMA,
                OldTA = i.OldTA,
                OldFA = i.OldFA,
                Amount = i.Amount,
                Percentage = i.Percentage,
                OldSalary = i.OldSalary,
                NewSalary = i.NewSalary,
                OldPA = i.OldPA,
                NewPA = i.NewPA,
                OldDA = i.OldDA,
                NewDA = i.NewDA,
                NewBS = i.NewBS,
                NewHR = i.NewHR,
                NewHRExp = i.NewHRExp,
                NewHRExpOther = i.NewHRExpOther,
                NewMA = i.NewMA,
                //NewFA = i.NewFA,
                //NewTA = i.NewTA
            }).Where(i => i.IncId == IncId);
            return Json(IncrementInfo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string comid = HttpContext.Session.GetString("comid");
            var hR_Emp_Increment = await db.HR_Emp_Increment.FindAsync(id);

            HR_Emp_Salary empsal = await db.HR_Emp_Salary
                        .Include(e => e.HR_Emp_Info)
                        .Where(s => s.EmpId == hR_Emp_Increment.EmpId && s.ComId == comid).FirstOrDefaultAsync();
            if (empsal != null)
            {
                empsal.BasicSalary = (float)hR_Emp_Increment.OldBS;
                empsal.HouseRent = (float)hR_Emp_Increment.OldHR;
                empsal.HrExp = (float)hR_Emp_Increment.OldHRExp;
                empsal.HRExpensesOther = (float)hR_Emp_Increment.OldHRExpOther;
                empsal.MadicalAllow = (float)hR_Emp_Increment.OldMA;
                //empsal.FoodAllow = (float)hR_Emp_Increment.OldFA;
                //empsal.ConveyanceAllow = (float)hR_Emp_Increment.OldTA;
                var oldDesigId = Convert.ToInt32(hR_Emp_Increment.OldDesigId);
                if (oldDesigId > 0)
                {
                    empsal.HR_Emp_Info.DesigId = oldDesigId;
                }

                var oldSectId = Convert.ToInt32(hR_Emp_Increment.OldSectId);
                if (oldSectId > 0)
                {
                    empsal.HR_Emp_Info.SectId = oldSectId;
                }

                var oldEmpTypeId = Convert.ToInt32(hR_Emp_Increment.OldEmpTypeId);
                if (oldEmpTypeId > 0)
                {
                    empsal.HR_Emp_Info.EmpTypeId = oldEmpTypeId;
                }

                empsal.HR_Emp_Info.DtIncrement = hR_Emp_Increment.DtIncrement;
                db.Entry(empsal.HR_Emp_Info).State = EntityState.Modified;
                db.Entry(empsal).State = EntityState.Modified;
                //db.SaveChanges();
            }

            db.HR_Emp_Increment.Remove(hR_Emp_Increment);
            await db.SaveChangesAsync();
            TempData["Message"] = "Data Delete Successfully";
            return Json(new { Success = 1, ex = TempData["Message"].ToString() });
        }

        private bool HR_Emp_IncrementExists(int id)
        {
            return db.HR_Emp_Increment.Any(e => e.IncId == id);
        }
    }
}
