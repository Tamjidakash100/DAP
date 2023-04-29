using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace GTERP.Controllers
{
    [OverridableAuthorize]
    public class SisterConcernCompanyController : Controller
    {
        private TransactionLogRepository tranlog;
        private GTRDBContext db;
        //UserLog //UserLog;

        public SisterConcernCompanyController(GTRDBContext context, TransactionLogRepository tran)
        {
            db = context;
            tranlog = tran;
        }

        // GET: CommercialCompanies
        //[OverridableAuthorize]
        public ActionResult Index()
        {
            return View(db.SisterConcernCompany.ToList());
        }



        // GET: CommercialCompanies/Create
        ////[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";

            return View();
        }

        // POST: CommercialCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin , Commercial-User ")]
        //[OverridableAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(SisterConcernCompany SisterConcernCompany)
        {
            try
            {

                ViewBag.Title = "Create";
                if (ModelState.IsValid)
                {
                    if (SisterConcernCompany.SisterConcernCompanyId > 0)
                    {
                        SisterConcernCompany.comid = (HttpContext.Session.GetString("comid"));
                        SisterConcernCompany.userid = HttpContext.Session.GetString("userid");

                        db.Entry(SisterConcernCompany).State = EntityState.Modified;

                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), SisterConcernCompany.comid.ToString(), "Update", SisterConcernCompany.CompanyName.ToString());

                    }
                    else
                    {
                        SisterConcernCompany.comid = HttpContext.Session.GetString("comid");
                        SisterConcernCompany.userid = HttpContext.Session.GetString("userid");
                        db.SisterConcernCompany.Add(SisterConcernCompany);

                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), SisterConcernCompany.comid.ToString(), "Save", SisterConcernCompany.CompanyName.ToString());



                    }
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View(SisterConcernCompany);
        }

        // GET: CommercialCompanies/Edit/5
        //[OverridableAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Edit";

            SisterConcernCompany SisterConcernCompany = db.SisterConcernCompany.Find(id);
            if (SisterConcernCompany == null)
            {
                return NotFound();
            }
            return View("Create", SisterConcernCompany);
        }

        // POST: CommercialCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        ////[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(/*Include =*/ "SisterConcernCompanyId,CompanyName,CompanyShortName,Address,PhoneNumber,FaxNumber,EmailID,ContactPerson,Active,TradeLicenceNo,TINNo,VATNo,IRCNo,BKMEARegNo,comid,userid,isDelete")] SisterConcernCompany SisterConcernCompany)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(SisterConcernCompany).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(SisterConcernCompany);
        //}

        // GET: CommercialCompanies/Delete/5
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin , Commercial-User ")]
        //[OverridableAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Delete";

            SisterConcernCompany SisterConcernCompany = db.SisterConcernCompany.Find(id);
            if (SisterConcernCompany == null)
            {
                return NotFound();
            }
            return View("Create", SisterConcernCompany);
        }

        // POST: CommercialCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin , Commercial-User ")]
        //[OverridableAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                SisterConcernCompany SisterConcernCompany = db.SisterConcernCompany.Find(id);
                db.SisterConcernCompany.Remove(SisterConcernCompany);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), id.ToString(), "Delete");
                return Json(new { Success = 1, id = SisterConcernCompany.SisterConcernCompanyId, ex = TempData["Message"].ToString() });

            }
            catch (Exception ex)
            {

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
