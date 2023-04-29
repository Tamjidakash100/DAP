using GTERP.Models;
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
    public class Acc_VoucherNoPrefixController : Controller
    {
        private GTRDBContext db;

        public Acc_VoucherNoPrefixController(GTRDBContext context)
        {
            db = context;
        }


        //[Authorize]
        // GET: Categories
        public ActionResult Index()
        {
            var comid = HttpContext.Session.GetString("comid");
            //List<vouchernoprefix> = db.Acc_VoucherNoPrefixes.Include(c => c.vVoucherTypes).ToList();
            List<Acc_VoucherNoPrefix> vouchernoprefix = db.Acc_VoucherNoPrefixes.Include(x => x.vVoucherTypes).Where(c => c.comid == comid).ToList();

            //return View(db.Acc_VoucherNoPrefixes.Where(c => c.VoucherNoPrefixId > 0).ToList());
            return View(vouchernoprefix);

        }

        //[Authorize]
        // GET: Categories/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.VoucherTypeId = new SelectList(db.Acc_VoucherTypes.Where(c => c.VoucherTypeId > 0), "VoucherTypeId", "VoucherTypeName");

            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Acc_VoucherNoPrefix Acc_VoucherNoPrefix)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            HttpContext.Session.GetString("userid");

            //if (ModelState.IsValid)
            {
                if (Acc_VoucherNoPrefix.VoucherNoPrefixId > 0)
                {

                    Acc_VoucherNoPrefix.DateUpdated = DateTime.Now;
                    Acc_VoucherNoPrefix.comid = HttpContext.Session.GetString("comid");
                    if (Acc_VoucherNoPrefix.userid == null)
                    {
                        Acc_VoucherNoPrefix.userid = HttpContext.Session.GetString("userid");
                    }
                    Acc_VoucherNoPrefix.useridUpdate = HttpContext.Session.GetString("userid");

                    db.Entry(Acc_VoucherNoPrefix).State = EntityState.Modified;
                    db.SaveChanges();

                }
                else
                {
                    Acc_VoucherNoPrefix.userid = HttpContext.Session.GetString("userid");
                    Acc_VoucherNoPrefix.comid = HttpContext.Session.GetString("comid");
                    Acc_VoucherNoPrefix.DateAdded = DateTime.Now;

                    db.Acc_VoucherNoPrefixes.Add(Acc_VoucherNoPrefix);
                    db.SaveChanges();

                    db.Entry(Acc_VoucherNoPrefix).GetDatabaseValues();
                    //int id = Acc_VoucherNoPrefix.VoucherNoPrefixId; // Yes it's here


                    //db.Categories.Add(Acc_VoucherNoPrefix);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");

            //return View(Acc_VoucherNoPrefix);
        }


        //[Authorize]
        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Acc_VoucherNoPrefix Acc_VoucherNoPrefix = db.Acc_VoucherNoPrefixes.Where(c => c.comid == HttpContext.Session.GetString("comid")).Where(c => c.VoucherNoPrefixId == id).FirstOrDefault();
            ViewBag.VoucherTypeId = new SelectList(db.Acc_VoucherTypes.Where(c => c.VoucherTypeId > 0), "VoucherTypeId", "VoucherTypeName");

            if (Acc_VoucherNoPrefix == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";

            return View("Create", Acc_VoucherNoPrefix);

        }


        //[Authorize]
        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            string comid = HttpContext.Session.GetString("comid");
            Acc_VoucherNoPrefix Acc_VoucherNoPrefix = db.Acc_VoucherNoPrefixes.Where(c => c.comid == comid).Where(c => c.VoucherNoPrefixId == id).FirstOrDefault();
            ViewBag.VoucherTypeId = new SelectList(db.Acc_VoucherTypes.Where(c => c.VoucherTypeId > 0), "VoucherTypeId", "VoucherTypeName");

            if (Acc_VoucherNoPrefix == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";

            return View("Create", Acc_VoucherNoPrefix);
        }
        //        //[Authorize]
        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        //      [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int? id)
        {
            try
            {

                Acc_VoucherNoPrefix Acc_VoucherNoPrefix = db.Acc_VoucherNoPrefixes.Where(c => c.comid == HttpContext.Session.GetString("comid")).Where(c => c.VoucherNoPrefixId == id).FirstOrDefault();

                db.Acc_VoucherNoPrefixes.Remove(Acc_VoucherNoPrefix);
                db.SaveChanges();

                return Json(new { Success = 1, VoucherNoPrefixId = Acc_VoucherNoPrefix.VoucherNoPrefixId, ex = "" });

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
