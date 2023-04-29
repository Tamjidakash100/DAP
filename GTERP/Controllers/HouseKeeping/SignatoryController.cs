using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HouseKeeping
{
    //[OverridableAuthorize(typeof(OverridableAuthorize))]
    //[TypeFilter(typeof(OverridableAuthorize))] --- working for onoverrride 
    [OverridableAuthorize]
    public class SignatoryController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public SignatoryController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        public static List<SelectListItem> ReportNames = new List<SelectListItem>()
        {
            new SelectListItem() {Text="Daily Production Report", Value="Daily Production Report"},
            new SelectListItem() {Text="Fax Report", Value="Fax Report"},
            new SelectListItem() {Text="MIS Report", Value="MIS Report"},
            new SelectListItem() {Text="DownTime Report", Value="DownTime Report"},
            new SelectListItem() {Text="U Ration Report", Value="U Ration Report"},
            new SelectListItem() {Text="Monthly Production Report", Value="Monthly Production Report"},
            new SelectListItem() {Text="Monthly Sales Report", Value="Monthly Sales Report"}
        };

        // GET: Signatory
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";

            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            return View(await db.Cat_ReportSignatory.ToListAsync());
        }


        // GET: Signatory/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.ReportName = new SelectList(ReportNames, "Value", "Text");
            //ViewBag.SignatoryId = new SelectList(db.Cat_ReportSignatory, "SignatoryId", "ReportName");
            return View();
        }

        // POST: Signatory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("SignatoryId,ComId,DeptCode,ReportName,Pcname,LuserId,DeptBangla,Slno,ParentId,Buid,Buname,DptSrtName,IsStrDpt")]*/ Cat_ReportSignatory Signatory)
        {
            if (ModelState.IsValid)
            {
                Signatory.UserId = HttpContext.Session.GetString("userid");
                Signatory.ComId = HttpContext.Session.GetString("comid");
                if (Signatory.SignatoryId > 0)
                {
                    db.Entry(Signatory).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Signatory.SignatoryId.ToString(), "Update", Signatory.ReportName.ToString());

                }
                else
                {
                    db.Add(Signatory);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Signatory.SignatoryId.ToString(), "Create", Signatory.ReportName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(Signatory);
        }

        // GET: Signatory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var Signatory = await db.Cat_ReportSignatory.FindAsync(id);
            ViewBag.ReportName = new SelectList(ReportNames, "Value", "Text", Signatory.ReportName);
            //ViewBag.SignatoryId = new SelectList(db.Cat_ReportSignatory, "SignatoryId", "ReportName", Signatory.ParentId);
            if (Signatory == null)
            {
                return NotFound();
            }
            return View("Create", Signatory);
        }

        // GET: Signatory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Signatory = await db.Cat_ReportSignatory
                .FirstOrDefaultAsync(m => m.SignatoryId == id);

            if (Signatory == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            ViewBag.ReportName = new SelectList(ReportNames, "Value", "Text", Signatory.ReportName);
            //ViewBag.SignatoryId = new SelectList(db.Cat_ReportSignatory, "SignatoryId", "ReportName", Signatory.ParentId);
            return View("Create", Signatory);
        }

        // POST: Signatory/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var Signatory = await db.Cat_ReportSignatory.FindAsync(id);
                db.Cat_ReportSignatory.Remove(Signatory);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Signatory.SignatoryId.ToString(), "Delete", Signatory.ReportName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, SignatoryId = Signatory.SignatoryId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }


        //public IActionResult IsExist(string ReportName,int SignatoryId)
        //{
        //    if (ViewBag.Title == "Create")
        //        return Json(!db.Cat_ReportSignatory.Any(d => d.ReportName == ReportName));
        //    else
        //        return Json(!db.Cat_ReportSignatory.Any(d => d.ReportName == ReportName));
        //}


        private bool SignatoryExists(int id)
        {
            return db.Cat_ReportSignatory.Any(e => e.SignatoryId == id);
        }
    }
}