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
    public class SectionController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public SectionController(GTRDBContext context, TransactionLogRepository tran)
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
            return View(await db.Cat_Section.Include(s => s.Dept).ToListAsync());
        }

        // GET: Section/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var cat_Section = await db.Cat_Section
                .Include(c => c.Dept)
                .FirstOrDefaultAsync(m => m.SectId == id);
            if (cat_Section == null)
            {
                return NotFound();
            }

            return View(cat_Section);
        }

        // GET: Section/Create
        public IActionResult Create()
        {

            ViewBag.Title = "Create";
            ViewBag.DeptId = new SelectList(db.Cat_Department, "DeptId", "DeptName");
            return View();
        }

        // POST: Section/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cat_Section cat_Section)
        {
            if (ModelState.IsValid)
            {
                cat_Section.UserId = HttpContext.Session.GetString("userid");
                cat_Section.ComId = HttpContext.Session.GetString("comid");

                cat_Section.DateUpdated = DateTime.Today;
                cat_Section.DtInput = DateTime.Today;
                cat_Section.DateAdded = DateTime.Today;

                if (cat_Section.SectId > 0)
                {
                    cat_Section.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(cat_Section).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Section.SectId.ToString(), "Update", cat_Section.SectName.ToString());

                }
                else
                {
                    db.Add(cat_Section);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Section.SectId.ToString(), "Create", cat_Section.SectName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(cat_Section);
        }

        // GET: Section/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var cat_Section = await db.Cat_Section.FindAsync(id);
            ViewBag.DeptId = new SelectList(db.Cat_Department, "DeptId", "DeptName", cat_Section.DeptId);
            if (cat_Section == null)
            {
                return NotFound();
            }
            return View("Create", cat_Section);
        }


        // GET: Section/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_Section = await db.Cat_Section
                  .Include(c => c.Dept)
               .FirstOrDefaultAsync(m => m.SectId == id);
            if (Cat_Section == null)
            {
                return NotFound();
            }


            ViewBag.Title = "Delete";
            ViewBag.DeptId = new SelectList(db.Cat_Department, "DeptId", "DeptName", Cat_Section.DeptId);


            return View("Create", Cat_Section);




        }

        // POST: Section/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var cat_Section = await db.Cat_Section.FindAsync(id);
                db.Cat_Section.Remove(cat_Section);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Section.SectId.ToString(), "Delete", cat_Section.SectName);
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, SectId = cat_Section.SectId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool Cat_SectionExists(int id)
        {
            return db.Cat_Section.Any(e => e.SectId == id);
        }
    }
}
