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
    public class Cat_UnitController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public Cat_UnitController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Cat_Unit
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");


            return View(await db.Cat_Unit.ToListAsync());
        }

        // GET: Cat_Unit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_Unit = await db.Cat_Unit
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (Cat_Unit == null)
            {
                return NotFound();
            }

            return View(Cat_Unit);
        }

        // GET: Cat_Unit/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            //ViewBag.UnitId = new SelectList(db.Cat_Unit, "UnitId", "UnitName");
            return View();
        }

        // POST: Cat_Unit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("UnitId,UnitName,Cat_UnitShortName")]*/ Cat_Unit Cat_Unit)
        {

            if (ModelState.IsValid)
            {
                Cat_Unit.UserId = HttpContext.Session.GetString("userid");
                Cat_Unit.ComId = HttpContext.Session.GetString("comid");
                if (Cat_Unit.UnitId > 0)
                {
                    db.Entry(Cat_Unit).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Unit.UnitId.ToString(), "Update", Cat_Unit.UnitName.ToString());

                }
                else
                {
                    db.Add(Cat_Unit);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Unit.UnitId.ToString(), "Create", Cat_Unit.UnitName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(Cat_Unit);

        }

        // GET: Cat_Unit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var Cat_Unit = await db.Cat_Unit.FindAsync(id);
            //ViewBag.UnitId = new SelectList(db.Cat_Unit, "UnitId", "UnitName", Cat_Unit.ParentId);
            if (Cat_Unit == null)
            {
                return NotFound();
            }
            return View("Create", Cat_Unit);

        }

        // GET: Cat_Unit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_Unit = await db.Cat_Unit
                .FirstOrDefaultAsync(m => m.UnitId == id);

            if (Cat_Unit == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            //ViewBag.UnitId = new SelectList(db.Cat_Unit, "UnitId", "UnitName", Cat_Unit.ParentId);
            return View("Create", Cat_Unit);

        }

        // POST: Cat_Unit/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var Cat_Unit = await db.Cat_Unit.FindAsync(id);
                db.Cat_Unit.Remove(Cat_Unit);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Unit.UnitId.ToString(), "Delete", Cat_Unit.UnitName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, UnitId = Cat_Unit.UnitId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool Cat_UnitExists(int id)
        {
            return db.Cat_Unit.Any(e => e.UnitId == id);
        }
    }
}
