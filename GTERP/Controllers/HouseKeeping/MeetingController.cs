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
    public class MeetingController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public MeetingController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Meeting
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            //var sectio
            return View(await db.Cat_Meeting.ToListAsync());
        }

        // GET: Meeting/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var cat_Meeting = await db.Cat_Meeting
                .FirstOrDefaultAsync(m => m.MeetingId == id);
            if (cat_Meeting == null)
            {
                return NotFound();
            }

            return View(cat_Meeting);
        }

        // GET: Meeting/Create
        public IActionResult Create()
        {
            string comid = HttpContext.Session.GetString("comid");
            ViewBag.Title = "Create";
            ViewBag.MeetingType = new SelectList(db.Cat_Variable.Where(c => c.VarType == "Technical" && c.ComId == comid), "VarName", "VarName");
            return View();
        }

        // POST: Meeting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cat_Meeting cat_Meeting)
        {
            if (ModelState.IsValid)
            {
                cat_Meeting.UserId = HttpContext.Session.GetString("userid");
                cat_Meeting.ComId = HttpContext.Session.GetString("comid");




                if (cat_Meeting.MeetingId > 0)
                {
                    cat_Meeting.DateUpdated = DateTime.Today;
                    cat_Meeting.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(cat_Meeting).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Meeting.MeetingId.ToString(), "Update", cat_Meeting.Meeting.ToString());

                }
                else
                {
                    cat_Meeting.DateAdded = DateTime.Today;
                    db.Add(cat_Meeting);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Meeting.MeetingId.ToString(), "Create", cat_Meeting.Meeting.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(cat_Meeting);
        }

        // GET: Meeting/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var cat_Meeting = await db.Cat_Meeting.FindAsync(id);
            ViewBag.MeetingType = new SelectList(db.Cat_Variable, "VarName", "VarName", cat_Meeting.MeetingType);
            if (cat_Meeting == null)
            {
                return NotFound();
            }
            return View("Create", cat_Meeting);
        }


        // GET: Meeting/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_Meeting = await db.Cat_Meeting

               .FirstOrDefaultAsync(m => m.MeetingId == id);
            if (Cat_Meeting == null)
            {
                return NotFound();
            }


            ViewBag.Title = "Delete";
            ViewBag.MeetingType = new SelectList(db.Cat_Variable, "VarName", "VarName", Cat_Meeting.MeetingType);
            return View("Create", Cat_Meeting);

        }

        // POST: Meeting/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var cat_Meeting = await db.Cat_Meeting.FindAsync(id);
                db.Cat_Meeting.Remove(cat_Meeting);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Meeting.MeetingId.ToString(), "Delete", cat_Meeting.Meeting);
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, MeetingId = cat_Meeting.MeetingId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool Cat_MeetingExists(int id)
        {
            return db.Cat_Meeting.Any(e => e.MeetingId == id);
        }
    }
}
