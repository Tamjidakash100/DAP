using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace GTERP.Controllers.Account
{
    [OverridableAuthorize]
    public class Acc_BankStatementBalanceController : Controller
    {
        private GTRDBContext db;

        public Acc_BankStatementBalanceController(GTRDBContext context)
        {
            db = context;
        }

        //[Authorize]
        // GET: Categories
        public ActionResult Index()
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            //return View(db.Acc_BankStatementBalances.Where(c => c.BankStatementBalanceId > 0).ToList());
            return View(db.Acc_BankStatementBalances.Where(x => x.comid == comid).ToList());

        }

        //[Authorize]
        // GET: Categories/Create
        public ActionResult Create()
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");


            ViewBag.AccId = new SelectList(db.Acc_ChartOfAccounts.Where(x => x.AccCode.Contains("1-1-11") && x.comid == comid && x.AccType == "L"), "AccId", "AccName");
            ViewBag.Title = "Create";


            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Acc_BankStatementBalance Acc_BankStatementBalances)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            //if (ModelState.IsValid)
            {
                if (Acc_BankStatementBalances.BankStatementBalanceId > 0)
                {
                    Acc_BankStatementBalances.DateUpdated = DateTime.Now;
                    Acc_BankStatementBalances.useridUpdate = userid;

                    db.Entry(Acc_BankStatementBalances).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    Acc_BankStatementBalances.comid = comid;
                    Acc_BankStatementBalances.userid = userid;
                    Acc_BankStatementBalances.DateAdded = DateTime.Now;


                    db.Acc_BankStatementBalances.Add(Acc_BankStatementBalances);
                    db.SaveChanges();


                    db.Entry(Acc_BankStatementBalances).GetDatabaseValues();
                    //int id = Acc_BankStatementBalance.BankStatementBalanceId; // Yes it's here



                    //db.Categories.Add(Acc_BankStatementBalance);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");

            //return View(Acc_BankStatementBalance);
        }


        //[Authorize]
        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            Acc_BankStatementBalance Acc_BankStatementBalance = db.Acc_BankStatementBalances.Where(c => c.BankStatementBalanceId == id).FirstOrDefault();

            ViewBag.AccId = new SelectList(db.Acc_ChartOfAccounts.Where(x => x.AccCode.Contains("1-1-11") && x.comid == comid && x.AccType == "L"), "AccId", "AccName", Acc_BankStatementBalance.AccId);
            if (Acc_BankStatementBalance == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";

            return View("Create", Acc_BankStatementBalance);

        }


        //[Authorize]
        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            Acc_BankStatementBalance Acc_BankStatementBalance = db.Acc_BankStatementBalances.Where(c => c.BankStatementBalanceId == id).FirstOrDefault();
            ViewBag.AccId = new SelectList(db.Acc_ChartOfAccounts.Where(x => x.AccCode.Contains("1-1-11") && x.comid == comid && x.AccType == "L"), "AccId", "AccName", Acc_BankStatementBalance.AccId);


            if (Acc_BankStatementBalance == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";

            return View("Create", Acc_BankStatementBalance);
        }
        //        //[Authorize]
        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        //      [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int? id)
        {
            try
            {

                Acc_BankStatementBalance Acc_BankStatementBalance = db.Acc_BankStatementBalances.Where(c => c.BankStatementBalanceId == id).FirstOrDefault();

                db.Acc_BankStatementBalances.Remove(Acc_BankStatementBalance);
                db.SaveChanges();

                return Json(new { Success = 1, BankStatementBalanceId = Acc_BankStatementBalance.BankStatementBalanceId, ex = "" });

            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.Message.ToString() });

            }



            //return RedirectToAction("Index");
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
