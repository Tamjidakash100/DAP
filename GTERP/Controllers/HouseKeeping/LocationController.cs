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
    public class Location : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public Location(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Cat_Location
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            return View(await db.Cat_Location.ToListAsync());
        }

        // GET: Cat_Location/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_Location = await db.Cat_Location
                .FirstOrDefaultAsync(m => m.LId == id);
            if (Cat_Location == null)
            {
                return NotFound();
            }

            return View(Cat_Location);
        }

        // GET: Cat_Location/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            //ViewBag.LId = new SelectList(db.Cat_Location, "LId", "LocationName");
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("LId,ComId,DeptCode,DeptName,Pcname,LuserId,DeptBangla,Slno,ParentId,Buid,Buname,DptSrtName,IsStrDpt")]*/ Cat_Location Cat_Location)
        {
            if (ModelState.IsValid)
            {
                Cat_Location.UserId = HttpContext.Session.GetString("userid");
                Cat_Location.ComId = HttpContext.Session.GetString("comid");
                if (Cat_Location.LId > 0)
                {
                    db.Entry(Cat_Location).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Location.LId.ToString(), "Update", Cat_Location.LocationName.ToString());

                }
                else
                {
                    db.Add(Cat_Location);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Location.LId.ToString(), "Create", Cat_Location.LocationName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(Cat_Location);
        }


        // GET: Cat_Location/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var Cat_Location = await db.Cat_Location.FindAsync(id);
            //ViewBag.LId = new SelectList(db.Cat_Location, "LId", "LocationName", Cat_Location.LId);
            if (Cat_Location == null)
            {
                return NotFound();
            }
            return View("Create", Cat_Location);
        }

        // POST: Cat_Location/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComId,LId,LocationName,PcName,AddByUserId,DateAdded,UpdateByUserId,DateUpdated,DtInput,userId")] Cat_Location Cat_Location)
        {
            if (id != Cat_Location.LId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(Cat_Location);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cat_LocationExists(Cat_Location.LId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Cat_Location);
        }

        private bool Cat_LocationExists(int id)
        {
            return db.Cat_Location.Any(e => e.LId == id);
        }

        // GET: Cat_Location/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_Location = await db.Cat_Location
                .FirstOrDefaultAsync(m => m.LId == id);

            if (Cat_Location == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            // ViewBag.DeptId = new SelectList(db.Cat_Location, "LId", "LocationName", Cat_Location.LId);
            return View("Create", Cat_Location);
        }

        // POST: Cat_Location/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var Cat_Location = await db.Cat_Location.FindAsync(id);
                db.Cat_Location.Remove(Cat_Location);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Location.LId.ToString(), "Delete", Cat_Location.LocationName);
                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, LId = Cat_Location.LId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }
    }
}
