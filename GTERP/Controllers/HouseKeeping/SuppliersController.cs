using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTERP.Controllers.Controllers
{
    [OverridableAuthorize]
    public class SuppliersController : Controller
    {
        private TransactionLogRepository tranlog;
        private GTRDBContext db = new GTRDBContext();


        public SuppliersController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;

        }

        // GET: Suppliers
        public ActionResult Index()
        {

            //var products = db.Products
            //.Include(p => p.vPrimaryCategory)
            //.Where(p => p.ProductId > 1 && p.comid == AppData.AppData.intcomid);
            //return View(products.ToList());

            //int comid = HttpContext.Session.GetString("comid");

            var suppliers = db.Suppliers.Where(s => s.comid == HttpContext.Session.GetString("comid")); //.Where(s => s.comid == HttpContext.Session.GetString("comid"))
                                                                                                        //var x = suppliers.ToList();
            return View(suppliers.ToList());
        }



        // GET: Suppliers/Create
        public ActionResult Create()
        {
            Supplier abc = new Supplier();

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            ViewBag.DistId = new SelectList(db.Cat_District, "DistId", "DistName");
            abc.OpBalance = 0;
            ViewBag.Title = "Create";
            return View(abc);
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            //if (ModelState.IsValid)
            //{

            if (supplier.SupplierId > 0)
            {
                ViewBag.Title = "Edit";

                supplier.DateUpdated = DateTime.Now;
                supplier.comid = HttpContext.Session.GetString("comid");

                if (supplier.userid == null)
                {
                    supplier.userid = HttpContext.Session.GetString("userid");
                }
                supplier.useridUpdate = HttpContext.Session.GetString("userid");

                //supplier.comid = HttpContext.Session.GetString("comid");
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Title = "Create";

                supplier.userid = HttpContext.Session.GetString("userid");
                supplier.comid = HttpContext.Session.GetString("comid");

                supplier.DateAdded = DateTime.Now;

                //supplier.comid = HttpContext.Session.GetString("comid"); // Session["comid"].ToString()
                db.Suppliers.Add(supplier);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
            //}

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", supplier.CountryId);
            return View(supplier);
        }



        // GET: Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Supplier supplier = db.Suppliers.Find(id);
            Supplier supplier = db.Suppliers.Where(c => c.comid == HttpContext.Session.GetString("comid") && c.SupplierId == id).FirstOrDefault();
            if (supplier == null)
            {
                return NotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", supplier.CountryId);
            ViewBag.DistId = new SelectList(db.Cat_District, "DistId", "DistName", supplier.DistId);
            ViewBag.Title = "Edit";
            return View("Create", supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("SupplierId,SupplierCode,SupplierName,EmailId,CountryId,PrimaryAddress,SecoundaryAddress,PostalCode,City,PhoneNo,IsInActive,OpBalance")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.comid = HttpContext.Session.GetString("comid");
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", supplier.CountryId);
            ViewBag.DistId = new SelectList(db.Cat_District, "DistId", "DistName", supplier.DistId);
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Supplier supplier = db.Suppliers.Where(c => c.comid == HttpContext.Session.GetString("comid") && c.SupplierId == id).FirstOrDefault();
            if (supplier == null)
            {
                return NotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", supplier.CountryId);
            ViewBag.DistId = new SelectList(db.Cat_District, "DistId", "DistName", supplier.DistId);
            ViewBag.Title = "Delete";
            return View("Create", supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {

                Supplier supplier = db.Suppliers.Find(id);
                db.Suppliers.Remove(supplier);
                db.SaveChanges();
                return Json(new { Success = 1, SupplierId = supplier.SupplierId, ex = "" });

            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to Delete").Message.ToString() });
            // return RedirectToAction("Index");
        }


        public JsonResult getPoliceStation(int id)
        {
            List<Cat_PoliceStation> PStation = db.Cat_PoliceStation.Where(x => x.DistId == id).ToList();

            List<SelectListItem> lipstation = new List<SelectListItem>();

            //licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
            if (PStation != null)
            {
                foreach (Cat_PoliceStation x in PStation)
                {
                    lipstation.Add(new SelectListItem { Text = x.PStationName, Value = x.PStationId.ToString() });
                }
            }
            return Json(new SelectList(lipstation, "Value", "Text"));
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
