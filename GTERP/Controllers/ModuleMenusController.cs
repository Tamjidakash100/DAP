
using GTERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace GTERP.Controllers
{
    [OverridableAuthorize]
    public class ModuleMenusController : Controller
    {
        private GTRDBContext db;
        public ModuleMenusController(GTRDBContext context)
        {
            db = context;
        }

        public Image _currentBitmap;
        string _FileName = "";
        string _path = "";
        string fileName = null;
        string Extension = null;

        // GET: ModuleGroups
        public ActionResult Index()
        {
            var moduleMenus = db.ModuleMenus.Include(m => m.vModuleGroup).Include(m => m.vModule);
            return View(moduleMenus.ToList());
        }

        // GET: ModuleGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ModuleGroup moduleMenu = db.ModuleGroups.Find(id);
            if (moduleMenu == null)
            {
                return NotFound();
            }
            return View(moduleMenu);
        }

        // GET: ModuleGroups/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.ModuleId = new SelectList(db.Modules, "ModuleId", "ModuleCaption");
            ViewBag.ModuleGroupId = new SelectList(db.ModuleGroups, "ModuleGroupId", "ModuleGroupCaption");
            ViewBag.ImageCriteriaId = new SelectList(db.ImageCriterias, "ImageCriteriaId", "ImageCriteriaCaption");

            return View();
        }

        // POST: ModuleGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(ModuleMenu moduleMenu, /*HttpPostedFileBase file,*/ string imageDatatest)
        {
            try
            {


                var errors = ModelState.Where(x => x.Value.Errors.Any())
               .Select(x => new { x.Key, x.Value.Errors });

                //if (Request.Files.Count > 0)

                //{
                //    var uploadedfile = Request.Files[0];
                //    //save file logic

                //}
                ////moduleMenu.comid = int.Parse(Session["comid"].ToString());


                if (ModelState.IsValid)
                {
                    if (moduleMenu.ModuleMenuId > 0)
                    {
                        db.Entry(moduleMenu).State = EntityState.Modified;
                        db.SaveChanges();

                        //if (file != null && file.ContentLength > 0)
                        //{
                        //    fileName = Path.GetFileName(file.FileName);
                        //    Extension = Path.GetExtension(fileName);

                        //    moduleMenu.ModuleImagePath = "uploads/ModuleMenus/";// + product.ProductId.ToString() + Extension.ToString();
                        //    moduleMenu.ModuleImageExtension = Extension;


                        //    _FileName = moduleMenu.ModuleMenuId.ToString() + Extension; 
                        //     _path = Path.Combine(Server.MapPath("~/uploads/ModuleMenus"), _FileName);
                        //    byte[] fileData = null;
                        //    using (var binaryReader = new BinaryReader(file.InputStream))
                        //    {
                        //        fileData = binaryReader.ReadBytes(file.ContentLength);
                        //    }

                        //    Image cropimage = HandleImageUpload(fileData, _path);
                        //    MemoryStream ms = new MemoryStream();
                        //    cropimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //    byte[] imageData = ms.ToArray();


                        //    moduleMenu.ModuleMenuImage = imageData;
                        //    string imageUrls = "/uploads/ModuleMenus/" + _FileName;



                        //    //moduleMenu.comid = int.Parse(Session["comid"].ToString());
                        //    db.Entry(moduleMenu).State = EntityState.Modified;
                        //    db.SaveChanges();
                        //}
                    }
                    else
                    {
                        if (moduleMenu.ParentId == -1)
                        {

                            moduleMenu.ParentId = 0;


                        }


                        //moduleMenu.comid = int.Parse(Session["comid"].ToString());
                        db.ModuleMenus.Add(moduleMenu);
                        var error = ModelState.Where(x => x.Value.Errors.Any())
                        .Select(x => new { x.Key, x.Value.Errors });
                        db.SaveChanges();

                        db.Entry(moduleMenu).GetDatabaseValues();
                        int id = moduleMenu.ModuleMenuId; // Yes it's here

                        //if (file != null && file.ContentLength > 0)
                        //{
                        //    fileName = Path.GetFileName(file.FileName);
                        //    Extension = Path.GetExtension(fileName);

                        //    moduleMenu.ModuleImagePath = "uploads/ModuleMenus/";// + product.ProductId.ToString() + Extension.ToString();
                        //    moduleMenu.ModuleImageExtension = Extension;

                        //    _FileName = id.ToString() + Extension;
                        //    _path = Path.Combine(Server.MapPath("~/uploads/ModuleMenus"), _FileName);
                        //    byte[] fileData = null;
                        //    using (var binaryReader = new BinaryReader(file.InputStream))
                        //    {
                        //        fileData = binaryReader.ReadBytes(file.ContentLength);
                        //    }


                        //    Image cropimage = HandleImageUpload(fileData, _path);
                        //    MemoryStream ms = new MemoryStream();
                        //    cropimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //    byte[] imageData = ms.ToArray();


                        //    moduleMenu.ModuleMenuImage = imageData;
                        //    string imageUrls = "/uploads/ModuleMenus/" + _FileName;
                        //}
                        ////_FileName = Path.GetFileName(DateTime.Now.ToBinary() + "-" + file.FileName);

                        //db.Entry(moduleMenu).State = EntityState.Modified;
                        //db.SaveChanges();

                    }
                    return RedirectToAction("Index");

                }
                ViewBag.ModuleMenuId = new SelectList(db.ModuleGroups, "ModuleMenuId", "ModuleGroupCaption", moduleMenu.ModuleGroupId);

                return View(moduleMenu);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private MemoryStream BytearrayToStream(byte[] arr)
        {
            return new MemoryStream(arr, 0, arr.Length);
        }

        private Image HandleImageUpload(byte[] binaryImage, string path)
        {
            Image img = RezizeImage(Image.FromStream(BytearrayToStream(binaryImage)), 300, 300);
            img.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            return img;
        }

        private Image RezizeImage(Image img, int maxWidth, int maxHeight)
        {
            if (img.Height < maxHeight && img.Width < maxWidth) return img;
            using (img)
            {
                Double xRatio = (double)img.Width / maxWidth;
                Double yRatio = (double)img.Height / maxHeight;
                Double ratio = Math.Max(xRatio, yRatio);
                int nnx = (int)Math.Floor(img.Width / ratio);
                int nny = (int)Math.Floor(img.Height / ratio);
                Bitmap cpy = new Bitmap(nnx, nny, PixelFormat.Format32bppArgb);
                using (Graphics gr = Graphics.FromImage(cpy))
                {
                    //gr.Clear(Color.Transparent);

                    // This is said to give best quality when resizing images
                    gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                    gr.DrawImage(img,
                        new Rectangle(0, 0, nnx, nny),
                        new Rectangle(0, 0, img.Width, img.Height),
                        GraphicsUnit.Pixel);
                }
                return cpy;
            }

        }

        // GET: ModuleGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ModuleMenu moduleMenu = db.ModuleMenus.Find(id);
            if (moduleMenu == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            ViewBag.ModuleId = new SelectList(db.Modules, "ModuleId", "ModuleCaption", moduleMenu.ModuleId);
            ViewBag.ImageCriteriaId = new SelectList(db.ImageCriterias, "ImageCriteriaId", "ImageCriteriaCaption", moduleMenu.ImageCriteriaId);
            ViewBag.ModuleGroupId = new SelectList(db.ModuleGroups.Where(x => x.ModuleGroupId == moduleMenu.ModuleGroupId), "ModuleGroupId", "ModuleGroupCaption", moduleMenu.ModuleGroupId);
            //ViewBag.ModuleGroupId = new SelectList(db.ModuleGroups.Where(m=>m.ModuleId==moduleMenu.ModuleId), "ModuleGroupId", "ModuleGroupCaption",moduleMenu.ModuleGroupId);
            ViewBag.ParentId = new SelectList(db.ModuleMenus.Where(x => x.ModuleGroupId == moduleMenu.ModuleGroupId && x.isParent == 1), "ModuleMenuId", "ModuleMenuCaption", moduleMenu.ParentId);
            //ViewBag.ParentId = new SelectList(db.ModuleMenus.Where(m=>m.ModuleGroupId==moduleMenu.ModuleGroupId), "ModuleMenuId", "ModuleGroupCaption", moduleMenu.ModuleMenuId);
            return View("Create", moduleMenu);
        }

        // POST: ModuleGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(ModuleGroup moduleMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moduleMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModuleMenuId = new SelectList(db.ModuleGroups, "ModuleMenuId", "ModuleGroupCaption", moduleMenu.ModuleGroupId);
            return View(moduleMenu);
        }

        // GET: ModuleGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ModuleMenu moduleMenu = db.ModuleMenus.Find(id);
            if (moduleMenu == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Delete";
            ViewBag.ModuleId = new SelectList(db.Modules, "ModuleId", "ModuleCaption", moduleMenu.ModuleId);
            ViewBag.ImageCriteriaId = new SelectList(db.ImageCriterias, "ImageCriteriaId", "ImageCriteriaCaption", moduleMenu.ImageCriteriaId);
            ViewBag.ModuleGroupId = new SelectList(db.ModuleGroups.Where(x => x.ModuleGroupId == moduleMenu.ModuleGroupId), "ModuleGroupId", "ModuleGroupCaption", moduleMenu.ModuleGroupId);
            //ViewBag.ModuleGroupId = new SelectList(db.ModuleGroups.Where(m=>m.ModuleId==moduleMenu.ModuleId), "ModuleGroupId", "ModuleGroupCaption",moduleMenu.ModuleGroupId);
            ViewBag.ParentId = new SelectList(db.ModuleMenus.Where(x => x.ParentId == moduleMenu.ParentId && x.isParent == 1), "ModuleMenuId", "ModuleMenuCaption", moduleMenu.ParentId);
            //ViewBag.ParentId = new SelectList(db.ModuleMenus.Where(m=>m.ModuleGroupId==moduleMenu.ModuleGroupId), "ModuleMenuId", "ModuleGroupCaption", moduleMenu.ModuleMenuId);
            return View("Create", moduleMenu);
        }

        // POST: ModuleGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int? id)
        {
            try
            {
                ModuleMenu moduleMenu = db.ModuleMenus.Find(id);
                db.ModuleMenus.Remove(moduleMenu);
                db.SaveChanges();

                //string fullPath = Request.MapPath("~/" + moduleMenu.ModuleImagePath + moduleMenu.ModuleMenuId + moduleMenu.ModuleImageExtension);
                //if (System.IO.File.Exists(fullPath))
                //{
                //    System.IO.File.Delete(fullPath);
                //}
                return Json(new { Success = 1, ModuleMenuId = moduleMenu.ModuleMenuId, ex = "" });

            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.Message.ToString() });

            }

            //return Json(new { Success = 0, ex = new Exception("Unable to Delete").Message.ToString() });

            //return RedirectToAction("Index");
        }


        public JsonResult GetModuleGroup(int id)
        {
            List<ModuleGroup> ModuleGroupList = db.ModuleGroups.Where(m => m.ModuleId == id).ToList();

            List<SelectListItem> ListOfModuleGroup = new List<SelectListItem>();

            //licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
            if (ModuleGroupList != null)
            {
                foreach (ModuleGroup x in ModuleGroupList)
                {
                    ListOfModuleGroup.Add(new SelectListItem { Text = x.ModuleGroupName, Value = x.ModuleGroupId.ToString() });
                }
            }
            return Json(new SelectList(ListOfModuleGroup, "Value", "Text"));
        }


        //[HttpPost, ActionName("GetModuleGroup")]
        //public JsonResult GetModuleGroup(int id)
        //{
        //    //db.Configuration.LazyLoadingEnabled = false;
        //    //db.Configuration.ProxyCreationEnabled = false;
        //    var moduleGroups = db.ModuleGroups.Where(m => m.ModuleId == id).ToList();
        //    return Json(moduleGroups);
        //}

        // [HttpPost, ActionName("GetModuleMenu")]
        //public JsonResult GetModuleMenu(int id)
        //{
        //    //db.Configuration.LazyLoadingEnabled = false;
        //    //db.Configuration.ProxyCreationEnabled = false;
        //    var moduleMenus = db.ModuleMenus.Where(m => m.ModuleGroupId == id && m.isParent==1).ToList();
        //    return Json(moduleMenus);
        //}


        public JsonResult GetModuleMenu(int id)
        {
            List<ModuleMenu> ParentMenuList = db.ModuleMenus.Where(m => m.ModuleGroupId == id && m.isParent == 1).ToList();

            List<SelectListItem> listparentmenu = new List<SelectListItem>();

            //licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
            if (ParentMenuList != null)
            {
                foreach (ModuleMenu x in ParentMenuList)
                {
                    listparentmenu.Add(new SelectListItem { Text = x.ModuleMenuCaption, Value = x.ModuleMenuId.ToString() });
                }
            }
            return Json(new SelectList(listparentmenu, "Value", "Text"));
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}