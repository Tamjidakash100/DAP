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
    public class ReligionController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public ReligionController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Cat_Religion
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");


            return View(await db.Cat_Religion.ToListAsync());
        }


        // GET: Cat_Religion/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.RelgionId = new SelectList(db.Cat_Religion, "RelgionId", "ReligionName");
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("RelgionId,ComId,DeptCode,DeptName,Pcname,LuserId,DeptBangla,Slno,ParentId,Buid,Buname,DptSrtName,IsStrDpt")]*/ Cat_Religion Cat_Religion)
        {
            if (ModelState.IsValid)
            {
                Cat_Religion.UserId = HttpContext.Session.GetString("userid");
                Cat_Religion.ComId = HttpContext.Session.GetString("comid");
                if (Cat_Religion.RelgionId > 0)
                {
                    db.Entry(Cat_Religion).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Religion.RelgionId.ToString(), "Update", Cat_Religion.ReligionName.ToString());

                }
                else
                {
                    db.Add(Cat_Religion);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Religion.RelgionId.ToString(), "Create", Cat_Religion.ReligionName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(Cat_Religion);
        }


        // GET: Cat_Religion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var Cat_Religion = await db.Cat_Religion.FindAsync(id);
            ViewBag.RelgionId = new SelectList(db.Cat_Religion, "RelgionId", "ReligionName", Cat_Religion.RelgionId);
            if (Cat_Religion == null)
            {
                return NotFound();
            }
            return View("Create", Cat_Religion);
        }

        private bool Cat_FloorExists(int id)
        {
            return db.Cat_Religion.Any(e => e.RelgionId == id);
        }

        // GET: Cat_Religion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_Religion = await db.Cat_Religion
                .FirstOrDefaultAsync(m => m.RelgionId == id);

            if (Cat_Religion == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            ViewBag.DeptId = new SelectList(db.Cat_Religion, "RelgionId", "ReligionName", Cat_Religion.RelgionId);
            return View("Create", Cat_Religion);
        }

        // POST: Cat_Religion/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var Cat_Religion = await db.Cat_Religion.FindAsync(id);
                db.Cat_Religion.Remove(Cat_Religion);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Religion.RelgionId.ToString(), "Delete", Cat_Religion.ReligionName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, RelgionId = Cat_Religion.RelgionId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }
    }
}
