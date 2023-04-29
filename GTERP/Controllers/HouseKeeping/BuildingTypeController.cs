using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HouseKeeping
{
    [OverridableAuthorize]

    public class BuildingTypeController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public BuildingTypeController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: BuildingType
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");
            return View(await db.Cat_BuildingType.ToListAsync());
        }

        // GET: BuildingType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingType = await db.Cat_BuildingType
                .FirstOrDefaultAsync(m => m.BId == id);
            if (buildingType == null)
            {
                return NotFound();
            }

            return View(buildingType);
        }

        // GET: BuildingType/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            //ViewBag.BId = new SelectList(db.Cat_BuildingType, "BId", "BuildingTypeName");
            return View();
        }

        // POST: BuildingType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("BId,BuildingTypeName,BuildingTypeShortName")]*/ Cat_BuildingType buildingType)
        {

            if (ModelState.IsValid)
            {
                buildingType.UserId = HttpContext.Session.GetString("userid");
                buildingType.ComId = HttpContext.Session.GetString("comid");
                if (buildingType.BId > 0)
                {
                    db.Entry(buildingType).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), buildingType.BId.ToString(), "Update", buildingType.BuildingName.ToString());

                }
                else
                {
                    db.Add(buildingType);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), buildingType.BId.ToString(), "Create", buildingType.BuildingName.ToString());
                }
                return RedirectToAction(nameof(Index));
            }
            return View(buildingType);

        }

        // GET: BuildingType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var buildingType = await db.Cat_BuildingType.FindAsync(id);
            //ViewBag.BId = new SelectList(db.Cat_BuildingType, "BId", "BuildingTypeName", BuildingType.ParentId);
            if (buildingType == null)
            {
                return NotFound();
            }
            return View("Create", buildingType);

        }

        // GET: BuildingType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingType = await db.Cat_BuildingType
                .FirstOrDefaultAsync(m => m.BId == id);

            if (buildingType == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            //ViewBag.BId = new SelectList(db.Cat_BuildingType, "BId", "BuildingTypeName", BuildingType.ParentId);
            return View("Create", buildingType);

        }

        // POST: BuildingType/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var buildingType = await db.Cat_BuildingType.FindAsync(id);
                db.Cat_BuildingType.Remove(buildingType);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), buildingType.BId.ToString(), "Delete", buildingType.BuildingName);
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, BId = buildingType.BId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool BuildingTypeExists(int id)
        {
            return db.Cat_BuildingType.Any(e => e.BId == id);
        }
    }
}