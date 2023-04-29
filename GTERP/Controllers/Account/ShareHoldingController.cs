using GTERP.BLL;
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
    public class ShareHoldingController : Controller
    {
        private TransactionLogRepository tranlog;
        private GTRDBContext db;

        public ShareHoldingController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }


        //[Authorize]
        // GET: Categories
        public ActionResult Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            //return View(db.ShareHoldings.Where(c => c.ShareHoldingId > 0).ToList());
            return View(db.ShareHoldings.Include(x => x.Acc_FiscalYears).Where(c => c.comid == HttpContext.Session.GetString("comid") && c.ShareHoldingId > 0).ToList());

        }

        //[Authorize]
        // GET: Categories/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            //ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.comid == (HttpContext.Session.GetString("comid"))).Where(c => c.CategoryId > 0), "CategoryId", "Name");
            ViewBag.FiscalyearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(c => c.FYId).Where(c => c.FYId > 0 && c.comid == (HttpContext.Session.GetString("comid"))), "FYId", "FYName");

            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShareHolding ShareHolding)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            string comid = HttpContext.Session.GetString("comid");
            string userid = HttpContext.Session.GetString("userid");


            //if (ModelState.IsValid)
            //{
            if (ShareHolding.ShareHoldingId > 0)
            {

                ShareHolding.DateUpdated = DateTime.Now;
                ShareHolding.comid = comid;

                if (ShareHolding.userid == null)
                {
                    ShareHolding.userid = userid;
                }
                ShareHolding.useridUpdate = userid;



                db.Entry(ShareHolding).State = EntityState.Modified;
                db.SaveChanges();

                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), ShareHolding.ShareHoldingId.ToString(), "Update", ShareHolding.ShareHolderName.ToString());





            }
            else
            {
                ShareHolding.userid = userid;
                ShareHolding.comid = comid;
                ShareHolding.DateAdded = DateTime.Now;





                db.ShareHoldings.Add(ShareHolding);
                db.SaveChanges();

                TempData["Message"] = "Data Save Successfully";
                TempData["Status"] = "1";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), ShareHolding.ShareHoldingId.ToString(), "Create", ShareHolding.ShareHolderName.ToString());






                //db.Categories.Add(ShareHolding);
                return RedirectToAction("Index");
            }
            //}
            return RedirectToAction("Index");

            //return View(ShareHolding);
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

            ShareHolding ShareHolding = db.ShareHoldings.Where(c => c.ShareHoldingId == id && c.comid == comid).FirstOrDefault();
            //ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.comid == comid).Where(c => c.CategoryId > 0), "CategoryId", "Name");
            ViewBag.FiscalyearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(c => c.FYId).Where(c => c.FYId > 0 && c.comid == (HttpContext.Session.GetString("comid"))), "FYId", "FYName");

            if (ShareHolding == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";

            return View("Create", ShareHolding);

        }


        //[Authorize]
        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var comid = (HttpContext.Session.GetString("comid")).ToString();

            ShareHolding ShareHolding = db.ShareHoldings.Where(c => c.ShareHoldingId == id && c.comid == comid).FirstOrDefault();
            //ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.comid == comid).Where(c => c.CategoryId > 0), "CategoryId", "Name");
            ViewBag.FiscalyearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(c => c.FYId).Where(c => c.FYId > 0 && c.comid == (HttpContext.Session.GetString("comid"))), "FYId", "FYName");

            if (ShareHolding == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";

            return View("Create", ShareHolding);
        }
        //        //[Authorize]
        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        //      [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int? id)
        {
            try
            {
                var comid = (HttpContext.Session.GetString("comid")).ToString();
                ShareHolding ShareHolding = db.ShareHoldings.Where(c => c.comid == comid && c.ShareHoldingId == id).FirstOrDefault();

                db.ShareHoldings.Remove(ShareHolding);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), ShareHolding.ShareHoldingId.ToString(), "Delete", ShareHolding.ShareHolderName);


                return Json(new { Success = 1, ShareHoldingId = ShareHolding.ShareHoldingId, ex = "" });

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
