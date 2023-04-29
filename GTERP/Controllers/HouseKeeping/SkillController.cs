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
    public class SkillController : Controller
    {
        private TransactionLogRepository tranlog;
        private readonly GTRDBContext db;

        public SkillController(GTRDBContext context, TransactionLogRepository tran)
        {
            tranlog = tran;
            db = context;
        }

        // GET: skill
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");


            return View(await db.Cat_Skill.ToListAsync());
        }


        // GET: skill/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            //ViewBag.SkillId = new SelectList(db.Cat_Skill, "SkillId", "skillName");
            return View();
        }

        // POST: skill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("SkillId,skillName,skillShortName")]*/ Cat_Skill skill)
        {

            if (ModelState.IsValid)
            {
                skill.UserId = HttpContext.Session.GetString("userid");
                skill.ComId = HttpContext.Session.GetString("comid");
                if (skill.SkillId > 0)
                {
                    db.Entry(skill).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), skill.SkillId.ToString(), "Update", skill.SkillName.ToString());

                }
                else
                {
                    db.Add(skill);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), skill.SkillId.ToString(), "Create", skill.SkillName.ToString());

                }
                return RedirectToAction(nameof(Index));
            }
            return View(skill);

        }

        // GET: skill/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            var skill = await db.Cat_Skill.FindAsync(id);
            //ViewBag.SkillId = new SelectList(db.Cat_Skill, "SkillId", "skillName", skill.ParentId);
            if (skill == null)
            {
                return NotFound();
            }
            return View("Create", skill);

        }

        // GET: skill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await db.Cat_Skill
                .FirstOrDefaultAsync(m => m.SkillId == id);

            if (skill == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Delete";
            //ViewBag.SkillId = new SelectList(db.Cat_Skill, "SkillId", "skillName", skill.ParentId);
            return View("Create", skill);

        }

        // POST: skill/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var skill = await db.Cat_Skill.FindAsync(id);
                db.Cat_Skill.Remove(skill);
                db.SaveChanges();

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), skill.SkillId.ToString(), "Delete", skill.SkillName);

                //TempData["Message"] = "Data Delete Successfully";
                return Json(new { Success = 1, SkillId = skill.SkillId, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        private bool skillExists(int id)
        {
            return db.Cat_Skill.Any(e => e.SkillId == id);
        }
    }
}
