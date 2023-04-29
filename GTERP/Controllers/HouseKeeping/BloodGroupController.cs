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
    public class BloodGroupController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public BloodGroupController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Cat_BloodGroup
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");


            return View(await db.Cat_BloodGroup.ToListAsync());
        }


        // GET: Cat_BloodGroup/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.BloodId = new SelectList(db.Cat_BloodGroup, "BloodId", "BloodName");
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("BloodId,ComId,DeptCode,DeptName,Pcname,LuserId,DeptBangla,Slno,ParentId,Buid,Buname,DptSrtName,IsStrDpt")]*/ Cat_BloodGroup Cat_BloodGroup)
        {
            if (ModelState.IsValid)
            {
                Cat_BloodGroup.UserId = HttpContext.Session.GetString("userid");
                Cat_BloodGroup.ComId = HttpContext.Session.GetString("comid");
                if (Cat_BloodGroup.BloodId > 0)
                {
                    db.Entry(Cat_BloodGroup).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_BloodGroup.BloodId.ToString(), "Update", Cat_BloodGroup.BloodName.ToString());

                }
                else
                {
                    db.Add(Cat_BloodGroup);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_BloodGroup.BloodId.ToString(), "Create", Cat_BloodGroup.BloodName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(Cat_BloodGroup);
        }


        // GET: Cat_BloodGroup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var Cat_BloodGroup = await db.Cat_BloodGroup.FindAsync(id);
            ViewBag.BloodId = new SelectList(db.Cat_BloodGroup, "BloodId", "BloodName", Cat_BloodGroup.BloodId);
            if (Cat_BloodGroup == null)
            {
                return NotFound();
            }
            return View("Create", Cat_BloodGroup);
        }

        private bool Cat_FloorExists(int id)
        {
            return db.Cat_BloodGroup.Any(e => e.BloodId == id);
        }

        // GET: Cat_BloodGroup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_BloodGroup = await db.Cat_BloodGroup
                .FirstOrDefaultAsync(m => m.BloodId == id);

            if (Cat_BloodGroup == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            ViewBag.DeptId = new SelectList(db.Cat_BloodGroup, "BloodId", "BloodName", Cat_BloodGroup.BloodId);
            return View("Create", Cat_BloodGroup);
        }

        // POST: Cat_BloodGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var Cat_BloodGroup = await db.Cat_BloodGroup.FindAsync(id);
                db.Cat_BloodGroup.Remove(Cat_BloodGroup);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_BloodGroup.BloodId.ToString(), "Delete", Cat_BloodGroup.BloodName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, BloodId = Cat_BloodGroup.BloodId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }
    }
}
