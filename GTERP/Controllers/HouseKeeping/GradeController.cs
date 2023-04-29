using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HouseKeeping
{
    [OverridableAuthorize]
    public class GradeController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public GradeController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Grade
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");


            return View(await db.Cat_Grade.ToListAsync());

        }

        // GET: Grade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat_Grade = await db.Cat_Grade
                .FirstOrDefaultAsync(m => m.GradeId == id);
            if (cat_Grade == null)
            {
                return NotFound();
            }

            return View(cat_Grade);
        }

        // GET: Grade/Create
        public IActionResult Create()
        {

            ViewBag.Title = "Create";
            //ViewBag.DeptId = new SelectList(db.Cat_Department, "DeptId", "DeptName");
            return View();
        }

        // POST: Grade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GradeId,GradeName,GradeNameB,MinGS,ComId,PcName,UserId,DateAdded,UpdateByUserId,DateUpdated,DtInput,SalaryRange,TtlManpower,TtlManPowerWorker")] Cat_Grade cat_Grade)
        {


            if (ModelState.IsValid)
            {
                cat_Grade.UserId = HttpContext.Session.GetString("userid");
                cat_Grade.ComId = HttpContext.Session.GetString("comid");

                cat_Grade.DateUpdated = DateTime.Today;
                cat_Grade.DtInput = DateTime.Today;
                cat_Grade.DateAdded = DateTime.Today;
                if (cat_Grade.GradeId > 0)
                {
                    cat_Grade.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(cat_Grade).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Grade.GradeId.ToString(), "Update", cat_Grade.GradeName.ToString());

                }
                else
                {
                    db.Add(cat_Grade);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Grade.GradeId.ToString(), "Create", cat_Grade.GradeName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(cat_Grade);
        }

        // GET: Grade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var cat_Grade = await db.Cat_Grade.FindAsync(id);
            if (cat_Grade == null)
            {
                return NotFound();
            }
            return View("Create", cat_Grade);
        }


        // GET: Grade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_Grade = await db.Cat_Grade
                .FirstOrDefaultAsync(m => m.GradeId == id);
            if (Cat_Grade == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Delete";
            return View("Create", Cat_Grade);
        }

        // POST: Grade/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var Cat_Grade = await db.Cat_Grade.FindAsync(id);
                db.Cat_Grade.Remove(Cat_Grade);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Grade.GradeId.ToString(), "Delete", Cat_Grade.GradeName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, GradeId = Cat_Grade.GradeId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool Cat_GradeExists(int id)
        {
            return db.Cat_Grade.Any(e => e.GradeId == id);
        }
    }
}
