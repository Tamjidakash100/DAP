using GTERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace GTERP.Controllers
{
    [OverridableAuthorize]
    public class UnitMastersController : Controller
    {
        private GTRDBContext db;
        public UnitMastersController(GTRDBContext context)
        {
            db = context;
        }

        // GET: UnitMasters
        //[OverridableAuthorize]
        public ActionResult Index()
        {
            var unitMasters = db.UnitMasters.Include(u => u.UnitGroup);
            return View(unitMasters.ToList());
        }
        // GET: UnitMasters/Create
        //[OverridableAuthorize]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.UnitGroupId = new SelectList(db.UnitGroups, "UnitGroupId", "UnitGroupId");
            return View();
        }

        // POST: UnitMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin , Commercial-User ")]
        //[OverridableAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(/*Include =*/ "UMId,UnitMasterId,UnitGroupId,UnitName,RelativeFactor,IsBaseUOM")] UnitMaster unitMaster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (unitMaster.UMId != null)
                    {
                        unitMaster.DateAdded = DateTime.Now;
                        unitMaster.DateUpdated = DateTime.Now;

                        if (unitMaster.UMId == unitMaster.UnitMasterId)
                        {
                            db.Entry(unitMaster).State = EntityState.Modified;
                        }
                        else
                        {
                            UnitMaster abcd = unitMaster;
                            db.UnitMasters.Add(abcd);

                            UnitMaster deleteunit = db.UnitMasters.Where(m => m.UnitMasterId == abcd.UMId).FirstOrDefault();

                            db.UnitMasters.Remove(deleteunit);
                        }
                        db.SaveChanges();
                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), unitMaster.UnitMasterId.ToString(), "Update");
                    }
                    else
                    {
                        unitMaster.DateAdded = DateTime.Now;
                        unitMaster.DateUpdated = DateTime.Now;

                        db.UnitMasters.Add(unitMaster);
                        db.SaveChanges();
                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), unitMaster.UnitMasterId.ToString(), "Create");
                    }

                    return RedirectToAction("Index");
                }

                ViewBag.UnitGroupId = new SelectList(db.UnitGroups, "UnitGroupId", "UnitGroupId", unitMaster.UnitGroupId);
                return View(unitMaster);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Unable to Save / Update";
                TempData["Status"] = "0";
                //ModelState("Unit is linked with Other Table");

                throw ex;
            }
        }

        // GET: UnitMasters/Edit/5
        //[OverridableAuthorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            ViewBag.Title = "Edit";
            UnitMaster unitMaster = db.UnitMasters.Find(id);
            unitMaster.UMId = unitMaster.UnitMasterId;

            if (unitMaster == null)
            {
                return NotFound();
            }
            ViewBag.UnitGroupId = new SelectList(db.UnitGroups, "UnitGroupId", "UnitGroupId", unitMaster.UnitGroupId);
            return View("Create", unitMaster);
        }

        // POST: UnitMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin , Commercial-User ")]
        //public ActionResult Edit([Bind(/*Include =*/ "UMId,UnitMasterId,UnitGroupId,UnitShortName,RelativeFactor,IsBaseUOM,AddedBy,DateAdded,UpdatedBy,DateUpdated")] UnitMaster unitMaster)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(unitMaster).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.UnitGroupId = new SelectList(db.UnitGroups, "UnitGroupId", "UnitGroupId", unitMaster.UnitGroupId);
        //    return View(unitMaster);
        //}

        // GET: UnitMasters/Delete/5
        //[OverridableAuthorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            ViewBag.Title = "Delete";
            UnitMaster unitMaster = db.UnitMasters.Find(id);
            unitMaster.UMId = unitMaster.UnitMasterId;

            if (unitMaster == null)
            {
                return NotFound();
            }
            ViewBag.UnitGroupId = new SelectList(db.UnitGroups, "UnitGroupId", "UnitGroupId", unitMaster.UnitGroupId);
            return View("Create", unitMaster);
        }

        // POST: UnitMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin , Commercial-User ")]
        //[OverridableAuthorize]
        //[ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(string id)
        {
            try
            {
                //UnitMaster unitMaster = db.UnitMasters.Where(m=> m.UnitMasterId.ToString() == m.UMId.ToString());
                UnitMaster unitMaster = db.UnitMasters.Find(id);
                db.UnitMasters.Remove(unitMaster);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), id.ToString(), "Delete");
                return Json(new { Success = 1, id = unitMaster.UnitMasterId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Unable to Delete the Data.";
                TempData["Status"] = "3";
                return Json(new { Success = 1, ex = ex.Message.ToString() });
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
