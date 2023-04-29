using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]

    public class SupplimentController : Controller
    {
        GTRDBContext db;
        public SupplimentController(GTRDBContext context)
        {
            db = context;
        }
        public IActionResult Index(DateTime? dtInput, int? sectId)
        {
            string comid = HttpContext.Session.GetString("comid");

            ViewBag.SectId = new SelectList(db.Cat_Section.Where(s => s.ComId == comid), "SectId", "SectName");
            ViewBag.Suppliments = null;

            if (dtInput == null && sectId == 0)
            {
                var data = db.HR_Emp_Salary.Include(e => e.HR_Emp_Info).Include(e => e.HR_Emp_Info.Cat_Designation)
               .Select(s => new SupplimentViewModel
               {
                   EmpId = s.HR_Emp_Info.EmpId,
                   EmpName = s.HR_Emp_Info.EmpName,
                   EmpCode = s.HR_Emp_Info.EmpCode,
                   Designation = s.HR_Emp_Info.Cat_Designation.DesigName,
                   Basic = s.BasicSalary,
                   DtFrom = DateTime.Now.Date,
                   DtTo = DateTime.Now.Date

               }).ToList();
                ViewBag.Suppliments = data;
            }
            if (dtInput == null && sectId > 0)
            {
                var data = db.HR_Emp_Salary.Include(e => e.HR_Emp_Info).Include(e => e.HR_Emp_Info.Cat_Designation)
               .Select(s => new SupplimentViewModel
               {
                   EmpId = s.HR_Emp_Info.EmpId,
                   EmpName = s.HR_Emp_Info.EmpName,
                   EmpCode = s.HR_Emp_Info.EmpCode,
                   SectId = s.HR_Emp_Info.SectId,
                   Designation = s.HR_Emp_Info.Cat_Designation.DesigName,
                   Basic = s.BasicSalary,
                   DtFrom = DateTime.Now.Date,
                   DtTo = DateTime.Now.Date

               }).Where(s => s.SectId == sectId).ToList();
                ViewBag.Suppliments = data;
            }
            else if (dtInput != null && sectId == 0)
            {
                var data = db.HR_Emp_Suppliment.Include(e => e.HR_Emp_Info).ThenInclude(e => e.Cat_Designation)
                  .Select(s => new SupplimentViewModel
                  {
                      EmpId = s.HR_Emp_Info.EmpId,
                      EmpName = s.HR_Emp_Info.EmpName,
                      EmpCode = s.HR_Emp_Info.EmpCode,
                      Designation = s.HR_Emp_Info.Cat_Designation.DesigName,
                      Basic = s.Basic,
                      Duration = s.Duration,

                      DtInput = s.DtInput,
                      DtFrom = s.DtFrom,
                      DtTo = s.DtTo,
                      IsBS = s.IsBS,
                      IsHR = s.IsHR,
                      IsWash = s.IsWash,
                      IsMA = s.IsMA,
                      IsCPF = s.IsCPF,
                      IsRisk = s.IsRisk,
                      IsEdu = s.IsEdu,
                      IsHRExpDed = s.IsHRExpDed,
                      Persantage = s.Persantage,
                      IsOPF = s.IsOPF,
                      IsAddPF = s.IsAddPF,
                      IsOA = s.IsOA,
                      IsWFSub = s.IsWFSub


                  }).Where(s => s.DtInput.Month == dtInput.Value.Month).ToList();
                ViewBag.Suppliments = data;
            }
            else if (dtInput != null && sectId > 0)
            {
                var data = db.HR_Emp_Suppliment.Include(e => e.HR_Emp_Info).Include(e => e.HR_Emp_Info.Cat_Designation)
                 .Select(s => new SupplimentViewModel
                 {
                     EmpId = s.HR_Emp_Info.EmpId,
                     EmpName = s.HR_Emp_Info.EmpName,
                     EmpCode = s.HR_Emp_Info.EmpCode,
                     Designation = s.HR_Emp_Info.Cat_Designation.DesigName,
                     SectId = s.HR_Emp_Info.SectId,
                     Basic = s.Basic,
                     Duration = s.Duration,
                     DtInput = s.DtInput,
                     DtFrom = s.DtFrom,
                     DtTo = s.DtTo,
                     IsBS = s.IsBS,
                     IsHR = s.IsHR,
                     IsWash = s.IsWash,
                     IsMA = s.IsMA,
                     IsCPF = s.IsCPF,
                     IsRisk = s.IsRisk,
                     IsEdu = s.IsEdu,
                     IsHRExpDed = s.IsHRExpDed,
                     Persantage = s.Persantage,
                     IsOPF = s.IsOPF,
                     IsAddPF = s.IsAddPF,
                     IsOA = s.IsOA,
                     IsWFSub = s.IsWFSub

                 }).Where(s => s.DtInput.Month == dtInput.Value.Month && s.SectId == sectId).ToList();
                ViewBag.Suppliments = data;
            }


            return View();
        }


        [HttpPost]
        public IActionResult Create(List<HR_Emp_Suppliment> suppliments)
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
               .Select(x => new { x.Key, x.Value.Errors });

                if (ModelState.IsValid)
                {
                    foreach (var item in suppliments)
                    {
                        var exist = db.HR_Emp_Suppliment.Where(o => o.EmpId == item.EmpId && o.DtInput.Month == item.DtInput.Month).FirstOrDefault();
                        if (exist != null)
                        {
                            db.HR_Emp_Suppliment.Remove(exist);

                        }
                        //db.SaveChanges();
                        db.Add(item);

                    }

                    db.SaveChanges();

                    TempData["Message"] = "Suppliment Save/Update Successfully";
                    return Json(new { Success = 1, ex = TempData["Message"].ToString() });
                }
                TempData["Message"] = "Some thing wrong, Check data";
                return Json(new { Success = 3, ex = TempData["Message"].ToString() });
            }
            catch (Exception e)
            {
                TempData["Message"] = "Please contact software authority";
                return Json(new { Success = 3, ex = TempData["Message"].ToString() });
            }
        }







        public class SupplimentViewModel
        {
            public int SupplimentId { get; set; }

            public int EmpId { get; set; }
            public int SectId { get; set; }
            public string EmpName { get; set; }
            public string EmpCode { get; set; }
            public string Designation { get; set; }
            public DateTime DtInput { get; set; }
            public DateTime DtFrom { get; set; }
            public DateTime DtTo { get; set; }
            public int Duration { get; set; }
            public float Basic { get; set; }
            public bool IsBS { get; set; } = true;
            public bool IsHR { get; set; } = true;
            public bool IsWash { get; set; } = true;
            public bool IsMA { get; set; } = true;
            public bool IsCPF { get; set; } = true;
            public bool IsRisk { get; set; } = true;
            public bool IsEdu { get; set; } = true;
            public bool IsHRExpDed { get; set; } = true;
            public int Persantage { get; set; }
            public bool IsOPF { get; set; } = true;
            public bool IsAddPF { get; set; } = true;
            public bool IsOA { get; set; } = true;
            public bool IsWFSub { get; set; } = true;
            public bool IsRS { get; set; } = true;
            public bool IsHBLoan { get; set; } = true;
            public bool IsMCLoan { get; set; } = true;

        }
    }
}