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
    public class ExchangeRateController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;
        public ExchangeRateController(GTRDBContext _db, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");
            return View(await db.Cat_ExchangeRate.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.ExChangeId = new SelectList(db.Cat_ExchangeRate, "ExChangeId", "ExchangeRate");
            return View();
        }

        public async Task<IActionResult> Create(Cat_ExchangeRate cat_ExchangeRate)
        {
            if (ModelState.IsValid)
            {
                cat_ExchangeRate.UserId = HttpContext.Session.GetString("userid");
                cat_ExchangeRate.ComId = HttpContext.Session.GetString("comid");
                if (cat_ExchangeRate.ExChangeId > 0)
                {
                    db.Entry(cat_ExchangeRate).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_ExchangeRate.ExChangeId.ToString(), "Update", cat_ExchangeRate.ExchangeRate.ToString());

                }
                else
                {
                    db.Add(cat_ExchangeRate);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_ExchangeRate.ExChangeId.ToString(), "Create", cat_ExchangeRate.ExchangeRate.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(cat_ExchangeRate);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var cat_ExchangeRate = await db.Cat_ExchangeRate.FindAsync(id);
            ViewBag.ExChangeId = new SelectList(db.Cat_ExchangeRate, "ExChangeId", "ExchangeRate", cat_ExchangeRate.ExChangeId);
            if (cat_ExchangeRate == null)
            {
                return NotFound();
            }
            return View("Create", cat_ExchangeRate);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat_ExchangeRate = await db.Cat_ExchangeRate
                .FirstOrDefaultAsync(m => m.ExChangeId == id);

            if (cat_ExchangeRate == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            ViewBag.ExChangeId = new SelectList(db.Cat_ExchangeRate, "ExChangeId", "ExchangeRate", cat_ExchangeRate.ExChangeId);
            return View("Create", cat_ExchangeRate);
        }
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var cat_ExchangeRate = await db.Cat_ExchangeRate.FindAsync(id);
                db.Cat_ExchangeRate.Remove(cat_ExchangeRate);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_ExchangeRate.ExChangeId.ToString(), "Delete", cat_ExchangeRate.ExchangeRate.ToString());

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, ExChangeId = cat_ExchangeRate.ExChangeId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool cat_ExchangeRateExists(int id)
        {
            return db.Cat_ExchangeRate.Any(e => e.ExChangeId == id);
        }
    }
}