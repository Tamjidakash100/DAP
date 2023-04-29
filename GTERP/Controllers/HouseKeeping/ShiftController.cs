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
    public class ShiftController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public ShiftController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Shift
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            return View(await db.Cat_Shift.ToListAsync());
        }


        // GET: Shift/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.ShiftId = new SelectList(db.Cat_Shift, "ShiftId", "ShiftName");
            return View();
        }

        // POST: Shift/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComId,ShiftId,ShiftName,ShiftCode,ShiftDesc,ShiftIn,ShiftOut,ShiftLate,LunchTime,LunchIn,LunchOut,TiffinTime,TiffinIn,TiffinOut,RegHour,ShiftType,ShiftCat,IsInactive,TiffinTime1,TiffinTimeIn1,TiffinTime2,TiffinTimeIn2,PcName,UserId,DateAdded,UpdateByUserId,DateUpdated,DtInput")] Cat_Shift cat_Shift)
        {
            if (ModelState.IsValid)
            {
                cat_Shift.UserId = HttpContext.Session.GetString("userid");
                cat_Shift.ComId = HttpContext.Session.GetString("comid");

                if (cat_Shift.ShiftId > 0)
                {
                    db.Entry(cat_Shift).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Shift.ShiftId.ToString(), "Update", cat_Shift.ShiftName.ToString());
                }
                else
                {
                    db.Add(cat_Shift);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Shift.ShiftId.ToString(), "Create", cat_Shift.ShiftName.ToString());
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cat_Shift);
        }

        // GET: Shift/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var Cat_Shift = await db.Cat_Shift.FindAsync(id);
            ViewBag.BloodId = new SelectList(db.Cat_BloodGroup, "ShiftId", "ShiftName", Cat_Shift.ShiftId);
            if (Cat_Shift == null)
            {
                return NotFound();
            }
            return View("Create", Cat_Shift);
        }

        // GET: Shift/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat_Shift = await db.Cat_Shift
                .FirstOrDefaultAsync(m => m.ShiftId == id);
            if (cat_Shift == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            ViewBag.DeptId = new SelectList(db.Cat_Floor, "ShiftId", "ShiftName", cat_Shift.ShiftId);
            return View("Create", cat_Shift);
        }

        // POST: Shift/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var Cat_Shift = await db.Cat_Shift.FindAsync(id);
                db.Cat_Shift.Remove(Cat_Shift);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Shift.ShiftId.ToString(), "Delete", Cat_Shift.ShiftName);
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, LineId = Cat_Shift.ShiftId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool Cat_ShiftExists(int id)
        {
            return db.Cat_Shift.Any(e => e.ShiftId == id);
        }
    }
}
