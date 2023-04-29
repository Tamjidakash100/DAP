using GTERP.BLL;
using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]
    public class EmpReleasedsController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public EmpReleasedsController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: EmpReleaseds
        public async Task<IActionResult> Index()
        {
            //var gTRDBContext = db.HR_Emp_Released.Include(h => h.Emp);
            //return View(await gTRDBContext.ToListAsync());
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");


            return View(await db.HR_Emp_Released.Include(h => h.HR_Emp_Info).Include(h => h.HR_Emp_Info.Cat_Designation).ToListAsync());

        }



        // GET: EmpReleaseds/Create
        public IActionResult Create()
        {
            var comid = HttpContext.Session.GetString("comid");

            ViewBag.Title = "Create";
            //ViewBag.EmpId = new SelectList(db.HR_Emp_Info, "EmpId", "EmpName");
            //ViewBag.EmpId = db.HR_Emp_Info.Select(x => new SelectListItem()
            //{ Value = x.EmpId.ToString(), Text = x.EmpName+" || "+x.EmpCode }).ToList();

            ViewBag.EmpId = new SelectList(db.HR_Emp_Info
                .Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
                .ToList(), "Value", "Text");

            ViewBag.RelType = new SelectList(db.Cat_Variable
                .Where(v => v.ComId == comid && v.VarType == "ReleasedType")
                .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            return View();
        }

        // POST: EmpReleaseds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HR_Emp_Released HR_Emp_Released)
        {
            var comid = HttpContext.Session.GetString("comid");
            if (ModelState.IsValid)
            {
                HR_Emp_Released.UserId = HttpContext.Session.GetString("userid");
                HR_Emp_Released.ComId = HttpContext.Session.GetString("comid");

                if (HR_Emp_Released.RelId > 0)
                {
                    HR_Emp_Released.DateUpdated = DateTime.Today;
                    HR_Emp_Released.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(HR_Emp_Released).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), HR_Emp_Released.EmpId.ToString(), "Update", HR_Emp_Released.EmpId.ToString());
                }
                else
                {
                    HR_Emp_Released.DateAdded = DateTime.Today;
                    db.Add(HR_Emp_Released);

                    var empinfo = await db.HR_Emp_Info.FindAsync(HR_Emp_Released.EmpId);
                    if (empinfo != null)
                    {
                        empinfo.IsInactive = true;
                        db.Entry(empinfo).State = EntityState.Modified;
                    }

                    await db.SaveChangesAsync();


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), HR_Emp_Released.EmpId.ToString(), "Create", HR_Emp_Released.HR_Emp_Info.ToString());

                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.EmpId = new SelectList(db.HR_Emp_Info
               .Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
               .ToList(), "Value", "Text");

            ViewBag.RelType = new SelectList(db.Cat_Variable
               .Where(v => v.ComId == comid && v.VarType == "ReleasedType")
               .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName");

            return View(HR_Emp_Released);

        }

        // GET: EmpReleaseds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var comid = HttpContext.Session.GetString("comid");
            ViewBag.Title = "Edit";
            var HR_Emp_Released = await db.HR_Emp_Released.FindAsync(id);
            //ViewBag.EmpId = new SelectList(db.HR_Emp_Info, "EmpId", "EmpName", HR_Emp_Released.EmpId);
            ViewBag.EmpId = new SelectList(db.HR_Emp_Info
                .Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
                .ToList(), "Value", "Text", HR_Emp_Released.EmpId);

            ViewBag.RelType = new SelectList(db.Cat_Variable
               .Where(v => v.ComId == comid && v.VarType == "ReleasedType")
               .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName", HR_Emp_Released.RelType);
            if (HR_Emp_Released == null)
            {
                return NotFound();
            }

            return View("Create", HR_Emp_Released);
        }

        // POST: EmpReleaseds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        // GET: EmpReleaseds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var comid = HttpContext.Session.GetString("comid");
            var HR_Emp_Released = await db.HR_Emp_Released
                .Include(h => h.HR_Emp_Info)
                .FirstOrDefaultAsync(m => m.RelId == id);
            if (HR_Emp_Released == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            //ViewBag.Empid = new SelectList(db.HR_Emp_Info, "EmpId", "EmpName", HR_Emp_Released.EmpId);
            ViewBag.EmpId = new SelectList(db.HR_Emp_Info
                .Select(s => new { Text = s.EmpName + " - [ " + s.EmpCode + " ]", Value = s.EmpId })
                .ToList(), "Value", "Text", HR_Emp_Released.EmpId);

            ViewBag.RelType = new SelectList(db.Cat_Variable
              .Where(v => v.ComId == comid && v.VarType == "ReleasedType")
              .OrderBy(v => v.SLNo).ToList(), "VarName", "VarName", HR_Emp_Released.RelType);

            return View("Create", HR_Emp_Released);


        }

        // POST: EmpReleaseds/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                var HR_Emp_Released = await db.HR_Emp_Released.FindAsync(id);
                db.HR_Emp_Released.Remove(HR_Emp_Released);


                var empinfo = await db.HR_Emp_Info.Where(e => e.EmpId == HR_Emp_Released.EmpId).FirstOrDefaultAsync();
                if (empinfo != null)
                {
                    empinfo.IsInactive = false;
                    db.Entry(empinfo).State = EntityState.Modified;

                }
                db.SaveChanges();
                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), HR_Emp_Released.EmpId.ToString(), "Delete", HR_Emp_Released.HR_Emp_Info.ToString());

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, RelId = HR_Emp_Released.RelId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool HR_Emp_ReleasedExists(int id)
        {
            return db.HR_Emp_Released.Any(e => e.RelId == id);
        }
    }
}
