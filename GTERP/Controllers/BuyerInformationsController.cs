using GTERP;
using GTERP.AppData;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace GTCommercial.Controllers
{
    [OverridableAuthorize]
    public class BuyerInformationsController : Controller
    {
        private GTRDBContext db;
        public BuyerInformationsController(GTRDBContext context)
        {
            db = context;
        }
        //UserLog //UserLog;


        // GET: BuyerInformations
        //[OverridableAuthorize]
        public ActionResult Index()
        {
            return View(db.BuyerInformation.ToList());
        }


        // GET: BuyerInformations/Create
        //[OverridableAuthorize]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";

            ViewBag.BuyerGroupId = new SelectList(db.BuyerGroups, "BuyerGroupId", "BuyerGroupName");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            ViewBag.EmployeeIdImport = new SelectList(db.Employee, "EmployeeId", "EmployeeName");
            ViewBag.EmployeeIdExport = new SelectList(db.Employee, "EmployeeId", "EmployeeName");

            return View();
        }

        // POST: BuyerInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        //[OverridableAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind("BuyerId,BuyerGroupId,EmployeeIdExport,EmployeeIdImport,BuyerName , BuyerSearchName,CountryId,ContactPerson,Address,Address2,ShippingMarks,LocalOffice,LCMargin,DefferredPaymentDays,Addedby,Dateadded,Updatedby,Dateupdated,DiscountPercentage , CMPPercentage")]*/ BuyerInformation buyerInformation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.BuyerInformation.Add(buyerInformation);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(buyerInformation);
        //}

        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (buyerInformation.BuyerId > 0)
                    {
                        buyerInformation.userid = HttpContext.Session.GetString("userid");
                        buyerInformation.DateUpdated = DateTime.Now;
                        buyerInformation.comid = (AppData.intComId);
                        db.Entry(buyerInformation).State = EntityState.Modified;
                        db.SaveChanges();
                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), buyerInformation.BuyerId.ToString(), "Update");
                    }
                    else
                    {
                        buyerInformation.userid = HttpContext.Session.GetString("userid");
                        buyerInformation.DateAdded = DateTime.Now;
                        buyerInformation.DateUpdated = DateTime.Now;
                        buyerInformation.comid = (AppData.intComId);

                        db.BuyerInformation.Add(buyerInformation);
                        db.SaveChanges();
                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), buyerInformation.BuyerId.ToString(), "Create");
                    }
                    return RedirectToAction("Index");
                }

                ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryCode", buyerInformation.CountryId);
                ViewBag.BuyerGroupId = new SelectList(db.BuyerGroups, "BuyerGroupId", "BuyerGroupName", buyerInformation.CountryId);

                ViewBag.EmployeeIdImport = new SelectList(db.Employee, "EmployeeId", "EmployeeName", buyerInformation.EmployeeIdImport);
                ViewBag.EmployeeIdExport = new SelectList(db.Employee, "EmployeeId", "EmployeeName", buyerInformation.EmployeeIdExport);



                return View(buyerInformation);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Unable to Save / Update";
                buyerInformation.BuyerId = 0;
                TempData["Status"] = "0";

                throw ex;
            }
        }
        // GET: BuyerInformations/Edit/5

        //[OverridableAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Edit";
            //int ContactID = int.Parse(id);

            BuyerInformation buyerinformation = db.BuyerInformation.Where(m => m.BuyerId.ToString() == id.ToString()).FirstOrDefault(); //Find(id);// 
            if (buyerinformation == null)
            {
                return NotFound();
            }
            ViewBag.BuyerGroupId = new SelectList(db.BuyerGroups, "BuyerGroupId", "BuyerGroupName", buyerinformation.BuyerGroupId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", buyerinformation.CountryId);
            ViewBag.EmployeeIdImport = new SelectList(db.Employee, "EmployeeId", "EmployeeName", buyerinformation.EmployeeIdImport);
            ViewBag.EmployeeIdExport = new SelectList(db.Employee, "EmployeeId", "EmployeeName", buyerinformation.EmployeeIdExport);
            return View("Create", buyerinformation);
        }



        // GET: BuyerInformations/Delete/5
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.Title = "Delete";

            BuyerInformation buyerinformation = db.BuyerInformation.Where(m => m.BuyerId.ToString() == id.ToString()).FirstOrDefault(); //Find(id);//
            if (buyerinformation == null)
            {
                return NotFound();
            }
            ViewBag.BuyerGroupId = new SelectList(db.BuyerGroups, "BuyerGroupId", "BuyerGroupName", buyerinformation.BuyerGroupId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", buyerinformation.CountryId);
            ViewBag.EmployeeIdImport = new SelectList(db.Employee, "EmployeeId", "EmployeeName", buyerinformation.EmployeeIdImport);
            ViewBag.EmployeeIdExport = new SelectList(db.Employee, "EmployeeId", "EmployeeName", buyerinformation.EmployeeIdExport);
            return View("Create", buyerinformation);
        }

        // POST: BuyerInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        //[ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {

                BuyerInformation buyerInformation = db.BuyerInformation.Where(m => m.BuyerId.ToString() == id.ToString()).FirstOrDefault(); //Find(id);//

                db.BuyerInformation.Remove(buyerInformation);
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                //UserLog.TransactionLog(ControllerContext.HttpContext.Request, Session, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), id.ToString(), "Delete");
                return Json(new { Success = 1, ContactID = buyerInformation.BuyerId, ex = TempData["Message"].ToString() });

            }

            catch (Exception ex)
            {
                TempData["Message"] = "Unable to Delete the Data.";
                TempData["Status"] = "3";
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }

            // return Json(new { Success = 0, ex = new Exception("Unable to Delete").Message.ToString() });
            // return RedirectToAction("Index");
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
