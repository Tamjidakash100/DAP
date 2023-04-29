using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Buffers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers.Buffer
{
    public class BufferReprestativeMemberController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;
        public BufferReprestativeMemberController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }
        public IActionResult Index()
        {

            var comid = HttpContext.Session.GetString("comid");
            return View(db.BufferRepresentativeMember.ToList());
        }


        public IActionResult Create()
        {
            ViewBag.Title = "Create";
           ViewBag.RepList = db.BuferRepresentative.Select(x => new SelectListItem { Text = x.RepresentativeName, Value = x.BufferRepresentativeId.ToString() }).ToList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BufferRepresentativeMember data)
        {



            if (ModelState.IsValid)
            {
                


                if (data.Id > 0)
                {

                    db.Entry(data).State = EntityState.Modified;
                    await db.SaveChangesAsync();


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";

                }
                else
                {
                    db.Add(data);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";

                }
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            ViewBag.RepList = db.BuferRepresentative.Select(x => new SelectListItem { Text = x.RepresentativeName, Value = x.BufferRepresentativeId.ToString() }).ToList();

            var data = await db.BufferRepresentativeMember.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return View("Create", data);
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await db.BufferRepresentativeMember.FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.RepList = db.BuferRepresentative.Select(x => new SelectListItem { Text = x.RepresentativeName, Value = x.BufferRepresentativeId.ToString() }).ToList();
            if (data == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";

            return View("Create", data);

        }


        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {


            try
            {
                var data = await db.BufferRepresentativeMember.FindAsync(id);
                db.BufferRepresentativeMember.Remove(data);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                // tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Designation.DesigId.ToString(), "Delete", Cat_Designation.DesigName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, BufferRepresentativeId = data.BufferRepresentativeId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.InnerException.Message.ToString();
                return Json(new { Success = 0, ex = TempData["Message"].ToString() });
            }

        }

        private bool BufferRepresentativeExists(int id)
        {
            return db.BufferRepresentativeMember.Any(e => e.Id == id);
        }
    }
}
