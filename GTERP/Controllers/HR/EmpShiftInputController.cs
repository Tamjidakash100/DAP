using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]
    public class EmpShiftInputController : Controller
    {
        private GTRDBContext db;
        private HrRepository repository;
        public EmpShiftInputController(GTRDBContext context, HrRepository hrRepository)
        {
            db = context;
            repository = hrRepository;
        }
        public IActionResult Index()
        {
            string comid = HttpContext.Session.GetString("comid");

            List<EmpForShit> employees = db.HR_Emp_Info
                .Include(e => e.Cat_Shift)
                .Include(e => e.Cat_Shift)
                .Include(e => e.Cat_Shift)
                .Select(e => new EmpForShit()
                {
                    ComId = e.ComId,
                    EmpId = e.EmpId,
                    EmpName = e.EmpName,
                    EmpCode = e.EmpCode,
                    Shift = e.Cat_Shift.ShiftName,
                    Department = e.Cat_Department.DeptName,
                    Section = e.Cat_Section.SectName,
                    Designation = e.Cat_Designation.DesigName
                }).Where(e => e.ComId == comid).ToList();

            ViewBag.EmployeeInfo = employees;

            ViewBag.Shift = db.Cat_Shift.Where(s => s.ComId == comid).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult EmpShiftPost(List<HR_Emp_ShiftInput> empShifts)
        {
            try
            {
                DateTime fromDate = empShifts.Select(e => e.FromDate).FirstOrDefault();
                DateTime toDate = empShifts.Select(e => e.ToDate).FirstOrDefault();
                int days = (toDate - fromDate).Days + 1;
                string comid = HttpContext.Session.GetString("comid");
                foreach (var item in empShifts)
                {

                    for (int i = 0; i < days; i++)
                    {
                        item.DtDate = fromDate.AddDays(i);
                        HR_Emp_ShiftInput old = db.HR_Emp_ShiftInput.Where(e => e.DtDate == item.DtDate && e.EmpId == item.EmpId && e.ComId == item.ComId).FirstOrDefault();
                        if (old != null)
                        {
                            db.Remove(old);
                        }
                        db.Add(item);
                    }
                    if (item.IsMain)
                    {
                        var emp = db.HR_Emp_Info.Where(e => e.EmpId == item.EmpId && e.ComId == comid).FirstOrDefault();
                        emp.ShiftId = item.ShiftId;
                        db.Entry(emp).State = EntityState.Modified;
                    }
                }
                db.SaveChanges();
                TempData["Message"] = "Employee shift create/update Successfully";
                return Json(new { Success = 1, ex = TempData["Message"].ToString() });

            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }


    }
    public class EmpForShit
    {
        public string ComId { get; set; }
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
        public string Shift { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string Designation { get; set; }
    }
}