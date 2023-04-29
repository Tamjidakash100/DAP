using GTERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace GTERP.Controllers
{
    [OverridableAuthorize]
    public class ModuleGroupsController : Controller
    {
        private GTRDBContext db;
        public ModuleGroupsController(GTRDBContext context)
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
            var moduleGroups = db.ModuleGroups.Include(m => m.vModule);
            return View(moduleGroups.ToList());
        }

        // GET: ModuleGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ModuleGroup moduleGroup = db.ModuleGroups.Find(id);
            if (moduleGroup == null)
            {
                return NotFound();
            }
            return View(moduleGroup);
        }

        // GET: ModuleGroups/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.ModuleId = new SelectList(db.Modules, "ModuleId", "ModuleName");
            return View();
        }

        // POST: ModuleGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(ModuleGroup moduleGroup, /*HttpPostedFileBase file,*/ string imageDatatest)
        {

            var errors = ModelState.Where(x => x.Value.Errors.Any())
           .Select(x => new { x.Key, x.Value.Errors });

            //if (Request.Files.Count > 0)
            //{
            //    var uploadedfile = Request.Files[0];
            //    //save file logic

            //}
            ////moduleGroup.comid = int.Parse(Session["comid"].ToString());


            if (ModelState.IsValid)
            {
                if (moduleGroup.ModuleGroupId > 0)
                {
                    db.Entry(moduleGroup).State = EntityState.Modified;
                    db.SaveChanges();

                    //if (file != null && file.ContentLength > 0)
                    //{
                    //    fileName = Path.GetFileName(file.FileName);
                    //    Extension = Path.GetExtension(fileName);

                    //    moduleGroup.ImagePath = "uploads/Products/";// + product.ProductId.ToString() + Extension.ToString();
                    //    moduleGroup.ImageExtension = Extension;

                    //    _FileName = moduleGroup.ModuleGroupId.ToString() + Extension;
                    //    _path = Path.Combine(Server.MapPath("~/uploads/ModuleGroups"), _FileName);
                    //    byte[] fileData = null;
                    //    using (var binaryReader = new BinaryReader(file.InputStream))
                    //    {
                    //        fileData = binaryReader.ReadBytes(file.ContentLength);
                    //    }

                    //    Image cropimage = HandleImageUpload(fileData, _path);
                    //    MemoryStream ms = new MemoryStream();
                    //    cropimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //    byte[] imageData = ms.ToArray();


                    //    moduleGroup.ModuleGroupImage = imageData;
                    //    string imageUrls = "/uploads/ModuleGroups/" + _FileName;



                    //    //moduleGroup.comid = int.Parse(Session["comid"].ToString());
                    //    db.Entry(moduleGroup).State = EntityState.Modified;
                    //    db.SaveChanges();
                    //}
                }
                else
                {
                    //moduleGroup.comid = int.Parse(Session["comid"].ToString());
                    db.ModuleGroups.Add(moduleGroup);
                    db.SaveChanges();

                    db.Entry(moduleGroup).GetDatabaseValues();
                    int id = moduleGroup.ModuleGroupId; // Yes it's here

                    //if (file != null && file.ContentLength > 0)
                    //{
                    //    fileName = Path.GetFileName(file.FileName);
                    //    Extension = Path.GetExtension(fileName);

                    //    moduleGroup.ImagePath = "uploads/ModuleGroups/";// + product.ProductId.ToString() + Extension.ToString();
                    //    moduleGroup.ImageExtension = Extension;

                    //    _FileName = id.ToString() + Extension;
                    //    _path = Path.Combine(Server.MapPath("~/uploads/ModuleGroups"), _FileName);
                    //    byte[] fileData = null;
                    //    using (var binaryReader = new BinaryReader(file.InputStream))
                    //    {
                    //        fileData = binaryReader.ReadBytes(file.ContentLength);
                    //    }


                    //    Image cropimage = HandleImageUpload(fileData, _path);
                    //    MemoryStream ms = new MemoryStream();
                    //    cropimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //    byte[] imageData = ms.ToArray();


                    //    moduleGroup.ModuleGroupImage = imageData;
                    //    string imageUrls = "/uploads/ModuleGroups/" + _FileName;
                    //}
                    ////_FileName = Path.GetFileName(DateTime.Now.ToBinary() + "-" + file.FileName);

                    //db.Entry(moduleGroup).State = EntityState.Modified;
                    //db.SaveChanges();

                }
                return RedirectToAction("Index");

            }
            ViewBag.ModuleId = new SelectList(db.Modules, "ModuleId", "ModuleName", moduleGroup.ModuleId);

            return View(moduleGroup);

            //if (ModelState.IsValid)
            //{
            //    db.ModuleGroups.Add(moduleGroup);//.ModuleGroups.Add(moduleGroup);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.ModuleId = new SelectList(db.Modules, "ModuleId", "ModuleName", moduleGroup.ModuleId);

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
            ModuleGroup moduleGroup = db.ModuleGroups.Find(id);
            if (moduleGroup == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Edit";
            ViewBag.ModuleId = new SelectList(db.Modules, "ModuleId", "ModuleName", moduleGroup.ModuleId);
            return View("Create", moduleGroup);
        }

        // POST: ModuleGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(/*Include =*/ "ModuleGroupId,ModuleGroupName,ModuleGroupCaption,ModuleId,ModuleGroupImage,ImagePath,ImageExtension,SLNo")] ModuleGroup moduleGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moduleGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModuleId = new SelectList(db.Modules, "ModuleId", "ModuleName", moduleGroup.ModuleId);
            return View(moduleGroup);
        }

        // GET: ModuleGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ModuleGroup moduleGroup = db.ModuleGroups.Find(id);
            if (moduleGroup == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Delete";
            ViewBag.ModuleId = new SelectList(db.Modules, "ModuleId", "ModuleName", moduleGroup.ModuleId);
            return View("Create", moduleGroup);
        }

        // POST: ModuleGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int? id)
        {
            try
            {
                ModuleGroup moduleGroup = db.ModuleGroups.Find(id);
                db.ModuleGroups.Remove(moduleGroup);
                db.SaveChanges();

                //string fullPath = Request.MapPath("~/" + moduleGroup.ImagePath + moduleGroup.ModuleGroupId + moduleGroup.ImageExtension);
                //if (System.IO.File.Exists(fullPath))
                //{
                //    System.IO.File.Delete(fullPath);
                //}
                return Json(new { Success = 1, ModuleGroupId = moduleGroup.ModuleGroupId, ex = "" });

            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.Message.ToString() });

            }

            //return Json(new { Success = 0, ex = new Exception("Unable to Delete").Message.ToString() });

            //return RedirectToAction("Index");
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
