using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GTERP.Controllers.HouseKeeping
{
    [OverridableAuthorize]
    public class ITComputationSettingController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public ITComputationSettingController(GTRDBContext context, TransactionLogRepository tran)
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
            return View(await db.Cat_ITComputationSetting.ToListAsync());
        }

        // GET: Section/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            //ViewBag.EmpTypeId = new SelectList(db.Cat_Emp_Type, "EmpTypeId", "EmpTypeName");
            //ViewBag.LId = new SelectList(db.Cat_Location, "LId", "LocationName");
            //ViewBag.BId = new SelectList(db.Cat_BuildingType, "BId", "BuildingName");
            return View();
        }

        // POST: Section/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cat_ITComputationSetting itComputation)
        {
            if (ModelState.IsValid)
            {
                itComputation.UserId = HttpContext.Session.GetString("userid");
                itComputation.ComId = HttpContext.Session.GetString("comid");

                itComputation.DateUpdated = DateTime.Today;

                itComputation.DateAdded = DateTime.Today;

                if (itComputation.Id > 0)
                {
                    itComputation.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(itComputation).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), itComputation.Id.ToString(), "Update", itComputation.Id.ToString());

                }
                else
                {
                    db.Add(itComputation);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), itComputation.Id.ToString(), "Create", itComputation.Id.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(itComputation);
        }

        // GET: Section/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var itComputation = await db.Cat_ITComputationSetting.FindAsync(id);

            //ViewBag.EmpTypeId = new SelectList(db.Cat_Emp_Type, "EmpTypeId", "EmpTypeName", itComputation.EmpTypeId);
            //ViewBag.LId = new SelectList(db.Cat_Location, "LId", "LocationName", itComputation.LId);
            //ViewBag.BId = new SelectList(db.Cat_BuildingType, "BId", "BuildingName", itComputation.BId);

            if (itComputation == null)
            {
                return NotFound();
            }
            return View("Create", itComputation);
        }


        // GET: Section/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itComputation = await db.Cat_ITComputationSetting
               .FirstOrDefaultAsync(m => m.Id == id);

            if (itComputation == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";


            return View("Create", itComputation);

        }

        // POST: Section/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var itComputation = await db.Cat_ITComputationSetting.FindAsync(id);
                db.Cat_ITComputationSetting.Remove(itComputation);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), itComputation.Id.ToString(), "Delete", itComputation.Id.ToString());
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, Id = itComputation.Id, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

    }
}
