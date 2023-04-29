using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTERP.Controllers.Payroll
{
    [OverridableAuthorize]
    public class SalaryDeductionController : Controller
    {
        public SalaryDeductionController(GTRDBContext _db)
        {
            db = _db;
        }

        private GTRDBContext db { get; set; }

        public IActionResult Index()
        {
            var comid = HttpContext.Session.GetString("comid");

            //ViewBag.SalaryDeductionTypeList = db.Cat_Location
            //    .Select(x => new { x.LId, x.LocationName }).ToList();

            var empData = db.HR_Emp_Info
                .Where(s => s.ComId == comid)
                .Select(s => new
                {
                    EmpId = s.EmpId,
                    EmpCode = s.EmpCode,
                    EmpName = s.EmpName,
                    DtJoin = s.DtJoin
                })
                .ToList();
            ViewBag.EmpInfo = empData;


            var empInfo = (from emp in db.HR_Emp_Info
                           join d in db.Cat_Department on emp.DeptId equals d.DeptId
                           join s in db.Cat_Section on emp.SectId equals s.SectId
                           join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                           where emp.ComId == comid
                           select new
                           {
                               Value = emp.EmpId,
                               Text = emp.EmpCode + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                           }).ToList();

            ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text");

            ViewBag.OtherDedType = new SelectList(db.Cat_Variable
               .Where(v => v.ComId == comid && v.VarType == "SalaryDeduction")
               .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            return View();
            //return PartialView("~/Views/Folder/_PartialName.cshtml", new SalaryDeduction());

        }

        [HttpPost]
        public JsonResult Create(Payroll_SalaryDeduction SalaryDeduction)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var check = db.Payroll_SalaryAddition
                        .Where(s => s.EmpId == SalaryDeduction.EmpId && s.DtInput.Date.Month == SalaryDeduction.DtInput.Date.Month
                        && s.DtInput.Date.Year == SalaryDeduction.DtInput.Date.Year
                        && s.OtherAddType == SalaryDeduction.OtherDedType && s.SalAddId != SalaryDeduction.SalDedId).FirstOrDefault();
                    if (check != null)
                    {
                        TempData["Message"] = "Data Already Exist";
                        return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                    }

                    string comid = HttpContext.Session.GetString("comid");
                    SalaryDeduction.ComId = comid;
                    SalaryDeduction.UserId = HttpContext.Session.GetString("userid");
                    if (SalaryDeduction.SalDedId > 0)
                    {
                        SalaryDeduction.DateAdded = DateTime.Now;
                        db.Entry(SalaryDeduction).State = EntityState.Modified;
                        TempData["Message"] = "Data Update Successfully";
                    }
                    else
                    {
                        SalaryDeduction.DateUpdated = DateTime.Now;
                        SalaryDeduction.UpdateByUserId = HttpContext.Session.GetString("userid");
                        db.Add(SalaryDeduction);
                        TempData["Message"] = "Data Save Successfully";
                    }
                    db.SaveChanges();
                    return Json(new { Success = 1, ex = TempData["Message"].ToString() });

                }
                else
                {
                    TempData["Message"] = "Models state is not valid";
                    return Json(new { Success = 3, ex = TempData["Message"].ToString() });
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Json(new { Success = 3, ex = TempData["Message"].ToString() });
            }


        }
        [HttpPost]
        public JsonResult DeleteSalaryDeductionAjax(int DedId)
        {
            var SalaryDeduction = db.Payroll_SalaryDeduction.Find(DedId);
            if (SalaryDeduction != null)
            {
                db.Payroll_SalaryDeduction.Remove(SalaryDeduction);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, ex = TempData["Message"].ToString() });
            }

            TempData["Message"] = "Data Not Found";
            return Json(new { Success = 2, ex = TempData["Message"].ToString() });
        }


        //load salary addition partial view
        public ActionResult LoadSalaryDeductionPartial(DateTime date)
        {
            //List<SalaryDeduction> SalaryDeductions = SalaryDeduction.PrcGetSalaryDeductionData(date);
            //ViewBag.SalaryDeductions = SalaryDeductions;
            string comid = HttpContext.Session.GetString("comid");
            var SalaryDeductions = db.Payroll_SalaryDeduction
                .Include(s => s.HR_Emp_Info)
                .Include(s => s.HR_Emp_Info.Cat_Section)
                .Where(s => s.DtInput.Date.Month == date.Month && s.DtInput.Date.Year == date.Year && s.ComId == comid)
                .Select(s => new SalaryDeduction
                {
                    DedId = s.SalDedId,
                    EmpId = s.EmpId,
                    EmpCode = s.HR_Emp_Info.EmpCode,
                    EmpName = s.HR_Emp_Info.EmpName,
                    Section = s.HR_Emp_Info.Cat_Section.SectName,
                    Designation = s.HR_Emp_Info.Cat_Designation.DesigName,
                    DtJoin = s.DtJoin.ToString("dd-MMM-yyyy"),
                    DtInput = s.DtInput.ToString("dd-MMM-yyyy"),
                    Amount = s.Amount,
                    OtherDedType = s.OtherDedType
                }).ToList();
            //ViewBag.SalaryDeductions = SalaryDeductions;
            //return PartialView("~/Views/SalaryDeduction/_SalaryDeductionGrid.cshtml", new SalaryDeduction());
            return Json(SalaryDeductions);
        }

        public class SalaryDeduction
        {
            public int DedId { get; set; }
            public int EmpId { get; set; }
            public string EmpCode { get; set; }
            public string EmpName { get; set; }
            public string DtJoin { get; set; }
            public string DtInput { get; set; }
            public string Section { get; set; }
            public string Designation { get; set; }
            public double Amount { get; set; }
            public string OtherDedType { get; set; }
        }
    }
}