using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GTERP.Controllers.HouseKeeping
{
    [OverridableAuthorize]
    public class IncomeTaxController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public IncomeTaxController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Section
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            //var sectio
            return View(await db.Cat_IncomeTaxChk.ToListAsync());
        }
        public class Pross
        {
            public string ProssType { get; set; }
            public DateTime dtInput { get; set; }
        }

        // GET: Section/Create
        public IActionResult Create()
        {

            ViewBag.Title = "Create";
            string comid = HttpContext.Session.GetString("comid");

            SqlParameter[] parameter1 = new SqlParameter[1];
            parameter1[0] = new SqlParameter("@ComId", comid);
            var prossType = Helper.ExecProcMapTList<Pross>("GetProssType", parameter1);
            ViewBag.ProssType = new SelectList(prossType, "ProssType", "ProssType");

            return View();
        }

        // POST: Section/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cat_IncomeTaxChk cat_IncomeTaxChk)
        {
            if (ModelState.IsValid)
            {
                cat_IncomeTaxChk.UserId = HttpContext.Session.GetString("userid");
                cat_IncomeTaxChk.ComId = HttpContext.Session.GetString("comid");

                if (cat_IncomeTaxChk.Id > 0)
                {
                    cat_IncomeTaxChk.DateUpdated = DateTime.Today;
                    cat_IncomeTaxChk.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(cat_IncomeTaxChk).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_IncomeTaxChk.Id.ToString(), "Update", cat_IncomeTaxChk.Id.ToString());

                }
                else
                {
                    cat_IncomeTaxChk.DateAdded = DateTime.Today;
                    db.Add(cat_IncomeTaxChk);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_IncomeTaxChk.Id.ToString(), "Create", cat_IncomeTaxChk.Id.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(cat_IncomeTaxChk);
        }

        // GET: Section/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var cat_IncomeTaxChk = await db.Cat_IncomeTaxChk.FindAsync(id);
            string comid = HttpContext.Session.GetString("comid");

            SqlParameter[] parameter1 = new SqlParameter[1];
            parameter1[0] = new SqlParameter("@ComId", comid);
            var prossType = Helper.ExecProcMapTList<Pross>("GetProssType", parameter1);
            ViewBag.ProssType = new SelectList(prossType, "ProssType", "ProssType", cat_IncomeTaxChk.ProssType);
            if (cat_IncomeTaxChk == null)
            {
                return NotFound();
            }
            return View("Create", cat_IncomeTaxChk);
        }


        // GET: Section/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat_IncomeTaxChk = await db.Cat_IncomeTaxChk
               .FirstOrDefaultAsync(m => m.Id == id);
            if (cat_IncomeTaxChk == null)
            {
                return NotFound();
            }

            string comid = HttpContext.Session.GetString("comid");
            ViewBag.Title = "Delete";
            SqlParameter[] parameter1 = new SqlParameter[1];
            parameter1[0] = new SqlParameter("@ComId", comid);
            var prossType = Helper.ExecProcMapTList<Pross>("GetProssType", parameter1);
            ViewBag.ProssType = new SelectList(prossType, "ProssType", "ProssType", cat_IncomeTaxChk.ProssType);



            return View("Create", cat_IncomeTaxChk);




        }

        // POST: Section/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var cat_IncomeTaxChk = await db.Cat_IncomeTaxChk.FindAsync(id);
                db.Cat_IncomeTaxChk.Remove(cat_IncomeTaxChk);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_IncomeTaxChk.Id.ToString(), "Delete", cat_IncomeTaxChk.Id.ToString());
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, SectId = cat_IncomeTaxChk.Id, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

    }
}
