using GTERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GTERP.Controllers
{
    [OverridableAuthorize]
    public class PortOfLoadingsController : Controller
    {
        private GTRDBContext db;
        public PortOfLoadingsController(GTRDBContext context)
        {
            db = context;
        }

        // GET: PortOfLoadings
        //[OverridableAuthorize]
        public ActionResult Index()
        {
            return View(db.PortOfLoadings.ToList());
        }



        // GET: PortOfLoadings/Create
        //[OverridableAuthorize]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");

            return View();
        }

        // POST: PortOfLoadings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin , Commercial-User ")]
        //[OverridableAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(/*Include =*/ "PortOfLoadingId,PortCode,PortOfLoadingName,CountryId")] PortOfLoading PortOfLoading)
        {
            //if (ModelState.IsValid)
            //{
            if (PortOfLoading.PortOfLoadingId > 0)
            {
                //PortOfLoading.comid = int.Parse(AppData.intComId.ToString());
                //PortOfLoading.userid = HttpContext.Session.GetString("userid");

                PortOfLoading.DateAdded = DateTime.Now;
                PortOfLoading.DateUpdated = DateTime.Now;
                db.Entry(PortOfLoading).State = EntityState.Modified;
                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), PortOfLoading.PortOfLoadingId.ToString(), "Update");
            }
            else
            {
                PortOfLoading.DateAdded = DateTime.Now;
                PortOfLoading.DateUpdated = DateTime.Now;
                //PortOfLoading.comid = int.Parse(AppData.intComId.ToString());
                //PortOfLoading.userid = HttpContext.Session.GetString("userid");
                db.PortOfLoadings.Add(PortOfLoading);
                TempData["Message"] = "Data Save Successfully";
                TempData["Status"] = "1";
                //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), PortOfLoading.PortOfLoadingId.ToString(), "Create");
            }
            db.SaveChanges();

            return RedirectToAction("Index");

            //}


        }

        // GET: PortOfLoadings/Edit/5
        //[OverridableAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Edit";
            PortOfLoading PortOfLoading = db.PortOfLoadings.Find(id);
            //ViewBag.CountryId = new SelectList(db.Countries.Where(m => m.comid == int.Parse(AppData.intComId)), "CountryId", "CountryName", PortOfLoading.CountryId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", PortOfLoading.CountryId);

            if (PortOfLoading == null)
            {
                return NotFound();
            }
            return View("Create", PortOfLoading);
        }

        // POST: PortOfLoadings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(/*Include =*/ "PortOfLoadingId,PortCode,PortOfLoadingName,CountryId")] PortOfLoading PortOfLoading)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(PortOfLoading).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(PortOfLoading);
        //}

        // GET: PortOfLoadings/Delete/5
        //[OverridableAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Delete";
            PortOfLoading PortOfLoading = db.PortOfLoadings.Find(id);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", PortOfLoading.CountryId);
            if (PortOfLoading == null)
            {
                return NotFound();
            }
            return View("Create", PortOfLoading);
        }

        // POST: PortOfLoadings/Delete/5
        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin , Commercial-User ")]
        //[OverridableAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                PortOfLoading PortOfLoadings = db.PortOfLoadings.Find(id);
                db.PortOfLoadings.Remove(PortOfLoadings);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), id.ToString(), "Delete");
                return Json(new { Success = 1, id = PortOfLoadings.PortOfLoadingId, ex = TempData["Message"].ToString() });

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
