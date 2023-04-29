using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GTERP.Controllers.HouseKeeping
{
    [OverridableAuthorize]
    public class HRSettingController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public HRSettingController(GTRDBContext context, TransactionLogRepository tran)
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
            return View(await db.Cat_HRSetting
                .Include(s => s.Cat_Emp_Type)
                .Include(s => s.Cat_BuildingType)
                .Include(c => c.Cat_Location)
                  .ToListAsync());
        }

        // GET: Section/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.EmpTypeId = new SelectList(db.Cat_Emp_Type, "EmpTypeId", "EmpTypeName");
            ViewBag.LId = new SelectList(db.Cat_Location, "LId", "LocationName");
            ViewBag.BId = new SelectList(db.Cat_BuildingType, "BId", "BuildingName");
            return View();
        }

        // POST: Section/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cat_HRSetting hRSetting)
        {
            if (ModelState.IsValid)
            {
                hRSetting.UserId = HttpContext.Session.GetString("userid");
                hRSetting.ComId = HttpContext.Session.GetString("comid");

                hRSetting.DateUpdated = DateTime.Today;

                hRSetting.DateAdded = DateTime.Today;

                if (hRSetting.Id > 0)
                {
                    hRSetting.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(hRSetting).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), hRSetting.Id.ToString(), "Update", hRSetting.Id.ToString());

                }
                else
                {
                    db.Add(hRSetting);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), hRSetting.Id.ToString(), "Create", hRSetting.Id.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(hRSetting);
        }

        // GET: Section/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var hRSetting = await db.Cat_HRSetting.FindAsync(id);

            ViewBag.EmpTypeId = new SelectList(db.Cat_Emp_Type, "EmpTypeId", "EmpTypeName", hRSetting.EmpTypeId);
            ViewBag.LId = new SelectList(db.Cat_Location, "LId", "LocationName", hRSetting.LId);
            ViewBag.BId = new SelectList(db.Cat_BuildingType, "BId", "BuildingName", hRSetting.BId);

            if (hRSetting == null)
            {
                return NotFound();
            }
            return View("Create", hRSetting);
        }


        // GET: Section/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hRSetting = await db.Cat_HRSetting
                  .Include(c => c.Cat_Emp_Type)
                  .Include(c => c.Cat_Location)
                  .Include(c => c.Cat_BuildingType)
               .FirstOrDefaultAsync(m => m.Id == id);

            if (hRSetting == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";

            ViewBag.EmpTypeId = new SelectList(db.Cat_Emp_Type, "EmpTypeId", "EmpTypeName", hRSetting.EmpTypeId);
            ViewBag.LId = new SelectList(db.Cat_Location, "LId", "LocationName", hRSetting.LId);
            ViewBag.BId = new SelectList(db.Cat_BuildingType, "BId", "BuildingName", hRSetting.BId);

            return View("Create", hRSetting);

        }

        // POST: Section/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var hRSetting = await db.Cat_HRSetting.FindAsync(id);
                db.Cat_HRSetting.Remove(hRSetting);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), hRSetting.Id.ToString(), "Delete", hRSetting.Id.ToString());
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, Id = hRSetting.Id, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

    }
}
