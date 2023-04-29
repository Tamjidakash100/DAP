using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HouseKeeping
{
    [OverridableAuthorize]
    public class DiagnosisController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public DiagnosisController(GTRDBContext context, TransactionLogRepository tran)
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

            return View(await db.Cat_MedicalDiagnosis.ToListAsync());
        }



        // GET: Designation/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            //ViewBag.GradeId = new SelectList(db.Cat_MedicalDiagnosis, "GradeId", "GradeName");
            return View();
        }

        // POST: Designation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cat_MedicalDiagnosis cat_Diagnosis)
        {

            if (ModelState.IsValid)
            {
                cat_Diagnosis.UserId = HttpContext.Session.GetString("userid");
                cat_Diagnosis.ComId = HttpContext.Session.GetString("comid");

                cat_Diagnosis.DateUpdated = DateTime.Today;

                cat_Diagnosis.DateAdded = DateTime.Today;

                if (cat_Diagnosis.DiagId > 0)
                {
                    cat_Diagnosis.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(cat_Diagnosis).State = EntityState.Modified;
                    await db.SaveChangesAsync();


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Diagnosis.DiagId.ToString(), "Update", cat_Diagnosis.DiagName.ToString());

                }
                else
                {
                    db.Add(cat_Diagnosis);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Diagnosis.DiagId.ToString(), "Create", cat_Diagnosis.DiagName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(cat_Diagnosis);
        }

        // GET: Designation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var cat_Diagnosis = await db.Cat_MedicalDiagnosis.FindAsync(id);

            if (cat_Diagnosis == null)
            {
                return NotFound();
            }

            return View("Create", cat_Diagnosis);
        }


        // GET: Designation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat_Diagnosis = await db.Cat_MedicalDiagnosis
                .FirstOrDefaultAsync(m => m.DiagId == id);
            if (cat_Diagnosis == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";


            return View("Create", cat_Diagnosis);

        }

        // POST: Designation/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {


            try
            {
                var cat_Diagnosis = await db.Cat_MedicalDiagnosis.FindAsync(id);
                db.Cat_MedicalDiagnosis.Remove(cat_Diagnosis);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Diagnosis.DiagId.ToString(), "Delete", cat_Diagnosis.DiagName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, DiagId = cat_Diagnosis.DiagId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

        }

        private bool cat_DiagnosisExists(int id)
        {
            return db.Cat_MedicalDiagnosis.Any(e => e.DiagId == id);
        }
    }
}
