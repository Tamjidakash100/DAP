using DataTablesParser;
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
    public class NoteDescriptionController : Controller
    {
        private TransactionLogRepository tranlog;
        private GTRDBContext db;

        public NoteDescriptionController(GTRDBContext context, TransactionLogRepository tran)
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

            ViewBag.FiscalYear = new SelectList(db.Acc_FiscalYears.Where(f => f.comid == HttpContext.Session.GetString("comid")), "FiscalYearId", "FYName");
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            //return View(db.NoteDescriptions.Where(c => c.NoteDescriptionId > 0).ToList());
            // return View(db.NoteDescriptions.Include(x=>x.Acc_FiscalYears).Where(c => c.comid == HttpContext.Session.GetString("comid") && c.NoteDescriptionId > 0).ToList());
            return View();
        }

        public class NotesView
        {
            public string FYName { get; set; }
            public int SLNo { get; set; }
            public string NoteNo { get; set; }
            public string NoteDetails { get; set; }
            public string NoteRemarks { get; set; }
            public int NoteDescriptionId { get; set; }
        }


        public IActionResult Get(int fiscalYearId)
        {
            try
            {
                var comid = (HttpContext.Session.GetString("comid"));

                Microsoft.Extensions.Primitives.StringValues y = "";

                var x = Request.Form.TryGetValue("search[value]", out y);


                if (y.ToString().Length > 0)
                {


                    var query = from e in db.NoteDescriptions.Include(x => x.Acc_FiscalYears)
                                .Where(p => p.comid == comid)
                                select new NotesView
                                {
                                    NoteDescriptionId = e.NoteDescriptionId,
                                    FYName = e.Acc_FiscalYears.FYName,
                                    SLNo = e.SLNo,
                                    NoteDetails = e.NoteDetails,
                                    NoteRemarks = e.NoteRemarks,
                                    NoteNo = e.NoteNo
                                };


                    var parser = new Parser<NotesView>(Request.Form, query);

                    return Json(parser.Parse());

                }
                else
                {
                    if (fiscalYearId != 0)
                    {
                        var query = from e in db.NoteDescriptions.Include(x => x.Acc_FiscalYears)
                                .Where(p => p.comid == comid && p.FiscalYearId == fiscalYearId)
                                    select new NotesView
                                    {
                                        NoteDescriptionId = e.NoteDescriptionId,
                                        FYName = e.Acc_FiscalYears.FYName,
                                        SLNo = e.SLNo,
                                        NoteDetails = e.NoteDetails,
                                        NoteRemarks = e.NoteRemarks,
                                        NoteNo = e.NoteNo
                                    };

                        var parser = new Parser<NotesView>(Request.Form, query);
                        return Json(parser.Parse());
                    }
                    else
                    {
                        var query = from e in db.NoteDescriptions.Include(x => x.Acc_FiscalYears)
                             .Where(p => p.comid == comid)
                                    select new NotesView
                                    {
                                        NoteDescriptionId = e.NoteDescriptionId,
                                        FYName = e.Acc_FiscalYears.FYName,
                                        SLNo = e.SLNo,
                                        NoteDetails = e.NoteDetails,
                                        NoteRemarks = e.NoteRemarks,
                                        NoteNo = e.NoteNo
                                    };

                        var parser = new Parser<NotesView>(Request.Form, query);

                        return Json(parser.Parse());
                    }


                }
            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

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
        public ActionResult Create(NoteDescription NoteDescription)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            string comid = HttpContext.Session.GetString("comid");
            string userid = HttpContext.Session.GetString("userid");


            //if (ModelState.IsValid)
            //{
            if (NoteDescription.NoteDescriptionId > 0)
            {

                NoteDescription.DateUpdated = DateTime.Now;
                NoteDescription.comid = comid;

                if (NoteDescription.userid == null)
                {
                    NoteDescription.userid = userid;
                }
                NoteDescription.useridUpdate = userid;



                db.Entry(NoteDescription).State = EntityState.Modified;
                db.SaveChanges();

                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), NoteDescription.NoteDescriptionId.ToString(), "Update", NoteDescription.NoteDetails.ToString());





            }
            else
            {
                NoteDescription.userid = userid;
                NoteDescription.comid = comid;
                NoteDescription.DateAdded = DateTime.Now;





                db.NoteDescriptions.Add(NoteDescription);
                db.SaveChanges();

                TempData["Message"] = "Data Save Successfully";
                TempData["Status"] = "1";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), NoteDescription.NoteDescriptionId.ToString(), "Create", NoteDescription.NoteDetails.ToString());






                //db.Categories.Add(NoteDescription);
                return RedirectToAction("Index");
            }
            //}
            return RedirectToAction("Index");

            //return View(NoteDescription);
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

            NoteDescription NoteDescription = db.NoteDescriptions.Where(c => c.NoteDescriptionId == id && c.comid == comid).FirstOrDefault();
            //ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.comid == comid).Where(c => c.CategoryId > 0), "CategoryId", "Name");
            ViewBag.FiscalyearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(c => c.FYId).Where(c => c.FYId > 0 && c.comid == (HttpContext.Session.GetString("comid"))), "FYId", "FYName");

            if (NoteDescription == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";

            return View("Create", NoteDescription);

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

            NoteDescription NoteDescription = db.NoteDescriptions.Where(c => c.NoteDescriptionId == id && c.comid == comid).FirstOrDefault();
            //ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.comid == comid).Where(c => c.CategoryId > 0), "CategoryId", "Name");
            ViewBag.FiscalyearId = new SelectList(db.Acc_FiscalYears.OrderByDescending(c => c.FYId).Where(c => c.FYId > 0 && c.comid == (HttpContext.Session.GetString("comid"))), "FYId", "FYName");

            if (NoteDescription == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";

            return View("Create", NoteDescription);
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
                NoteDescription NoteDescription = db.NoteDescriptions.Where(c => c.comid == comid && c.NoteDescriptionId == id).FirstOrDefault();

                db.NoteDescriptions.Remove(NoteDescription);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), NoteDescription.NoteDescriptionId.ToString(), "Delete", NoteDescription.NoteDetails);


                return Json(new { Success = 1, NoteDescriptionId = NoteDescription.NoteDescriptionId, ex = "" });

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
