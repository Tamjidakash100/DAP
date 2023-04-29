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
    public class ElectricChargeSettingController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public ElectricChargeSettingController(GTRDBContext context, TransactionLogRepository tran)
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
            return View(await db.Cat_ElectricChargeSetting.Include(c => c.Cat_Location)
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
        public async Task<IActionResult> Create(Cat_ElectricChargeSetting electricChargeSetting)
        {
            if (ModelState.IsValid)
            {
                electricChargeSetting.UserId = HttpContext.Session.GetString("userid");
                electricChargeSetting.ComId = HttpContext.Session.GetString("comid");

                electricChargeSetting.DateUpdated = DateTime.Today;

                electricChargeSetting.DateAdded = DateTime.Today;

                if (electricChargeSetting.Id > 0)
                {
                    electricChargeSetting.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(electricChargeSetting).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), electricChargeSetting.Id.ToString(), "Update", electricChargeSetting.Id.ToString());

                }
                else
                {
                    db.Add(electricChargeSetting);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), electricChargeSetting.Id.ToString(), "Create", electricChargeSetting.Id.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(electricChargeSetting);
        }

        // GET: Section/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var electricChargeSetting = await db.Cat_ElectricChargeSetting.FindAsync(id);

            // ViewBag.EmpTypeId = new SelectList(db.Cat_Emp_Type, "EmpTypeId", "EmpTypeName", electricChargeSetting.EmpTypeId);
            ViewBag.LId = new SelectList(db.Cat_Location, "LId", "LocationName", electricChargeSetting.LId);
            ViewBag.BId = new SelectList(db.Cat_BuildingType, "BId", "BuildingName", electricChargeSetting.BId);

            if (electricChargeSetting == null)
            {
                return NotFound();
            }
            return View("Create", electricChargeSetting);
        }


        // GET: Section/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electricChargeSetting = await db.Cat_ElectricChargeSetting
                  .Include(c => c.Cat_Location)
                  .Include(c => c.Cat_BuildingType)
               .FirstOrDefaultAsync(m => m.Id == id);

            if (electricChargeSetting == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";

            // ViewBag.EmpTypeId = new SelectList(db.Cat_Emp_Type, "EmpTypeId", "EmpTypeName", electricChargeSetting.EmpTypeId);
            ViewBag.LId = new SelectList(db.Cat_Location, "LId", "LocationName", electricChargeSetting.LId);
            ViewBag.BId = new SelectList(db.Cat_BuildingType, "BId", "BuildingName", electricChargeSetting.BId);

            return View("Create", electricChargeSetting);

        }

        // POST: Section/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var electricChargeSetting = await db.Cat_ElectricChargeSetting.FindAsync(id);
                db.Cat_ElectricChargeSetting.Remove(electricChargeSetting);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), electricChargeSetting.Id.ToString(), "Delete", electricChargeSetting.Id.ToString());
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, Id = electricChargeSetting.Id, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

    }
}
