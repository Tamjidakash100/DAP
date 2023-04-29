using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HouseKeeping
{
    [OverridableAuthorize]
    public class DesignationController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public DesignationController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Designation
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            return View(await db.Cat_Designation.Include(c => c.Grade).ToListAsync());
        }

        // GET: Designation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat_Designation = await db.Cat_Designation
                .Include(c => c.Grade)
                .FirstOrDefaultAsync(m => m.DesigId == id);
            if (cat_Designation == null)
            {
                return NotFound();
            }

            return View(cat_Designation);
        }

        // GET: Designation/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.GradeId = new SelectList(db.Cat_Grade, "GradeId", "GradeName");
            return View();
        }

        // POST: Designation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DesigId,ComId,DesigName,DesigNameB,SlNo,Gsmin,GradeId,AttBonus,PcName,UserId,DateAdded,UpdateByUserId,DateUpdated,DtInput")] Cat_Designation cat_Designation)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Add(cat_Designation);
            //    await db.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["GradeId"] = new SelectList(db.Cat_Grade, "GradeId", "GradeName", cat_Designation.GradeId);
            //return View(cat_Designation);



            if (ModelState.IsValid)
            {
                cat_Designation.UserId = HttpContext.Session.GetString("userid");
                cat_Designation.ComId = HttpContext.Session.GetString("comid");

                cat_Designation.DateUpdated = DateTime.Today;
                cat_Designation.DtInput = DateTime.Today;
                cat_Designation.DateAdded = DateTime.Today;

                if (cat_Designation.DesigId > 0)
                {
                    cat_Designation.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(cat_Designation).State = EntityState.Modified;
                    await db.SaveChangesAsync();


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Designation.DesigId.ToString(), "Update", cat_Designation.DesigName.ToString());

                }
                else
                {
                    db.Add(cat_Designation);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Designation.DesigId.ToString(), "Create", cat_Designation.DesigName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(cat_Designation);
        }

        // GET: Designation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var cat_Designation = await db.Cat_Designation.FindAsync(id);
            ViewBag.GradeId = new SelectList(db.Cat_Grade, "GradeId", "GradeName", cat_Designation.GradeId);
            if (cat_Designation == null)
            {
                return NotFound();
            }

            return View("Create", cat_Designation);
        }


        // GET: Designation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat_Designation = await db.Cat_Designation
                .Include(c => c.Grade)
                .FirstOrDefaultAsync(m => m.DesigId == id);
            if (cat_Designation == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            ViewBag.GradeId = new SelectList(db.Cat_Grade, "GradeId", "GradeName", cat_Designation.GradeId);

            return View("Create", cat_Designation);

        }

        // POST: Designation/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {


            try
            {
                var Cat_Designation = await db.Cat_Designation.FindAsync(id);
                db.Cat_Designation.Remove(Cat_Designation);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Designation.DesigId.ToString(), "Delete", Cat_Designation.DesigName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, DesigId = Cat_Designation.DesigId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

        }

        private bool Cat_DesignationExists(int id)
        {
            return db.Cat_Designation.Any(e => e.DesigId == id);
        }
    }
}
