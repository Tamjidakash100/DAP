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
    public class BusStopController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;
        public BusStopController(GTRDBContext _db, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            return View(await db.Cat_BusStop.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.BusStopId = new SelectList(db.Cat_BusStop, "BusStopId", "BusStopName");
            return View();
        }

        public async Task<IActionResult> Create(Cat_BusStop cat_Busstop)
        {
            if (ModelState.IsValid)
            {
                cat_Busstop.UserId = HttpContext.Session.GetString("userid");
                cat_Busstop.ComId = HttpContext.Session.GetString("comid");
                if (cat_Busstop.BusStopId > 0)
                {
                    db.Entry(cat_Busstop).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Busstop.BusStopId.ToString(), "Update", cat_Busstop.BusStopName.ToString());
                }
                else
                {
                    db.Add(cat_Busstop);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Busstop.BusStopId.ToString(), "Create", cat_Busstop.BusStopName.ToString());
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cat_Busstop);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var cat_Busstop = await db.Cat_BusStop.FindAsync(id);
            ViewBag.BusStopId = new SelectList(db.Cat_BusStop, "BusStopId", "BusStopName", cat_Busstop.BusStopId);
            if (cat_Busstop == null)
            {
                return NotFound();
            }
            return View("Create", cat_Busstop);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat_Busstop = await db.Cat_BusStop
                .FirstOrDefaultAsync(m => m.BusStopId == id);

            if (cat_Busstop == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            ViewBag.BusStopId = new SelectList(db.Cat_BusStop, "BusStopId", "BusStopName", cat_Busstop.BusStopId);
            return View("Create", cat_Busstop);
        }
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var cat_Busstop = await db.Cat_BusStop.FindAsync(id);
                db.Cat_BusStop.Remove(cat_Busstop);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Busstop.BusStopId.ToString(), "Delete", cat_Busstop.BusStopName);
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, BusStopId = cat_Busstop.BusStopId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool cat_BusStopExists(int id)
        {
            return db.Cat_BusStop.Any(e => e.BusStopId == id);
        }
    }
}
