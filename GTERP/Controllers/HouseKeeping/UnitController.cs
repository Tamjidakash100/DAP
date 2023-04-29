using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace GTERP.Controllers.HouseKeeping
{
    [OverridableAuthorize]
    public class UnitController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public UnitController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Unit
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");


            return View(await db.Unit.ToListAsync());
        }

        // GET: Unit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Unit = await db.Unit
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (Unit == null)
            {
                return NotFound();
            }

            return View(Unit);
        }

        // GET: Unit/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            //ViewBag.UnitId = new SelectList(db.Unit, "UnitId", "UnitName");
            return View();
        }

        // POST: Unit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("UnitId,UnitName,UnitShortName")]*/ Unit Unit)
        {

            if (ModelState.IsValid)
            {
                //Unit.UserId = HttpContext.Session.GetString("userid");
                //Unit.ComId = HttpContext.Session.GetString("comid");
                if (Unit.UnitId > 0)
                {
                    db.Entry(Unit).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Unit.UnitId.ToString(), "Update", Unit.UnitName.ToString());

                }
                else
                {
                    db.Add(Unit);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Unit.UnitId.ToString(), "Create", Unit.UnitName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(Unit);

        }

        // GET: Unit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var Unit = await db.Unit.FindAsync(id);
            //ViewBag.UnitId = new SelectList(db.Unit, "UnitId", "UnitName", Unit.ParentId);
            if (Unit == null)
            {
                return NotFound();
            }
            return View("Create", Unit);

        }

        // GET: Unit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Unit = await db.Unit
                .FirstOrDefaultAsync(m => m.UnitId == id);

            if (Unit == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            //ViewBag.UnitId = new SelectList(db.Unit, "UnitId", "UnitName", Unit.ParentId);
            return View("Create", Unit);

        }

        // POST: Unit/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var Unit = await db.Unit.FindAsync(id);
                db.Unit.Remove(Unit);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Unit.UnitId.ToString(), "Delete", Unit.UnitName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, UnitId = Unit.UnitId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool UnitExists(int id)
        {
            return db.Unit.Any(e => e.UnitId == id);
        }
    }
}
