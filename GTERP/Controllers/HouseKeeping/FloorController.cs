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
    public class FloorController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public FloorController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Cat_Floor
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");


            return View(await db.Cat_Floor.ToListAsync());
        }


        // GET: Cat_Floor/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.FloorId = new SelectList(db.Cat_Floor, "FloorId", "FloorName");
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("FloorId,ComId,DeptCode,DeptName,Pcname,LuserId,DeptBangla,Slno,ParentId,Buid,Buname,DptSrtName,IsStrDpt")]*/ Cat_Floor Cat_Floor)
        {
            if (ModelState.IsValid)
            {
                Cat_Floor.UserId = HttpContext.Session.GetString("userid");
                Cat_Floor.ComId = HttpContext.Session.GetString("comid");
                if (Cat_Floor.FloorId > 0)
                {
                    db.Entry(Cat_Floor).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Floor.FloorId.ToString(), "Update", Cat_Floor.FloorName.ToString());

                }
                else
                {
                    db.Add(Cat_Floor);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Floor.FloorId.ToString(), "Create", Cat_Floor.FloorName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(Cat_Floor);
        }


        // GET: Cat_Floor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var Cat_Floor = await db.Cat_Floor.FindAsync(id);
            ViewBag.FloorId = new SelectList(db.Cat_Floor, "FloorId", "FloorName", Cat_Floor.FloorId);
            if (Cat_Floor == null)
            {
                return NotFound();
            }
            return View("Create", Cat_Floor);
        }

        private bool Cat_FloorExists(int id)
        {
            return db.Cat_Floor.Any(e => e.FloorId == id);
        }

        // GET: Cat_Floor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_Floor = await db.Cat_Floor
                .FirstOrDefaultAsync(m => m.FloorId == id);

            if (Cat_Floor == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            ViewBag.DeptId = new SelectList(db.Cat_Floor, "FloorId", "FloorName", Cat_Floor.FloorId);
            return View("Create", Cat_Floor);
        }

        // POST: Cat_Floor/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var Cat_Floor = await db.Cat_Floor.FindAsync(id);
                db.Cat_Floor.Remove(Cat_Floor);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Floor.FloorId.ToString(), "Delete", Cat_Floor.FloorName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, FloorId = Cat_Floor.FloorId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }
    }
}
