using GTERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GTERP.Controllers
{
    [OverridableAuthorize]
    public class DestinationsController : Controller
    {
        private GTRDBContext db;
        public DestinationsController(GTRDBContext context)
        {
            db = context;
        }

        // GET: Destinations
        //[OverridableAuthorize]
        public ActionResult Index()
        {
            return View(db.Destinations.ToList());
        }



        // GET: Destinations/Create
        //[OverridableAuthorize]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");

            return View();
        }

        // POST: Destinations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin , Commercial-User ")]
        //[OverridableAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(/*Include =*/ "DestinationID,DestinationCode,DestinationName,CountryId,DestinationNameSearch")] Destination destination)
        {
            //if (ModelState.IsValid)
            //{
            if (destination.DestinationID > 0)
            {
                //destination.comid = int.Parse(AppData.intComId.ToString());
                //destination.userid = HttpContext.Session.GetString("userid");
                destination.DateAdded = DateTime.Now;
                destination.DateUpdated = DateTime.Now;
                db.Entry(destination).State = EntityState.Modified;
                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), destination.DestinationID.ToString(), "Update");
            }
            else
            {
                destination.DateAdded = DateTime.Now;
                destination.DateUpdated = DateTime.Now;
                //destination.comid = int.Parse(AppData.intComId.ToString());
                //destination.userid = HttpContext.Session.GetString("userid");
                db.Destinations.Add(destination);
                TempData["Message"] = "Data Save Successfully";
                TempData["Status"] = "1";
                //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), destination.DestinationID.ToString(), "Create");
            }
            db.SaveChanges();

            return RedirectToAction("Index");

            //}


        }

        // GET: Destinations/Edit/5
        //[OverridableAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Edit";
            Destination destination = db.Destinations.Find(id);
            //ViewBag.CountryId = new SelectList(db.Countries.Where(m => m.comid == int.Parse(AppData.intComId)), "CountryId", "CountryName", destination.CountryId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", destination.CountryId);

            if (destination == null)
            {
                return NotFound();
            }
            return View("Create", destination);
        }

        // POST: Destinations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(/*Include =*/ "DestinationID,DestinationCode,DestinationName,CountryId")] Destination destination)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(destination).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(destination);
        //}




        // GET: Destinations/Delete/5
        //[OverridableAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Delete";
            Destination destination = db.Destinations.Find(id);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", destination.CountryId);
            if (destination == null)
            {
                return NotFound();
            }
            return View("Create", destination);
        }

        // POST: Destinations/Delete/5
        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin , Commercial-User ")]
        //[OverridableAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Destination Destinations = db.Destinations.Find(id);
                db.Destinations.Remove(Destinations);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), id.ToString(), "Delete");
                return Json(new { Success = 1, id = Destinations.DestinationID, ex = TempData["Message"].ToString() });

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
