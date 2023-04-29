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
    public class OpeningBanksController : Controller
    {
        private GTRDBContext db;
        public OpeningBanksController(GTRDBContext context)
        {
            db = context;
        }

        // GET: OpeningBanks
        //[OverridableAuthorize]
        public ActionResult Index()
        {
            return View(db.OpeningBanks.ToList());
        }



        // GET: OpeningBanks/Create
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");


            return View();
        }

        // POST: OpeningBanks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(/*Include =*/ "OpeningBankId,OpeningBankName,CountryId,SwiftCode,BranchAddress , BranchAddress2,PhoneNo,Remarks")] OpeningBank openingBank)
        {
            try
            {


                if (openingBank.OpeningBankId > 0)
                {
                    openingBank.DateUpdated = DateTime.Now;
                    openingBank.DateAdded = DateTime.Now;
                    openingBank.userid = HttpContext.Session.GetString("userid");
                    //openingBank.comid = (HttpContext.Session.GetString("comid"));
                    db.Entry(openingBank).State = EntityState.Modified;
                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), openingBank.OpeningBankId.ToString(), "Update");

                }
                else
                {
                    openingBank.DateAdded = DateTime.Now;
                    openingBank.DateUpdated = DateTime.Now;
                    openingBank.userid = HttpContext.Session.GetString("userid");
                    //openingBank.comid = (HttpContext.Session.GetString("comid"));
                    db.OpeningBanks.Add(openingBank);
                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), openingBank.OpeningBankId.ToString(), "Create");
                }
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: OpeningBanks/Edit/5
        //[OverridableAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Edit";
            OpeningBank openingBank = db.OpeningBanks.Find(id);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", openingBank.CountryId);

            if (openingBank == null)
            {
                return NotFound();
            }
            return View("Create", openingBank);
        }

        // POST: OpeningBanks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[OverridableAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(/*Include =*/ "OpeningBankId,OpeningBankName,CountryId,SwiftCode,BranchAddress , BranchAddress2,PhoneNo,Remarks")] OpeningBank openingBank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(openingBank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(openingBank);
        }

        // GET: OpeningBanks/Delete/5
        //[OverridableAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Delete";
            OpeningBank openingBank = db.OpeningBanks.Find(id);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", openingBank.CountryId);
            if (openingBank == null)
            {
                return NotFound();
            }
            return View("Create", openingBank);
        }

        // POST: OpeningBanks/Delete/5
        [HttpPost, ActionName("Delete")]
        //[OverridableAuthorize]
        // [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {
                OpeningBank openingBank = db.OpeningBanks.Find(id);
                db.OpeningBanks.Remove(openingBank);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), id.ToString(), "Delete");

                return Json(new { Success = 1, id = openingBank.OpeningBankId, ex = TempData["Message"].ToString() });
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
