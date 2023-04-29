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
    public class PostOfficeController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public PostOfficeController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: postoffice
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            return View(await db.Cat_PostOffice.Include(s => s.Cat_District).Include(s => s.Cat_PoliceStation).ToListAsync());
        }

        [HttpGet]
        public IActionResult GetPoliceStation(int id)
        {
            string comid = HttpContext.Session.GetString("comid");
            var data = db.Cat_PoliceStation.Where(p => p.DistId == id).ToList();
            return Json(data);
        }

        // GET: postoffice/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.DistId = new SelectList(db.Cat_District, "DistId", "DistName");
            return View();
        }

        // POST: postoffice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("POId,POName,postofficeShortName")]*/ Cat_PostOffice postoffice)
        {

            if (ModelState.IsValid)
            {
                postoffice.UserId = HttpContext.Session.GetString("userid");
                postoffice.ComId = HttpContext.Session.GetString("comid");
                if (postoffice.POId > 0)
                {
                    db.Entry(postoffice).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), postoffice.POId.ToString(), "Update", postoffice.POName.ToString());

                }
                else
                {
                    db.Add(postoffice);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), postoffice.POId.ToString(), "Create", postoffice.POName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(postoffice);

        }

        // GET: postoffice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var postoffice = await db.Cat_PostOffice.FindAsync(id);
            ViewBag.DistId = new SelectList(db.Cat_District, "DistId", "DistName", postoffice.DistId);
            ViewBag.PStationId = new SelectList(db.Cat_PoliceStation.Where(p => p.DistId == postoffice.DistId), "PStationId", "PStationName", postoffice.PStationId);
            if (postoffice == null)
            {
                return NotFound();
            }
            return View("Create", postoffice);

        }

        // GET: postoffice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postoffice = await db.Cat_PostOffice
                .Include(c => c.Cat_District)
                .FirstOrDefaultAsync(m => m.POId == id);

            if (postoffice == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            ViewBag.DistId = new SelectList(db.Cat_District, "DistId", "DistName", postoffice.DistId);
            ViewBag.PStationId = new SelectList(db.Cat_PoliceStation.Where(p => p.DistId == postoffice.DistId), "PStationId", "PStationName", postoffice.PStationId);
            return View("Create", postoffice);

        }

        // POST: postoffice/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var postoffice = await db.Cat_PostOffice.FindAsync(id);
                db.Cat_PostOffice.Remove(postoffice);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), postoffice.POId.ToString(), "Delete", postoffice.POName);
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, POId = postoffice.POId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool PostOfficeExists(int id)
        {
            return db.Cat_PostOffice.Any(e => e.POId == id);
        }
    }
}
