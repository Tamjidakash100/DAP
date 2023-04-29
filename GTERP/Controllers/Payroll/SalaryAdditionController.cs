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
    public class SalaryAdditionController : Controller
    {
        public SalaryAdditionController(GTRDBContext _db)
        {
            db = _db;
        }

        private GTRDBContext db { get; set; }

        public IActionResult Index()
        {
            var comid = HttpContext.Session.GetString("comid");

            //ViewBag.SalaryAdditionTypeList = db.Cat_Location
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

            ViewBag.OtherAddType = new SelectList(db.Cat_Variable
               .Where(v => v.ComId == comid && v.VarType == "SalaryAddition")
               .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            return View();
            //return PartialView("~/Views/Folder/_PartialName.cshtml", new SalaryAddition());

        }

        [HttpPost]
        public JsonResult Create(Payroll_SalaryAddition salaryAddition)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var check = db.Payroll_SalaryAddition
                        .Where(s => s.EmpId == salaryAddition.EmpId && s.DtInput.Date.Month == salaryAddition.DtInput.Date.Month
                        && s.DtInput.Date.Year == salaryAddition.DtInput.Date.Year
                        && s.OtherAddType == salaryAddition.OtherAddType && s.SalAddId != salaryAddition.SalAddId).FirstOrDefault();
                    if (check != null)
                    {
                        TempData["Message"] = "Data Already Exist";
                        return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                    }

                    string comid = HttpContext.Session.GetString("comid");
                    salaryAddition.ComId = comid;
                    salaryAddition.UserId = HttpContext.Session.GetString("userid");
                    if (salaryAddition.SalAddId > 0)
                    {


                        salaryAddition.DateAdded = DateTime.Now;
                        db.Entry(salaryAddition).State = EntityState.Modified;
                        TempData["Message"] = "Data Update Successfully";
                    }
                    else
                    {
                        salaryAddition.DateUpdated = DateTime.Now;
                        salaryAddition.UpdateByUserId = HttpContext.Session.GetString("userid");
                        db.Add(salaryAddition);
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
        public JsonResult DeleteSalaryAdditionAjax(int addId)
        {
            var salaryAddition = db.Payroll_SalaryAddition.Find(addId);
            if (salaryAddition != null)
            {
                db.Payroll_SalaryAddition.Remove(salaryAddition);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, ex = TempData["Message"].ToString() });
            }

            TempData["Message"] = "No Data Found";
            return Json(new { Success = 2, ex = TempData["Message"].ToString() });
        }


        //load salary addition partial view
        [HttpPost]
        public ActionResult LoadSalaryAdditionPartial(DateTime date)
        {
            //List<SalaryAddition> salaryAdditions = SalaryAddition.PrcGetSalaryAdditionData(date);
            //ViewBag.SalaryAdditions = salaryAdditions;
            string comid = HttpContext.Session.GetString("comid");
            var salaryAdditions = db.Payroll_SalaryAddition
                .Include(s => s.HR_Emp_Info)
                .Include(s => s.HR_Emp_Info.Cat_Section)
                .Where(s => s.DtInput.Date.Month == date.Month && s.DtInput.Date.Year == date.Year && s.ComId == comid)
                .Select(s => new SalaryAddition
                {
                    SalAddId = s.SalAddId,
                    EmpId = s.EmpId,
                    EmpCode = s.HR_Emp_Info.EmpCode,
                    EmpName = s.HR_Emp_Info.EmpName,
                    Section = s.HR_Emp_Info.Cat_Section.SectName,
                    Designation = s.HR_Emp_Info.Cat_Designation.DesigName,
                    DtJoin = s.DtJoin.ToString("dd-MMM-yyyy"),
                    DtInput = s.DtInput.ToString("dd-MMM-yyyy"),
                    Amount = s.Amount,
                    OtherAddType = s.OtherAddType
                }).ToList();
            //ViewBag.SalaryAdditions = salaryAdditions;
            //return PartialView("~/Views/SalaryAddition/_SalaryAdditionGrid.cshtml", new SalaryAddition());
            return Json(salaryAdditions);
        }

        public class SalaryAddition
        {
            public int SalAddId { get; set; }
            public int EmpId { get; set; }
            public string EmpCode { get; set; }
            public string EmpName { get; set; }
            public string DtJoin { get; set; }
            public string DtInput { get; set; }
            public string Section { get; set; }
            public string Designation { get; set; }
            public double Amount { get; set; }
            public string OtherAddType { get; set; }
        }
    }
}