using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace GTERP.Controllers.Account
{
    [OverridableAuthorize]
    public class VoucherTranGroupController : Controller
    {
        private GTRDBContext db;

        public VoucherTranGroupController(GTRDBContext context)
        {
            db = context;
        }

        //[Authorize]
        // GET: Categories
        public ActionResult Index()
        {
            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            //return View(db.VoucherTranGroups.Where(c => c.VoucherTranGroupId > 0).ToList());
            return View(db.VoucherTranGroups.Where(x => x.comid == comid).ToList());

        }

        //[Authorize]
        // GET: Categories/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";


            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VoucherTranGroup VoucherTranGroups)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            var comid = HttpContext.Session.GetString("comid");
            var userid = HttpContext.Session.GetString("userid");

            //if (ModelState.IsValid)
            {
                if (VoucherTranGroups.VoucherTranGroupId > 0)
                {

                    db.Entry(VoucherTranGroups).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    VoucherTranGroups.comid = comid;
                    VoucherTranGroups.userid = userid;

                    db.VoucherTranGroups.Add(VoucherTranGroups);
                    db.SaveChanges();


                    db.Entry(VoucherTranGroups).GetDatabaseValues();
                    //int id = VoucherTranGroup.VoucherTranGroupId; // Yes it's here



                    //db.Categories.Add(VoucherTranGroup);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");

            //return View(VoucherTranGroup);
        }


        //[Authorize]
        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            VoucherTranGroup VoucherTranGroup = db.VoucherTranGroups.Where(c => c.VoucherTranGroupId == id).FirstOrDefault();


            if (VoucherTranGroup == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";

            return View("Create", VoucherTranGroup);

        }


        //[Authorize]
        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            VoucherTranGroup VoucherTranGroup = db.VoucherTranGroups.Where(c => c.VoucherTranGroupId == id).FirstOrDefault();


            if (VoucherTranGroup == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";

            return View("Create", VoucherTranGroup);
        }
        //        //[Authorize]
        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        //      [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int? id)
        {
            try
            {

                VoucherTranGroup VoucherTranGroup = db.VoucherTranGroups.Where(c => c.VoucherTranGroupId == id).FirstOrDefault();

                db.VoucherTranGroups.Remove(VoucherTranGroup);
                db.SaveChanges();

                return Json(new { Success = 1, VoucherTranGroupId = VoucherTranGroup.VoucherTranGroupId, ex = "" });

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
