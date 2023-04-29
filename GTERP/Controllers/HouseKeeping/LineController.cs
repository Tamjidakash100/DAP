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
    public class LineController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public LineController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: Cat_Line
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");


            return View(await db.Cat_Line.ToListAsync());
        }

        // GET: Cat_Line/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_Line = await db.Cat_Line
                .FirstOrDefaultAsync(m => m.LineId == id).ConfigureAwait(false);
            if (Cat_Line == null)
            {
                return NotFound();
            }

            return View(Cat_Line);
        }

        // GET: Cat_Line/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.LineId = new SelectList(db.Cat_Line, "LineId", "LineName");
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("LineId,ComId,DeptCode,DeptName,Pcname,LuserId,DeptBangla,Slno,ParentId,Buid,Buname,DptSrtName,IsStrDpt")]*/ Cat_Line Cat_Line)
        {
            if (ModelState.IsValid)
            {
                Cat_Line.UserId = HttpContext.Session.GetString("userid");
                Cat_Line.ComId = HttpContext.Session.GetString("comid");
                if (Cat_Line.LineId > 0)
                {
                    db.Entry(Cat_Line).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Line.LineId.ToString(), "Update", Cat_Line.LineName.ToString());

                }
                else
                {
                    db.Add(Cat_Line);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Line.LineId.ToString(), "Create", Cat_Line.LineName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(Cat_Line);
        }


        // GET: Cat_Line/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var Cat_Line = await db.Cat_Line.FindAsync(id);
            ViewBag.LineId = new SelectList(db.Cat_Line, "LineId", "LineName", Cat_Line.LineId);
            if (Cat_Line == null)
            {
                return NotFound();
            }
            return View("Create", Cat_Line);
        }

        // POST: Cat_Line/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComId,LineId,LineName,PcName,AddByUserId,DateAdded,UpdateByUserId,DateUpdated,DtInput,userId")] Cat_Line Cat_Line)
        {
            if (id != Cat_Line.LineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(Cat_Line);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cat_LineExists(Cat_Line.LineId))
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
            return View(Cat_Line);
        }

        private bool Cat_LineExists(int id)
        {
            return db.Cat_Line.Any(e => e.LineId == id);
        }

        // GET: Cat_Line/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_Line = await db.Cat_Line
                .FirstOrDefaultAsync(m => m.LineId == id);

            if (Cat_Line == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            ViewBag.DeptId = new SelectList(db.Cat_Line, "LineId", "LineName", Cat_Line.LineId);
            return View("Create", Cat_Line);
        }

        // POST: Cat_Line/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var Cat_Line = await db.Cat_Line.FindAsync(id);
                db.Cat_Line.Remove(Cat_Line);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Line.LineId.ToString(), "Delete", Cat_Line.LineName);


                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, LineId = Cat_Line.LineId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }
    }
}
