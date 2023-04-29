using GTERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GTERP.Controllers
{
    [OverridableAuthorize]
    public class PortOfDischargesController : Controller
    {
        private GTRDBContext db;
        public PortOfDischargesController(GTRDBContext context)
        {
            db = context;
        }

        // GET: PortOfDischarges
        //[OverridableAuthorize]
        public ActionResult Index()
        {
            return View(db.PortOfDischarges.ToList());
        }

        // GET: PortOfDischarges/Create
        //[OverridableAuthorize]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");

            return View();
        }

        // POST: PortOfDischarges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin , Commercial-User ")]
        //[OverridableAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(/*Include =*/ "PortOfDischargeId,PortCode,PortOfDischargeName,CountryId")] PortOfDischarge PortOfDischarge)
        {
            //if (ModelState.IsValid)
            //{
            if (PortOfDischarge.PortOfDischargeId > 0)
            {
                //PortOfDischarge.comid = int.Parse(AppData.intComId.ToString());
                //PortOfDischarge.userid = HttpContext.Session.GetString("userid");




                PortOfDischarge.DateAdded = DateTime.Now;
                PortOfDischarge.DateUpdated = DateTime.Now;


                db.Entry(PortOfDischarge).State = EntityState.Modified;
                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), PortOfDischarge.PortOfDischargeId.ToString(), "Update");

            }
            else
            {
                PortOfDischarge.DateAdded = DateTime.Now;
                PortOfDischarge.DateUpdated = DateTime.Now;
                //PortOfDischarge.comid = int.Parse(AppData.intComId.ToString());
                //PortOfDischarge.userid = HttpContext.Session.GetString("userid");
                db.PortOfDischarges.Add(PortOfDischarge);
                TempData["Message"] = "Data Save Successfully";
                TempData["Status"] = "1";
                //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), PortOfDischarge.PortOfDischargeId.ToString(), "Create");
            }
            db.SaveChanges();

            return RedirectToAction("Index");

            //}


        }

        // GET: PortOfDischarges/Edit/5
        //[OverridableAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Edit";
            PortOfDischarge PortOfDischarge = db.PortOfDischarges.Find(id);
            //ViewBag.CountryId = new SelectList(db.Countries.Where(m => m.comid == int.Parse(AppData.intComId)), "CountryId", "CountryName", PortOfDischarge.CountryId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", PortOfDischarge.CountryId);

            if (PortOfDischarge == null)
            {
                return NotFound();
            }
            return View("Create", PortOfDischarge);
        }

        // POST: PortOfDischarges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(/*Include =*/ "PortOfDischargeId,PortCode,PortOfDischargeName,CountryId")] PortOfDischarge PortOfDischarge)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(PortOfDischarge).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(PortOfDischarge);
        //}

        // GET: PortOfDischarges/Delete/5
        //[OverridableAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Delete";
            PortOfDischarge PortOfDischarge = db.PortOfDischarges.Find(id);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", PortOfDischarge.CountryId);
            if (PortOfDischarge == null)
            {
                return NotFound();
            }
            return View("Create", PortOfDischarge);
        }

        // POST: PortOfDischarges/Delete/5
        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin , Commercial-User ")]
        //[OverridableAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                PortOfDischarge PortOfDischarges = db.PortOfDischarges.Find(id);
                db.PortOfDischarges.Remove(PortOfDischarges);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), id.ToString(), "Delete");
                return Json(new { Success = 1, id = PortOfDischarges.PortOfDischargeId, ex = TempData["Message"].ToString() });

            }
            catch (Exception ex)
            {
                TempData["Message"] = "Unable to Delete the Data.";
                TempData["Status"] = "3";
                return Json(new { Success = 0, ex = ex.Message.ToString() });
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
