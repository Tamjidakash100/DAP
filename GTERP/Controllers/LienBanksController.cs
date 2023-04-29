using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace GTERP.Controllers
{
    [OverridableAuthorize]
    public class LienBanksController : Controller
    {
        private GTRDBContext db;
        public LienBanksController(GTRDBContext context)
        {
            db = context;
        }

        // GET: LienBanks
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        public ActionResult Index()
        {
            return View(db.LienBanks.ToList());
        }



        // GET: LienBanks/Create
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");


            return View();
        }

        // POST: LienBanks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(LienBank LienBank)
        {
            try
            {


                if (LienBank.LienBankId > 0)
                {
                    LienBank.DateUpdated = DateTime.Now;
                    LienBank.DateAdded = DateTime.Now;
                    LienBank.userid = HttpContext.Session.GetString("userid");
                    LienBank.comid = HttpContext.Session.GetString("comid");
                    db.Entry(LienBank).State = EntityState.Modified;
                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), LienBank.LienBankId.ToString(), "Update");

                }
                else
                {
                    LienBank.DateAdded = DateTime.Now;
                    LienBank.DateUpdated = DateTime.Now;
                    LienBank.userid = HttpContext.Session.GetString("userid");
                    LienBank.comid = HttpContext.Session.GetString("comid");
                    db.LienBanks.Add(LienBank);
                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), LienBank.LienBankId.ToString(), "Create");

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

        // GET: LienBanks/Edit/5
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Edit";
            LienBank LienBank = db.LienBanks.Find(id);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", LienBank.CountryId);

            if (LienBank == null)
            {
                return NotFound();
            }
            return View("Create", LienBank);
        }

        // POST: LienBanks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        ////[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(/*Include =*/ "LienBankId,LienBankName,CountryId,SwiftCode,BranchAddress , BranchAddress2,PhoneNo,Remarks")] LienBank LienBank)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(LienBank).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(LienBank);
        //}

        // GET: LienBanks/Delete/5
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Delete";
            LienBank LienBank = db.LienBanks.Find(id);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", LienBank.CountryId);
            if (LienBank == null)
            {
                return NotFound();
            }
            return View("Create", LienBank);
        }

        // POST: LienBanks/Delete/5
        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        // [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {
                LienBank LienBank = db.LienBanks.Find(id);
                db.LienBanks.Remove(LienBank);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), id.ToString(), "Delete");
                return Json(new { Success = 1, id = LienBank.LienBankId, ex = TempData["Message"].ToString() });
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
