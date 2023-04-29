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
    public class PFContributionController : Controller
    {
        [OverridableAuthorize]
        public PFContributionController(GTRDBContext _db)
        {
            db = _db;
        }

        private GTRDBContext db { get; set; }

        public IActionResult Index()
        {
            var comid = HttpContext.Session.GetString("comid");

            //ViewBag.PFContributionTypeList = db.Cat_Location
            //    .Select(x => new { x.LId, x.LocationName }).ToList();

            var empData = db.HR_Emp_Info
                .Where(s => s.ComId == comid)
                .Select(s => new
                {
                    EmpId = s.EmpId,
                    EmpCode = s.HR_Emp_PersonalInfo.PFFileNo,
                    EmpName = s.EmpName,
                    DtJoin = s.DtJoin
                })
                .ToList();
            ViewBag.EmpInfo = empData;


            var empInfo = (from emp in db.HR_Emp_Info
                           join ep in db.HR_Emp_PersonalInfo on emp.EmpId equals ep.EmpId
                           join d in db.Cat_Department on emp.DeptId equals d.DeptId
                           join s in db.Cat_Section on emp.SectId equals s.SectId
                           join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                           where emp.ComId == comid & ep.IsAllowPF == true
                           select new
                           {
                               Value = emp.EmpId,
                               Text = ep.PFFileNo + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                           }).ToList();

            ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text");

            ViewBag.PF = new SelectList(db.Cat_Variable
               .Where(v => v.ComId == comid && v.VarType == "PFContributionType")
               .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            return View();
            //return PartialView("~/Views/Folder/_PartialName.cshtml", new PFContribution());

        }

        [HttpPost]
        public JsonResult Create(HR_PFContribution PFContribution)
        {
            if (ModelState.IsValid)
            {
                var check = db.HR_PFContribution
                    .Where(s => s.EmpId == PFContribution.EmpId && s.DtInput.Date.Month == PFContribution.DtInput.Date.Month
                    && s.PF == PFContribution.PF && s.PFContributionId != PFContribution.PFContributionId).FirstOrDefault();
                if (check != null)
                {
                    TempData["Message"] = "Data Already Exist";
                    return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                }

                string comid = HttpContext.Session.GetString("comid");
                PFContribution.ComId = comid;
                PFContribution.UserId = HttpContext.Session.GetString("userid");
                if (PFContribution.PFContributionId > 0)
                {
                    PFContribution.DateAdded = DateTime.Now;
                    db.Entry(PFContribution).State = EntityState.Modified;
                    TempData["Message"] = "Data Update Successfully";
                }
                else
                {
                    PFContribution.DateUpdated = DateTime.Now;
                    PFContribution.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Add(PFContribution);
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
        public JsonResult DeletePFContributionAjax(int DedId)
        {
            var PFContribution = db.HR_PFContribution.Find(DedId);
            if (PFContribution != null)
            {
                db.HR_PFContribution.Remove(PFContribution);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, ex = TempData["Message"].ToString() });
            }

            TempData["Message"] = "Data Not Found";
            return Json(new { Success = 2, ex = TempData["Message"].ToString() });
        }


        //load salary addition partial view
        public ActionResult LoadPFContributionPartial(DateTime date)
        {
            //List<PFContribution> PFContributions = PFContribution.PrcGetPFContributionData(date);
            //ViewBag.PFContributions = PFContributions;
            string comid = HttpContext.Session.GetString("comid");
            var PFContributions = db.HR_PFContribution
                .Include(s => s.HR_Emp_Info)
                .Include(s => s.HR_Emp_Info.Cat_Section)
                .Where(s => s.DtInput.Date.Month == date.Month && s.DtInput.Date.Year == date.Year && s.ComId == comid)
                .Select(s => new PFContribution
                {
                    PFContributionId = s.PFContributionId,
                    EmpId = s.EmpId,
                    EmpCode = s.HR_Emp_Info.EmpCode,
                    EmpName = s.HR_Emp_Info.EmpName,
                    Section = s.HR_Emp_Info.Cat_Section.SectName,
                    Designation = s.HR_Emp_Info.Cat_Designation.DesigName,
                    DtJoin = s.DtJoin.ToString("dd-MMM-yyyy"),
                    DtInput = s.DtInput.ToString("dd-MMM-yyyy"),
                    Amount = s.Amount,
                    PF = s.PF
                }).ToList();
            //ViewBag.PFContributions = PFContributions;
            //return PartialView("~/Views/PFContribution/_PFContributionGrid.cshtml", new PFContribution());
            return Json(PFContributions);
        }

        public class PFContribution
        {
            public int PFContributionId { get; set; }
            public int EmpId { get; set; }
            public string EmpCode { get; set; }
            public string EmpName { get; set; }
            public string DtJoin { get; set; }
            public string DtInput { get; set; }
            public string Section { get; set; }
            public string Designation { get; set; }
            public double Amount { get; set; }
            public string PF { get; set; }
        }
    }
}