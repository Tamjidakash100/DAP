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
    public class PoliceStationController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public PoliceStationController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: policestation
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            return View(await db.Cat_PoliceStation.Include(s => s.Cat_District).ToListAsync());
        }

        // GET: policestation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var policestation = await db.Cat_PoliceStation
            //    .FirstOrDefaultAsync(m => m.PStationId == id);
            var policestation = await db.Cat_PoliceStation
                  .Include(c => c.Cat_District)
                  .FirstOrDefaultAsync(m => m.PStationId == id);
            if (policestation == null)
            {
                return NotFound();
            }

            return View(policestation);
        }

        // GET: policestation/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.DistId = new SelectList(db.Cat_District, "DistId", "DistName");
            return View();
        }

        // POST: policestation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("PStationId,policestationName,policestationShortName")]*/ Cat_PoliceStation policestation)
        {

            if (ModelState.IsValid)
            {
                policestation.UserId = HttpContext.Session.GetString("userid");
                policestation.ComId = HttpContext.Session.GetString("comid");
                if (policestation.PStationId > 0)
                {
                    db.Entry(policestation).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), policestation.PStationId.ToString(), "Update", policestation.PStationName.ToString());

                }
                else
                {
                    db.Add(policestation);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), policestation.PStationId.ToString(), "Create", policestation.PStationName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(policestation);

        }

        // GET: policestation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var policestation = await db.Cat_PoliceStation.FindAsync(id);
            ViewBag.DistId = new SelectList(db.Cat_District, "DistId", "DistName", policestation.DistId);
            if (policestation == null)
            {
                return NotFound();
            }
            return View("Create", policestation);

        }

        // GET: policestation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policestation = await db.Cat_PoliceStation
                .Include(c => c.Cat_District)
                .FirstOrDefaultAsync(m => m.PStationId == id);

            if (policestation == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            ViewBag.DistId = new SelectList(db.Cat_District, "DistId", "DistName", policestation.DistId);
            return View("Create", policestation);

        }

        // POST: policestation/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var policestation = await db.Cat_PoliceStation.FindAsync(id);
                db.Cat_PoliceStation.Remove(policestation);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), policestation.PStationId.ToString(), "Delete", policestation.PStationName);
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, PStationId = policestation.PStationId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool PoliceStationExists(int id)
        {
            return db.Cat_PoliceStation.Any(e => e.PStationId == id);
        }
    }
}