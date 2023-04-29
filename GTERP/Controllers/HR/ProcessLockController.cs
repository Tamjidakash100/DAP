using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]
    public class ProcessLockController : Controller
    {
        private readonly GTRDBContext db;

        public ProcessLockController(GTRDBContext context)
        {
            db = context;
        }

        // GET: ProcessLock
        public async Task<IActionResult> Index()
        {
            return View(await db.HR_ProcessLock.ToListAsync());
        }

        // GET: ProcessLock/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var HR_ProcessLock = await db.HR_ProcessLock
                .FirstOrDefaultAsync(m => m.ProcessId == id);
            if (HR_ProcessLock == null)
            {
                return NotFound();
            }

            return View(HR_ProcessLock);
        }

        // GET: ProcessLock/Create
        public IActionResult Create()
        {
            var comid = HttpContext.Session.GetString("comid");

            ViewBag.Title = "Create";

            ViewBag.LockType = new SelectList(db.Cat_Variable
                .Where(v => v.ComId == comid && v.VarType == "ProcessLock")
                .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");


            var fiscalYear = db.Acc_FiscalYears.Where(f => f.isRunning == true && f.isWorking == true).FirstOrDefault();
            if (fiscalYear != null)
            {
                var fiscalMonth = db.Acc_FiscalMonths.Where(f => f.OpeningdtFrom.Date <= DateTime.Now.Date && f.ClosingdtTo >= DateTime.Now.Date).FirstOrDefault();

                ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", fiscalYear.FiscalYearId);
                ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.Where(x => x.FYId == fiscalYear.FYId).OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName", fiscalMonth.FiscalMonthId);

            }
            else
            {
                ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName");
                ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.Where(x => x.FYId == fiscalYear.FiscalYearId).OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName");
            }

            return View();
        }

        // POST: ProcessLock/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ProcessId,ComId,LockType,DtDate,IsLock,PcName,UserId,DtTran")] HR_ProcessLock hR_ProcessLock)
        public async Task<IActionResult> Create(HR_ProcessLock HR_ProcessLock)
        {

            string comid = HttpContext.Session.GetString("comid");

            if (ModelState.IsValid)
            {

                HR_ProcessLock.ComId = HttpContext.Session.GetString("comid");

                if (HR_ProcessLock.ProcessId > 0)
                {
                    HR_ProcessLock.DateUpdated = DateTime.Now;
                    HR_ProcessLock.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(HR_ProcessLock).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    HR_ProcessLock.UserId = HttpContext.Session.GetString("userid");
                    HR_ProcessLock.DateAdded = DateTime.Now;
                    db.Add(HR_ProcessLock);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }


            ViewBag.LockType = new SelectList(db.Cat_Variable
               .Where(v => v.ComId == comid && v.VarType == "ProcessLock")
               .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            return View(HR_ProcessLock);
        }

        // GET: ProcessLock/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var comid = HttpContext.Session.GetString("comid");
            ViewBag.Title = "Edit";
            var HR_ProcessLock = await db.HR_ProcessLock.FindAsync(id);
            //ViewBag.EmpId = new SelectList(db.HR_Emp_Info, "EmpId", "EmpName", HR_Emp_Released.EmpId);
            //ViewBag.EmpId = new SelectList(db.HR_Emp_Info
            //    .Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
            //    .ToList(), "Value", "Text", HR_Emp_Released.EmpId);

            ViewBag.LockType = new SelectList(db.Cat_Variable
               .Where(v => v.ComId == comid && v.VarType == "ProcessLock")
               .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName", HR_ProcessLock.LockType);
            if (HR_ProcessLock == null)
            {
                return NotFound();
            }

            ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", HR_ProcessLock.FiscalYearId);
            ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.Where(x => x.FYId == HR_ProcessLock.FiscalYearId).OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName", HR_ProcessLock.FiscalMonthId);


            return View("Create", HR_ProcessLock);

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var hR_ProcessLock = await _context.HR_ProcessLock.FindAsync(id);
            //if (hR_ProcessLock == null)
            //{
            //    return NotFound();
            //}
            //return View(hR_ProcessLock);
        }

        // POST: ProcessLock/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ProcessId,ComId,LockType,DtDate,IsLock,PcName,UserId,DtTran")] HR_ProcessLock hR_ProcessLock)
        //{
        //    if (id != hR_ProcessLock.ProcessId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(hR_ProcessLock);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!HR_ProcessLockExists(hR_ProcessLock.ProcessId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(hR_ProcessLock);
        //}

        // GET: ProcessLock/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var comid = HttpContext.Session.GetString("comid");
            var HR_ProcessLock = await db.HR_ProcessLock
                .FirstOrDefaultAsync(m => m.ProcessId == id);
            if (HR_ProcessLock == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";


            ViewBag.LockType = new SelectList(db.Cat_Variable
              .Where(v => v.ComId == comid && v.VarType == "ProcessLock")
              .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName", HR_ProcessLock.LockType);

            ViewBag.FiscalYearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(y => y.FYName), "FiscalYearId", "FYName", HR_ProcessLock.FiscalYearId);
            ViewBag.FiscalMonthId = new SelectList(db.Acc_FiscalMonths.Where(x => x.FYId == HR_ProcessLock.FiscalYearId).OrderByDescending(y => y.MonthName), "FiscalMonthId", "MonthName", HR_ProcessLock.FiscalMonthId);


            return View("Create", HR_ProcessLock);

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var hR_ProcessLock = await _context.HR_ProcessLock
            //    .FirstOrDefaultAsync(m => m.ProcessId == id);
            //if (hR_ProcessLock == null)
            //{
            //    return NotFound();
            //}

            //return View(hR_ProcessLock);
        }

        // POST: ProcessLock/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var hR_ProcessLock = await _context.HR_ProcessLock.FindAsync(id);
            //_context.HR_ProcessLock.Remove(hR_ProcessLock);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            try
            {
                var HR_ProcessLock = await db.HR_ProcessLock.FindAsync(id);
                db.HR_ProcessLock.Remove(HR_ProcessLock);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, RelId = HR_ProcessLock.ProcessId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }


        [HttpGet]
        public IActionResult GetFiscalMonth(int FiscalYearId)
        {
            string comid = HttpContext.Session.GetString("comid");
            var data = db.Acc_FiscalMonths.OrderByDescending(y => y.MonthName).Where(m => m.FYId == FiscalYearId).ToList();

            //var filterAccount = db.Acc_ChartOfAccounts.Where(
            //    acc => db.BudgetDetails
            //        .Any(a => a.AccId == acc.AccId && (a.BudgetDebit + a.BudgetCredit) > 0 && a.BudgetMain.FiscalYearId == FiscalYearId)
            //    && acc.comid == comid).Distinct();
            //var accHead = filterAccount.Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList();


            return Json(new { Month = data });
        }

        private bool HR_ProcessLockExists(int id)
        {
            return db.HR_ProcessLock.Any(e => e.ProcessId == id);
        }
    }
}
