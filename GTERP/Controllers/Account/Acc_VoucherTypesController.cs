using GTERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace GTERP.Controllers.Account
{
    [OverridableAuthorize]
    public class Acc_VoucherTypesController : Controller
    {
        private GTRDBContext db;

        public Acc_VoucherTypesController(GTRDBContext context)
        {
            db = context;
        }

        //[Authorize]
        // GET: Categories
        public ActionResult Index()
        {
            //return View(db.Acc_VoucherTypes.Where(c => c.VoucherTypeId > 0).ToList());
            return View(db.Acc_VoucherTypes.ToList());

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
        public ActionResult Create(Acc_VoucherType Acc_VoucherType)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });



            //if (ModelState.IsValid)
            {
                if (Acc_VoucherType.VoucherTypeId > 0)
                {

                    db.Entry(Acc_VoucherType).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {

                    db.Acc_VoucherTypes.Add(Acc_VoucherType);
                    db.SaveChanges();


                    db.Entry(Acc_VoucherType).GetDatabaseValues();
                    //int id = Acc_VoucherType.VoucherTypeId; // Yes it's here



                    //db.Categories.Add(Acc_VoucherType);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");

            //return View(Acc_VoucherType);
        }


        //[Authorize]
        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Acc_VoucherType Acc_VoucherType = db.Acc_VoucherTypes.Where(c => c.VoucherTypeId == id).FirstOrDefault();


            if (Acc_VoucherType == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";

            return View("Create", Acc_VoucherType);

        }


        //[Authorize]
        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Acc_VoucherType Acc_VoucherType = db.Acc_VoucherTypes.Where(c => c.VoucherTypeId == id).FirstOrDefault();


            if (Acc_VoucherType == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";

            return View("Create", Acc_VoucherType);
        }
        //        //[Authorize]
        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        //      [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int? id)
        {
            try
            {

                Acc_VoucherType Acc_VoucherType = db.Acc_VoucherTypes.Where(c => c.VoucherTypeId == id).FirstOrDefault();

                db.Acc_VoucherTypes.Remove(Acc_VoucherType);
                db.SaveChanges();

                return Json(new { Success = 1, VoucherTypeId = Acc_VoucherType.VoucherTypeId, ex = "" });

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
