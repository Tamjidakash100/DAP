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
    public class HRExpSettingController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public HRExpSettingController(GTRDBContext context, TransactionLogRepository tran)
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
            return View(await db.Cat_HRExpSetting.Include(s => s.Cat_Emp_Type).Include(c => c.Cat_Location)
                  .Include(c => c.Cat_BuildingType).ToListAsync());
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
        public async Task<IActionResult> Create(Cat_HRExpSetting hRExpSetting)
        {
            if (ModelState.IsValid)
            {
                hRExpSetting.UserId = HttpContext.Session.GetString("userid");
                hRExpSetting.ComId = HttpContext.Session.GetString("comid");

                hRExpSetting.DateUpdated = DateTime.Today;

                hRExpSetting.DateAdded = DateTime.Today;

                if (hRExpSetting.Id > 0)
                {
                    hRExpSetting.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(hRExpSetting).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), hRExpSetting.Id.ToString(), "Update", hRExpSetting.Id.ToString());

                }
                else
                {
                    db.Add(hRExpSetting);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), hRExpSetting.Id.ToString(), "Create", hRExpSetting.Id.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(hRExpSetting);
        }

        // GET: Section/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var hRExpSetting = await db.Cat_HRExpSetting.FindAsync(id);

            ViewBag.EmpTypeId = new SelectList(db.Cat_Emp_Type, "EmpTypeId", "EmpTypeName", hRExpSetting.EmpTypeId);
            ViewBag.LId = new SelectList(db.Cat_Location, "LId", "LocationName", hRExpSetting.LId);
            ViewBag.BId = new SelectList(db.Cat_BuildingType, "BId", "BuildingName", hRExpSetting.BId);

            if (hRExpSetting == null)
            {
                return NotFound();
            }
            return View("Create", hRExpSetting);
        }


        // GET: Section/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hRExpSetting = await db.Cat_HRExpSetting
                  .Include(c => c.Cat_Emp_Type)
                  .Include(c => c.Cat_Location)
                  .Include(c => c.Cat_BuildingType)
               .FirstOrDefaultAsync(m => m.Id == id);

            if (hRExpSetting == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";

            ViewBag.EmpTypeId = new SelectList(db.Cat_Emp_Type, "EmpTypeId", "EmpTypeName", hRExpSetting.EmpTypeId);
            ViewBag.LId = new SelectList(db.Cat_Location, "LId", "LocationName", hRExpSetting.LId);
            ViewBag.BId = new SelectList(db.Cat_BuildingType, "BId", "BuildingName", hRExpSetting.BId);

            return View("Create", hRExpSetting);

        }

        // POST: Section/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var hRExpSetting = await db.Cat_HRExpSetting.FindAsync(id);
                db.Cat_HRExpSetting.Remove(hRExpSetting);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), hRExpSetting.Id.ToString(), "Delete", hRExpSetting.Id.ToString());
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, Id = hRExpSetting.Id, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

    }
}
