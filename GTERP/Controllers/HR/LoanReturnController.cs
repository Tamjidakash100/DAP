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

    public class LoanReturnController : Controller
    {
        public LoanReturnController(GTRDBContext _db)
        {
            db = _db;
        }

        private GTRDBContext db { get; set; }

        public IActionResult Index()
        {
            var comid = HttpContext.Session.GetString("comid");

            //ViewBag.LoanReturnTypeList = db.Cat_Location
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

            ViewBag.LoanType = new SelectList(db.Cat_Variable
               .Where(v => v.ComId == comid && v.VarType == "LoanReturnType")
               .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            return View();
            //return PartialView("~/Views/Folder/_PartialName.cshtml", new LoanReturn());

        }

        [HttpPost]
        public JsonResult Create(HR_Loan_Return LoanReturn)
        {
            if (ModelState.IsValid)
            {
                var check = db.HR_Loan_Return
                    .Where(s => s.EmpId == LoanReturn.EmpId && s.DtInput.Date.Month == LoanReturn.DtInput.Date.Month
                    && s.LoanType == LoanReturn.LoanType && s.LoanReturnId != LoanReturn.LoanReturnId).FirstOrDefault();
                if (check != null)
                {
                    TempData["Message"] = "Data Already Exist";
                    return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                }

                string comid = HttpContext.Session.GetString("comid");
                LoanReturn.ComId = comid;
                LoanReturn.UserId = HttpContext.Session.GetString("userid");
                if (LoanReturn.LoanReturnId > 0)
                {
                    LoanReturn.DateAdded = DateTime.Now;
                    db.Entry(LoanReturn).State = EntityState.Modified;
                    TempData["Message"] = "Data Update Successfully";
                }
                else
                {
                    LoanReturn.DateUpdated = DateTime.Now;
                    LoanReturn.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Add(LoanReturn);
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
        [HttpPost]
        public JsonResult DeleteLoanReturnAjax(int DedId)
        {
            var LoanReturn = db.HR_Loan_Return.Find(DedId);
            if (LoanReturn != null)
            {
                db.HR_Loan_Return.Remove(LoanReturn);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, ex = TempData["Message"].ToString() });
            }

            TempData["Message"] = "Data Not Found";
            return Json(new { Success = 2, ex = TempData["Message"].ToString() });
        }


        //load salary addition partial view
        public ActionResult LoadLoanReturnPartial(DateTime date)
        {
            //List<LoanReturn> LoanReturns = LoanReturn.PrcGetLoanReturnData(date);
            //ViewBag.LoanReturns = LoanReturns;
            string comid = HttpContext.Session.GetString("comid");
            var LoanReturns = db.HR_Loan_Return
                .Include(s => s.HR_Emp_Info)
                .Include(s => s.HR_Emp_Info.Cat_Section)
                .Where(s => s.DtInput.Date.Month == date.Month && s.DtInput.Date.Year == date.Year && s.ComId == comid)
                .Select(s => new LoanReturn
                {
                    LoanReturnId = s.LoanReturnId,
                    EmpId = s.EmpId,
                    EmpCode = s.HR_Emp_Info.EmpCode,
                    EmpName = s.HR_Emp_Info.EmpName,
                    Section = s.HR_Emp_Info.Cat_Section.SectName,
                    Designation = s.HR_Emp_Info.Cat_Designation.DesigName,
                    DtJoin = s.DtJoin.ToString("dd-MMM-yyyy"),
                    DtInput = s.DtInput.ToString("dd-MMM-yyyy"),
                    Amount = s.Amount,
                    LoanType = s.LoanType
                }).ToList();
            //ViewBag.LoanReturns = LoanReturns;
            //return PartialView("~/Views/LoanReturn/_LoanReturnGrid.cshtml", new LoanReturn());
            return Json(LoanReturns);
        }

        public class LoanReturn
        {
            public int LoanReturnId { get; set; }
            public int EmpId { get; set; }
            public string EmpCode { get; set; }
            public string EmpName { get; set; }
            public string DtJoin { get; set; }
            public string DtInput { get; set; }
            public string Section { get; set; }
            public string Designation { get; set; }
            public double Amount { get; set; }
            public string LoanType { get; set; }
        }
    }
}