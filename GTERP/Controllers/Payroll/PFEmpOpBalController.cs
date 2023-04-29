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

namespace GTERP.Controllers.Payroll
{
    [OverridableAuthorize]
    public class PFEmpOpBalController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public PFEmpOpBalController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Section
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            //var sectio
            return View(await db.HR_Emp_PF_OPBal
                .Include(s => s.HR_Emp_Info)
                    .Include(x => x.PFChartOfAccountDebit)
                    .Include(x => x.PFChartOfAccountCredit)
                  .ToListAsync());
        }

        // GET: Section/Create
        public IActionResult Create()
        {
            string ComId = HttpContext.Session.GetString("comid");

            ViewBag.Title = "Create";

            var empInfo = (from emp in db.HR_Emp_Info
                           join ep in db.HR_Emp_PersonalInfo on emp.EmpId equals ep.EmpId
                           join d in db.Cat_Department on emp.DeptId equals d.DeptId
                           join s in db.Cat_Section on emp.SectId equals s.SectId
                           join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                           where emp.ComId == ComId & ep.IsAllowPF == true
                           select new
                           {
                               Value = emp.EmpId,
                               Text = ep.PFFileNo + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                           }).ToList();

            ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text");

            ViewBag.DebitAccId = new SelectList(db.PF_ChartOfAccounts.Where(x => x.comid == ComId && x.AccType == "L"), "AccId", "AccName");
            ViewBag.CreditAccId = new SelectList(db.PF_ChartOfAccounts.Where(x => x.comid == ComId && x.AccType == "L"), "AccId", "AccName");


            ViewBag.PFOPBalYID = new SelectList(db.Acc_FiscalYears.Where(x => x.comid == ComId), "FiscalYearId", "FYName");
            return View();
        }

        // POST: Section/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HR_Emp_PF_OPBal PFOPBal)
        {
            if (ModelState.IsValid)
            {
                PFOPBal.UserId = HttpContext.Session.GetString("userid");
                PFOPBal.ComId = HttpContext.Session.GetString("comid");

                PFOPBal.DateUpdated = DateTime.Today;

                PFOPBal.DateAdded = DateTime.Today;

                if (PFOPBal.PFOPBalId > 0)
                {
                    PFOPBal.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(PFOPBal).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), PFOPBal.PFOPBalYID.ToString(), "Update", PFOPBal.PFOPBalYID.ToString());

                }
                else
                {
                    db.Add(PFOPBal);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), PFOPBal.PFOPBalYID.ToString(), "Create", PFOPBal.PFOPBalYID.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(PFOPBal);
        }

        // GET: Section/Edit/5
        public IActionResult Edit(int? id)
        {
            string ComId = HttpContext.Session.GetString("comid");

            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var PFOPBal = db.HR_Emp_PF_OPBal.Where(m => m.PFOPBalId == id).FirstOrDefault();
            //.Include(c => c.HR_Emp_Info)
            //.Include(x => x.PFChartOfAccountDebit)
            //.Include(x => x.PFChartOfAccountCredit)
            //.FirstOrDefaultAsync(m => m.PFOPBalYID == id);
            //.FirstOrDefault(m => m.PFOPBalYID == id);

            var empInfo = (from emp in db.HR_Emp_Info
                           join ep in db.HR_Emp_PersonalInfo on emp.EmpId equals ep.EmpId
                           join d in db.Cat_Department on emp.DeptId equals d.DeptId
                           join s in db.Cat_Section on emp.SectId equals s.SectId
                           join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                           where emp.ComId == ComId & ep.IsAllowPF == true
                           select new
                           {
                               Value = emp.EmpId,
                               Text = ep.PFFileNo + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                           }).ToList();


            ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text", PFOPBal.EmpId);
            ViewData["DebitAccId"] = new SelectList(db.PF_ChartOfAccounts.Where(x => x.comid == ComId && x.AccType == "L"), "AccId", "AccName", PFOPBal.DebitAccId);
            ViewData["CreditAccId"] = new SelectList(db.PF_ChartOfAccounts.Where(x => x.comid == ComId && x.AccType == "L"), "AccId", "AccName", PFOPBal.CreditAccId);

            ViewBag.PFOPBalYID = new SelectList(db.Acc_FiscalYears.Where(x => x.comid == ComId), "FiscalYearId", "FYName", PFOPBal.PFOPBalYID);

            if (PFOPBal == null)
            {
                return NotFound();
            }
            return View("Create", PFOPBal);
        }


        // GET: Section/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            string ComId = HttpContext.Session.GetString("comid");
            if (id == null)
            {
                return NotFound();
            }

            var PFOPBal = db.HR_Emp_PF_OPBal
                  .Include(c => c.HR_Emp_Info)
                //.Include(x => x.PFChartOfAccountDebit)
                //.Include(x => x.PFChartOfAccountCredit)
                //.FirstOrDefaultAsync(m => m.PFOPBalYID == id);
                .FirstOrDefault(m => m.PFOPBalId == id);

            if (PFOPBal == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";

            var empInfo = (from emp in db.HR_Emp_Info
                           join ep in db.HR_Emp_PersonalInfo on emp.EmpId equals ep.EmpId
                           join d in db.Cat_Department on emp.DeptId equals d.DeptId
                           join s in db.Cat_Section on emp.SectId equals s.SectId
                           join des in db.Cat_Designation on emp.DesigId equals des.DesigId
                           where emp.ComId == ComId & ep.IsAllowPF == true
                           select new
                           {
                               Value = emp.EmpId,
                               Text = ep.PFFileNo + " - [ " + emp.EmpName + " ] - [ " + des.DesigName + " ] - [ " + d.DeptName + " ] - [ " + s.SectName + " ]"
                           }).ToList();

            //ViewBag.DebitAccId = new SelectList(db.PF_ChartOfAccounts.Where(x => x.comid == ComId && x.AccType == "L"), "AccId", "AccName", PFOPBal.DebitAccId);
            //ViewBag.CreditAccId = new SelectList(db.PF_ChartOfAccounts.Where(x => x.comid == ComId && x.AccType == "L"), "AccId", "AccName", PFOPBal.CreditAccId);


            ViewData["EmpId"] = new SelectList(empInfo, "Value", "Text", PFOPBal.EmpId);
            ViewBag.PFOPBalYID = new SelectList(db.Acc_FiscalYears.Where(x => x.comid == ComId), "FiscalYearId", "FYName", PFOPBal.PFOPBalYID);
            ViewData["DebitAccId"] = new SelectList(db.PF_ChartOfAccounts.Where(x => x.comid == ComId && x.AccType == "L"), "AccId", "AccName", PFOPBal.DebitAccId);
            ViewData["CreditAccId"] = new SelectList(db.PF_ChartOfAccounts.Where(x => x.comid == ComId && x.AccType == "L"), "AccId", "AccName", PFOPBal.CreditAccId);

            return View("Create", PFOPBal);

        }

        // POST: Section/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var PFOPBal = await db.HR_Emp_PF_OPBal
                    .FindAsync(id);
                db.HR_Emp_PF_OPBal.Remove(PFOPBal);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), PFOPBal.PFOPBalYID.ToString(), "Delete", PFOPBal.PFOPBalYID.ToString());
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, PFOPBalYID = PFOPBal.HR_Emp_Info.EmpId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

    }
}
