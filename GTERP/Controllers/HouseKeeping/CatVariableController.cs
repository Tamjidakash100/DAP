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
    public class CatVariableController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public CatVariableController(GTRDBContext context, TransactionLogRepository tran)
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
            return View(await db.Cat_Variable.ToListAsync());
        }


        // GET: Section/Create
        public IActionResult Create()
        {
            string comid = HttpContext.Session.GetString("comid");
            ViewBag.Title = "Create";
            //ViewBag.VarType = new SelectList(db.Cat_Variable
            //    .Where(v => v.ComId==comid).GroupBy(v=>v.VarType), "VarType", "VarType");
            var data = db.Cat_Variable.GroupBy(p => p.VarType)
                          .Select(g => new
                          {
                              VarType = g.Key,
                              Count = g.Count()
                          })
                          .ToList();
            ViewBag.VarType = new SelectList(data, "VarType", "VarType");


            return View();
        }

        // POST: Section/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cat_Variable cat_Variable)
        {
            if (ModelState.IsValid)
            {
                cat_Variable.UserId = HttpContext.Session.GetString("userid");
                cat_Variable.ComId = HttpContext.Session.GetString("comid");

                cat_Variable.DateUpdated = DateTime.Today;

                cat_Variable.DateAdded = DateTime.Today;

                if (cat_Variable.VarId > 0)
                {
                    cat_Variable.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(cat_Variable).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Variable.VarId.ToString(), "Update", cat_Variable.VarName);

                }
                else
                {
                    db.Add(cat_Variable);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Variable.VarId.ToString(), "Create", cat_Variable.VarName);

                }
                return RedirectToAction(nameof(Index));
            }
            return View(cat_Variable);
        }

        // GET: Section/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var cat_Variable = await db.Cat_Variable.FindAsync(id);
            ViewBag.DeptId = new SelectList(db.Cat_Department, "DeptId", "DeptName", cat_Variable.VarId);
            if (cat_Variable == null)
            {
                return NotFound();
            }
            var data = db.Cat_Variable.GroupBy(p => p.VarType)
                          .Select(g => new
                          {
                              VarType = g.Key,
                              Count = g.Count()
                          })
                          .ToList();
            ViewBag.VarType = new SelectList(data, "VarType", "VarType", cat_Variable.VarType);
            return View("Create", cat_Variable);
        }


        // GET: Section/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat_Variable = await db.Cat_Variable
               .FirstOrDefaultAsync(m => m.VarId == id);
            if (cat_Variable == null)
            {
                return NotFound();
            }


            ViewBag.Title = "Delete";
            var data = db.Cat_Variable.GroupBy(p => p.VarType)
                          .Select(g => new
                          {
                              VarType = g.Key,
                              Count = g.Count()
                          })
                          .ToList();
            ViewBag.VarType = new SelectList(data, "VarType", "VarType", cat_Variable.VarType);

            return View("Create", cat_Variable);




        }

        // POST: Section/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var cat_Variable = await db.Cat_Variable.FindAsync(id);
                db.Cat_Variable.Remove(cat_Variable);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Variable.VarId.ToString(), "Delete", cat_Variable.VarName);
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, VarId = cat_Variable.VarId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool cat_VariableExists(int id)
        {
            return db.Cat_Variable.Any(e => e.VarId == id);
        }
    }
}
