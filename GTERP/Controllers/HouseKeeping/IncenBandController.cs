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
    public class IncenBandController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public IncenBandController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Cat_IncenBand
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");


            var data = await db.Cat_IncenBand.ToListAsync();
            return View(data);
        }

        // GET: Cat_IncenBand/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_IncenBand = await db.Cat_IncenBand
                .FirstOrDefaultAsync(m => m.InBId == id);
            if (Cat_IncenBand == null)
            {
                return NotFound();
            }

            return View(Cat_IncenBand);
        }

        // GET: Cat_IncenBand/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            //ViewBag.CountryId = new SelectList(db.Cat_Country, "CountryId", "CountryName");
            ViewBag.InBId = new SelectList(db.Cat_IncenBand, "InBId", "IncenBandName");
            return View();
        }

        // POST: Cat_IncenBand/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind(" DistId ,DistName,DistNameShort,aId ,wId , LUserId ,PCName")]*/ Cat_IncenBand Cat_IncenBand)
        {
            if (ModelState.IsValid)
            {
                Cat_IncenBand.UserId = HttpContext.Session.GetString("userid");
                Cat_IncenBand.ComId = HttpContext.Session.GetString("comid");
                if (Cat_IncenBand.InBId > 0)
                {
                    Cat_IncenBand.DateUpdated = DateTime.Now;
                    Cat_IncenBand.UpdateByUserId = HttpContext.Session.GetString("userid");
                    db.Entry(Cat_IncenBand).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_IncenBand.InBId.ToString(), "Update", Cat_IncenBand.IncenBandName.ToString());

                }
                else
                {
                    Cat_IncenBand.DateAdded = DateTime.Now;
                    db.Add(Cat_IncenBand);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_IncenBand.InBId.ToString(), "Create", Cat_IncenBand.IncenBandName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(Cat_IncenBand);
        }

        // GET: Cat_IncenBand/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            //Cat_Country  cat_Country  = db.Cat_Country.Where(m => m.BuyerId.ToString() == id.ToString()).FirstOrDefault(); //Find(id);// 
            var Cat_IncenBand = await db.Cat_IncenBand.FindAsync(id);
            ViewBag.InBId = new SelectList(db.Cat_IncenBand, "InBId", "IncenBandName", Cat_IncenBand.InBId);
            if (Cat_IncenBand == null)
            {
                return NotFound();
            }

            return View("Create", Cat_IncenBand);
        }

        // POST: Cat_IncenBand/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InBId,ComId,IncenBandName,Remarks,SLNO,IsInactive,UserId, Pcname")] Cat_IncenBand Cat_IncenBand)
        {
            if (id != Cat_IncenBand.InBId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(Cat_IncenBand);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InceBandExists(Cat_IncenBand.InBId))
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
            return View(Cat_IncenBand);
        }

        // GET: Cat_IncenBand/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_IncenBand = await db.Cat_IncenBand
                .FirstOrDefaultAsync(m => m.InBId == id);

            if (Cat_IncenBand == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            ViewBag.InBId = new SelectList(db.Cat_IncenBand, "InBId", "IncenBandName", Cat_IncenBand.InBId);
            return View("Create", Cat_IncenBand);
        }

        // POST: Cat_IncenBand/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {


            try
            {
                var Cat_IncenBand = await db.Cat_IncenBand.FindAsync(id);
                db.Cat_IncenBand.Remove(Cat_IncenBand);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_IncenBand.InBId.ToString(), "Delete", Cat_IncenBand.IncenBandName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, InBId = Cat_IncenBand.InBId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

        }

        private bool InceBandExists(int id)
        {
            return db.Cat_IncenBand.Any(e => e.InBId == id);
        }
    }
}
