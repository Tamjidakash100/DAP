using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GTERP.Controllers.Account
{
    [OverridableAuthorize]
    public class BankReconcileInfoController : Controller
    {
        private TransactionLogRepository tranlog;

        //Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        private GTRDBContext db;
        public clsProcedure clsProc { get; }
        //public CommercialRepository Repository { get; set; } ///for report service

        public BankReconcileInfoController(GTRDBContext context, clsProcedure _clsProc, TransactionLogRepository tran)//for report service
        {

            db = context;
            // Repository = repository; ///for report service
            clsProc = _clsProc;
            tranlog = tran;
        }

        //[Authorize]
        // GET: Categories
        public ViewResult Index(string FromDate, string ToDate, string criteria)
        {

            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date.ToString("dd-MMM-yy"));
            DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date.ToString("dd-MMM-yy"));


            List<Acc_VoucherSubCheckno> abcd = new List<Acc_VoucherSubCheckno>();

            if (FromDate == null || FromDate == "")
            {

                abcd = db.Acc_VoucherSubChecnos.Include(x => x.vAcc_ChartOfAccount).Where(x => x.VoucherId == null && x.comid == comid).Where(x => x.dtChk == null).ToList();

            }
            else
            {
                dtFrom = Convert.ToDateTime(FromDate);

                abcd = db.Acc_VoucherSubChecnos.Include(x => x.vAcc_ChartOfAccount).Where(x => x.VoucherId == null && x.comid == comid).Where(x => x.dtChk >= dtFrom && x.dtChk <= dtTo).ToList();



            }
            //if (ToDate == null || ToDate == "")
            //{
            //}
            //else
            //{
            //    dtTo = Convert.ToDateTime(ToDate);

            //}



            //return View(db.Acc_VoucherSubChecnos.Where(c => c.VoucherSubCheckId > 0).ToList());
            return View(abcd);

        }

        //[Authorize]
        // GET: Categories/Create
        public ActionResult Create()
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");


            ViewData["Criteria"] = new SelectList(CriteriaList, "Value", "Text");
            var Acc_ChartOfAccount = db.Acc_ChartOfAccounts.Where(c => c.comid == comid && c.AccId > 0 && c.AccType == "L" && c.IsChkRef == true); //&& c.ComId == (transactioncomid)
            this.ViewBag.AccId = new SelectList(Acc_ChartOfAccount.Where(x => x.IsChkRef == true).Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text");


            ViewBag.Title = "Create";


            return View();
        }


        public static List<SelectListItem> CriteriaList = new List<SelectListItem>()
        {
            new SelectListItem() { Text="Add", Value="Add"},
            new SelectListItem() { Text="Less", Value="Less"},
        };

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Acc_VoucherSubCheckno Acc_VoucherSubChecknovar)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            //if (ModelState.IsValid)
            {
                if (Acc_VoucherSubChecknovar.VoucherSubCheckId > 0)
                {

                    if (Acc_VoucherSubChecknovar.comid == null || Acc_VoucherSubChecknovar.comid == "")
                    {
                        Acc_VoucherSubChecknovar.comid = comid;

                    }

                    Acc_VoucherSubChecknovar.DateUpdated = DateTime.Now;
                    Acc_VoucherSubChecknovar.useridUpdate = userid;
                    Acc_VoucherSubChecknovar.isManualEntry = true;


                    db.Entry(Acc_VoucherSubChecknovar).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {

                    Acc_VoucherSubChecknovar.DateAdded = DateTime.Now;
                    Acc_VoucherSubChecknovar.userid = userid;
                    Acc_VoucherSubChecknovar.comid = comid;
                    Acc_VoucherSubChecknovar.isManualEntry = true;


                    db.Acc_VoucherSubChecnos.Add(Acc_VoucherSubChecknovar);
                    db.SaveChanges();


                    //db.Entry(Acc_VoucherSubChecknovar).GetDatabaseValues();
                    //int id = Acc_VoucherSubCheckno.VoucherSubCheckId; // Yes it's here



                    //db.Categories.Add(Acc_VoucherSubCheckno);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");

            //return View(Acc_VoucherSubCheckno);
        }


        //[Authorize]
        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            if (id == null)
            {
                return BadRequest();
            }
            Acc_VoucherSubCheckno Acc_VoucherSubCheckno = db.Acc_VoucherSubChecnos.Where(c => c.VoucherSubCheckId == id).FirstOrDefault();


            if (Acc_VoucherSubCheckno == null)
            {
                return NotFound();
            }


            ViewData["Criteria"] = new SelectList(CriteriaList, "Value", "Text", Acc_VoucherSubCheckno.Criteria);
            var Acc_ChartOfAccount = db.Acc_ChartOfAccounts.Where(c => c.comid == comid && c.AccId > 0 && c.AccType == "L" && c.IsChkRef == true); //&& c.ComId == (transactioncomid)
            this.ViewBag.AccId = new SelectList(Acc_ChartOfAccount.Where(x => x.IsChkRef == true).Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text", Acc_VoucherSubCheckno.AccId);


            ViewBag.Title = "Edit";

            return View("Create", Acc_VoucherSubCheckno);

        }


        public ActionResult View(int? id)
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            if (id == null)
            {
                return BadRequest();
            }
            Acc_VoucherSubCheckno Acc_VoucherSubCheckno = db.Acc_VoucherSubChecnos.Where(c => c.VoucherSubCheckId == id).FirstOrDefault();


            if (Acc_VoucherSubCheckno == null)
            {
                return NotFound();
            }


            ViewData["Criteria"] = new SelectList(CriteriaList, "Value", "Text", Acc_VoucherSubCheckno.Criteria);
            var Acc_ChartOfAccount = db.Acc_ChartOfAccounts.Where(c => c.comid == comid && c.AccId > 0 && c.AccType == "L" && c.IsChkRef == true); //&& c.ComId == (transactioncomid)
            this.ViewBag.AccId = new SelectList(Acc_ChartOfAccount.Where(x => x.IsChkRef == true).Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text", Acc_VoucherSubCheckno.AccId);


            ViewBag.Title = "View";

            return View("Create", Acc_VoucherSubCheckno);

        }


        //[Authorize]
        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");
            if (id == null)
            {
                return BadRequest();
            }
            Acc_VoucherSubCheckno Acc_VoucherSubCheckno = db.Acc_VoucherSubChecnos.Where(c => c.VoucherSubCheckId == id).FirstOrDefault();


            if (Acc_VoucherSubCheckno == null)
            {
                return NotFound();
            }

            ViewData["Criteria"] = new SelectList(CriteriaList, "Value", "Text", Acc_VoucherSubCheckno.Criteria);
            var Acc_ChartOfAccount = db.Acc_ChartOfAccounts.Where(c => c.comid == comid && c.AccId > 0 && c.AccType == "L" && c.IsChkRef == true); //&& c.ComId == (transactioncomid)
            this.ViewBag.AccId = new SelectList(Acc_ChartOfAccount.Where(x => x.IsChkRef == true).Select(s => new { Text = s.AccName + " - [ " + s.AccCode + " ]", Value = s.AccId }).ToList(), "Value", "Text", Acc_VoucherSubCheckno.AccId);


            ViewBag.Title = "Delete";

            return View("Create", Acc_VoucherSubCheckno);
        }
        //        //[Authorize]
        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        //      [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int? id)
        {
            try
            {

                Acc_VoucherSubCheckno Acc_VoucherSubCheckno = db.Acc_VoucherSubChecnos.Where(c => c.VoucherSubCheckId == id).FirstOrDefault();

                db.Acc_VoucherSubChecnos.Remove(Acc_VoucherSubCheckno);
                db.SaveChanges();

                return Json(new { Success = 1, VoucherSubCheckId = Acc_VoucherSubCheckno.VoucherSubCheckId, ex = "" });

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
