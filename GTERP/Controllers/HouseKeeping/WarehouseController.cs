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
    public class WarehouseController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public WarehouseController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Warehouse
        public async Task<IActionResult> Index()
        {
            var comid = HttpContext.Session.GetString("comid");
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            return View(await db.Warehouses.Where(x => x.comid == comid).Include(x => x.Warehouses).ToListAsync());
        }

        // GET: Warehouse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var Warehouse = await db.Warehouses
            //    .FirstOrDefaultAsync(m => m.WarehouseId == id);
            var Warehouse = await db.Warehouses
                  .Include(c => c.Warehouses)
                  .FirstOrDefaultAsync(m => m.WarehouseId == id);
            if (Warehouse == null)
            {
                return NotFound();
            }

            return View(Warehouse);
        }

        // GET: Warehouse/Create
        public IActionResult Create()
        {
            var comid = HttpContext.Session.GetString("comid");

            ViewBag.Title = "Create";
            ViewBag.ParentId = new SelectList(db.Warehouses.Where(x => x.comid == comid && x.WhType == "G"), "WarehouseId", "WhName");
            return View();
        }

        // POST: Warehouse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("WarehouseId,WarehouseName,WarehouseShortName")]*/ Warehouse Warehouse)
        {

            if (ModelState.IsValid)
            {
                Warehouse.userid = HttpContext.Session.GetString("userid");
                Warehouse.comid = HttpContext.Session.GetString("comid");
                if (Warehouse.WarehouseId > 0)
                {
                    db.Entry(Warehouse).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Warehouse.WarehouseId.ToString(), "Update", Warehouse.WhName.ToString());

                }
                else
                {
                    db.Add(Warehouse);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Warehouse.WarehouseId.ToString(), "Create", Warehouse.WhName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(Warehouse);

        }

        // GET: Warehouse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var comid = HttpContext.Session.GetString("comid");

            ViewBag.Title = "Edit";
            var Warehouse = await db.Warehouses.FindAsync(id);
            ViewBag.ParentId = new SelectList(db.Warehouses.Where(x => x.comid == comid && x.WhType == "G"), "WarehouseId", "WhName", Warehouse.ParentId);
            if (Warehouse == null)
            {
                return NotFound();
            }
            return View("Create", Warehouse);

        }

        // GET: Warehouse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var comid = HttpContext.Session.GetString("comid");


            var Warehouse = await db.Warehouses
                .Include(c => c.Warehouses)
                .FirstOrDefaultAsync(m => m.WarehouseId == id);

            if (Warehouse == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            ViewBag.ParentId = new SelectList(db.Warehouses.Where(x => x.comid == comid && x.WhType == "G"), "WarehouseId", "WhName", Warehouse.ParentId);
            return View("Create", Warehouse);

        }

        // POST: Warehouse/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var Warehouse = await db.Warehouses.FindAsync(id);
                db.Warehouses.Remove(Warehouse);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Warehouse.WarehouseId.ToString(), "Delete", Warehouse.WhName);
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, WarehouseId = Warehouse.WarehouseId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool WarehouseExists(int id)
        {
            return db.Warehouses.Any(e => e.WarehouseId == id);
        }
    }
}