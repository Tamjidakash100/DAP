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
    public class BankAccountNoesController : Controller
    {

        private GTRDBContext db;
        public BankAccountNoesController(GTRDBContext context)
        {
            db = context;
        }

        // GET: BankAccountNoes
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        ////[OverridableAuthorize]
        public ActionResult Index()
        {
            var bankAccountNos = db.BankAccountNos.Include(x => x.CommercialCompanys).Include(x => x.OpeningBanks).ToList();
            return View(bankAccountNos);
        }



        // GET: BankAccountNoes/Create
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        ////[OverridableAuthorize]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.SisterConcernCompanyId = new SelectList(db.SisterConcernCompany, "SisterConcernCompanyId", "CompanyName");
            ViewBag.OpeningBankId = new SelectList(db.OpeningBanks, "OpeningBankId", "OpeningBankName");
            return View();
        }

        // POST: BankAccountNoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        ////[OverridableAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(/*Include =*/ "BankAccountId,BankAccountNumber,SisterConcernCompanyId,OpeningBankId")] BankAccountNo bankAccountNo)
        {
            try
            {
                bankAccountNo.comid = (HttpContext.Session.GetString("comid"));
                bankAccountNo.userid = HttpContext.Session.GetString("userid");

                if (bankAccountNo.BankAccountId > 0)
                {
                    db.Entry(bankAccountNo).State = EntityState.Modified;
                    //  db.SaveChanges();
                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), bankAccountNo.BankAccountId.ToString(), "Update");
                }
                else
                {
                    db.BankAccountNos.Add(bankAccountNo);
                    db.SaveChanges();
                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), bankAccountNo.BankAccountId.ToString(), "Create");
                }


                //}
                ViewBag.SisterConcernCompanyId = new SelectList(db.SisterConcernCompany, "SisterConcernCompanyId", "CompanyName", bankAccountNo.CommercialCompanyId);
                ViewBag.OpeningBankId = new SelectList(db.OpeningBanks, "OpeningBankId", "OpeningBankName", bankAccountNo.OpeningBankId);
                //return RedirectToAction("Index");
                //return View(bankAccountNo);

            }
            catch (Exception ex)
            {
                TempData["Message"] = "Unable to Save / Update";
                TempData["Status"] = "0";
            }
            return RedirectToAction("Index");
        }

        // GET: BankAccountNoes/Edit/5
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        ////[OverridableAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }


            ViewBag.Title = "Edit";
            BankAccountNo bankAccountNo = db.BankAccountNos.Where(x => x.BankAccountId == id).FirstOrDefault();
            if (bankAccountNo == null)
            {
                return NotFound();
            }
            ViewBag.SisterConcernCompanyId = new SelectList(db.SisterConcernCompany, "SisterConcernCompanyId", "CompanyName", bankAccountNo.CommercialCompanyId);
            ViewBag.OpeningBankId = new SelectList(db.OpeningBanks, "OpeningBankId", "OpeningBankName", bankAccountNo.OpeningBankId);
            return View("Create", bankAccountNo);
        }

        // GET: BankAccountNoes/Delete/5
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        ////[OverridableAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Delete";
            BankAccountNo bankAccountNo = db.BankAccountNos.Find(id);
            if (bankAccountNo == null)
            {
                return NotFound();
            }
            return View("Create", bankAccountNo);
        }

        // POST: BankAccountNoes/Delete/5
        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        ////[OverridableAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                BankAccountNo bankAccountNo = db.BankAccountNos.Find(id);
                db.BankAccountNos.Remove(bankAccountNo);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), id.ToString(), "Delete");
                return Json(new { Success = 1, bankAccountNo.BankAccountId, ex = TempData["Message"].ToString() });
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
