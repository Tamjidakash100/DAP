using GTERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GTERP.Controllers
{
    [OverridableAuthorize]
    public class CurrenciesController : Controller
    {
        private GTRDBContext db;
        public CurrenciesController(GTRDBContext context)
        {
            db = context;
        }
        //UserLog //UserLog;
        //public CurrenciesController()
        //{
        //    //UserLog = new //UserLog();
        //}

        // GET: Currency
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        public ActionResult Index()
        {
            return View(db.Currency.ToList());
        }


        // GET: Currency/Create
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            //ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");


            return View();
        }

        // POST: Currency/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(/*Include =*/ "CurrencyId,CurCode,Rate,EffectDate")] Currency Currency)
        {
            try
            {


                if (Currency.CurrencyId > 0)
                {
                    //Currency.DateUpdated = DateTime.Now;
                    Currency.DateAdded = DateTime.Now;
                    //Currency.userid = HttpContext.Session.GetString("userid");
                    //Currency.comid = int.Parse(AppData.intComId);
                    db.Entry(Currency).State = EntityState.Modified;
                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Currency.CurrencyId.ToString(), "Update");

                }
                else
                {
                    Currency.DateAdded = DateTime.Now;
                    //Currency.DateUpdated = DateTime.Now;
                    //Currency.userid = HttpContext.Session.GetString("userid");
                    //Currency.comid = int.Parse(AppData.intComId);
                    db.Currency.Add(Currency);
                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Currency.CurrencyId.ToString(), "Create");

                }
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["Message"] = "Unable to Save / Update";
                TempData["Status"] = "0";
                throw ex;
            }
        }

        // GET: Currency/Edit/5
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Edit";
            Currency Currency = db.Currency.Find(id);
            //ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", Currency.CountryId);

            if (Currency == null)
            {
                return NotFound();
            }
            return View("Create", Currency);
        }

        // POST: Currency/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(/*Include =*/ "CurrencyId,CurCode,Rate,EffectDate")] Currency Currency)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(Currency).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(Currency);
        //}

        // GET: Currency/Delete/5
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Delete";
            Currency Currency = db.Currency.Find(id);
            //ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", Currency.CountryId);
            if (Currency == null)
            {
                return NotFound();
            }
            return View("Create", Currency);
        }

        // POST: Currency/Delete/5
        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        // [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {
                Currency Currency = db.Currency.Find(id);
                db.Currency.Remove(Currency);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), id.ToString(), "Delete");
                return Json(new { Success = 1, id = Currency.CurrencyId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Unable to Delete the Data.";
                TempData["Status"] = "3";
                return Json(new { Success = 0, ex = ex.Message.ToString() }); ;
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
