using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HouseKeeping
{
    [OverridableAuthorize]
    public class HRReportController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public HRReportController(GTRDBContext context, TransactionLogRepository tran)
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
            return View(await db.HR_ReportType.ToListAsync());
        }


        // GET: Section/Create
        public IActionResult Create()
        {
            string comid = HttpContext.Session.GetString("comid");
            ViewBag.Title = "Create";
            //ViewBag.ReportType = new SelectList(db.HR_ReportType
            //    .Where(v => v.ComId==comid).GroupBy(v=>v.ReportType), "ReportType", "ReportType");
            var data = db.HR_ReportType.GroupBy(p => p.ReportType)
                          .Select(g => new
                          {
                              ReportType = g.Key,
                              Count = g.Count()
                          })
                          .ToList();
            ViewBag.ReportType = new SelectList(data, "ReportType", "ReportType");


            return View();
        }

        // POST: Section/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HR_ReportType HR_ReportType)
        {
            if (ModelState.IsValid)
            {
                HR_ReportType.UserId = HttpContext.Session.GetString("userid");
                HR_ReportType.ComId = HttpContext.Session.GetString("comid");


                if (HR_ReportType.ReportId > 0)
                {
                    db.Entry(HR_ReportType).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), HR_ReportType.ReportId.ToString(), "Update", HR_ReportType.ReportName);

                }
                else
                {
                    db.Add(HR_ReportType);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), HR_ReportType.ReportId.ToString(), "Create", HR_ReportType.ReportName);

                }
                return RedirectToAction(nameof(Index));
            }
            return View(HR_ReportType);
        }

        // GET: Section/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var HR_ReportType = await db.HR_ReportType.FindAsync(id);
            ViewBag.DeptId = new SelectList(db.Cat_Department, "DeptId", "DeptName", HR_ReportType.ReportId);
            if (HR_ReportType == null)
            {
                return NotFound();
            }
            var data = db.HR_ReportType.GroupBy(p => p.ReportType)
                          .Select(g => new
                          {
                              ReportType = g.Key,
                              Count = g.Count()
                          })
                          .ToList();
            ViewBag.ReportType = new SelectList(data, "ReportType", "ReportType", HR_ReportType.ReportType);
            return View("Create", HR_ReportType);
        }


        // GET: Section/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var HR_ReportType = await db.HR_ReportType
               .FirstOrDefaultAsync(m => m.ReportId == id);
            if (HR_ReportType == null)
            {
                return NotFound();
            }


            ViewBag.Title = "Delete";
            var data = db.HR_ReportType.GroupBy(p => p.ReportType)
                          .Select(g => new
                          {
                              ReportType = g.Key,
                              Count = g.Count()
                          })
                          .ToList();
            ViewBag.ReportType = new SelectList(data, "ReportType", "ReportType", HR_ReportType.ReportType);

            return View("Create", HR_ReportType);




        }

        // POST: Section/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var HR_ReportType = await db.HR_ReportType.FindAsync(id);
                db.HR_ReportType.Remove(HR_ReportType);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), HR_ReportType.ReportId.ToString(), "Delete", HR_ReportType.ReportName);
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, ReportId = HR_ReportType.ReportId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool HR_ReportTypeExists(int id)
        {
            return db.HR_ReportType.Any(e => e.ReportId == id);
        }
    }
}
