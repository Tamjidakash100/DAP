using GTERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace GTERP.Controllers
{
    [OverridableAuthorize]
    public class ModulesController : Controller
    {
        private GTRDBContext db;
        public ModulesController(GTRDBContext context)
        {
            db = context;
        }

        private Image _currentBitmap;
        string _FileName = "";
        string _path = "";
        string fileName = null;
        string Extension = null;

        // GET: Modules
        public ActionResult Index()
        {
            return View(db.Modules.ToList());
        }

        // GET: Modules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return NotFound();
            }
            return View(module);
        }

        // GET: Modules/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        ////[Authorize]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Module module,/* HttpPostedFileBase file,*/ string imageDatatest)
        {
            module.isInactive = 0;

            //  var errors = ModelState.Where(x => x.Value.Errors.Any())
            //.Select(x => new { x.Key, x.Value.Errors });




            //if (Request.Files.Count > 0)
            //{
            //    HttpPostedFileBase uploadedfile = Request.Files[0];
            //    //save file logic

            //}

            if (ModelState.IsValid)
            {
                if (module.ModuleId > 0)
                {
                    db.Entry(module).State = EntityState.Modified;
                    db.SaveChanges();

                    // image 

                    //if (file != null && file.ContentLength > 0)
                    //{
                    //    fileName = Path.GetFileName(file.FileName);
                    //    Extension = Path.GetExtension(fileName);

                    //    module.ModuleImagePath = "uploads/Modules/";// + module.ProductId.ToString() + Extension.ToString();
                    //    module.ModuleImageExtension = Extension;

                    //    _FileName = module.ModuleId.ToString() + Extension;
                    //    _path = Path.Combine(Server.MapPath("~/uploads/Modules"), _FileName);
                    //    byte[] fileData = null;
                    //    using (var binaryReader = new BinaryReader(file.InputStream))
                    //    {
                    //        fileData = binaryReader.ReadBytes(file.ContentLength);
                    //    }

                    //    Image cropimage = HandleImageUpload(fileData, _path);
                    //    MemoryStream ms = new MemoryStream();
                    //    cropimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //    byte[] imageData = ms.ToArray();


                    //    module.ModuleImage = imageData;
                    //    string imageUrls = "/uploads/Modules/" + _FileName;




                    //    db.Entry(module).State = EntityState.Modified;
                    //    db.SaveChanges();
                    //}


                }
                else
                {
                    //if (file != null && file.ContentLength > 0)
                    //{
                    //    fileName = Path.GetFileName(file.FileName);
                    //    Extension = Path.GetExtension(fileName);

                    //    module.ModuleImagePath = "uploads/Modules/";// + product.ProductId.ToString() + Extension.ToString();
                    //    module.ModuleImageExtension = Extension;
                    //}


                    db.Modules.Add(module);
                    db.SaveChanges();

                    db.Entry(module).GetDatabaseValues();
                    int id = module.ModuleId; // Yes it's here

                    //if (file != null && file.ContentLength > 0)
                    //{
                    //    //_FileName = Path.GetFileName(DateTime.Now.ToBinary() + "-" + file.FileName);
                    //    _FileName = id.ToString() + Extension;
                    //    _path = Path.Combine(Server.MapPath("~/uploads/Modules"), _FileName);
                    //    byte[] fileData = null;
                    //    using (var binaryReader = new BinaryReader(file.InputStream))
                    //    {
                    //        fileData = binaryReader.ReadBytes(file.ContentLength);
                    //    }

                    //    Image cropimage = HandleImageUpload(fileData, _path);
                    //    MemoryStream ms = new MemoryStream();
                    //    cropimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //    byte[] imageData = ms.ToArray();

                    //    module.ModuleImage = imageData;
                    //    string imageUrls = "/uploads/Modules/" + _FileName;


                    //    db.Entry(module).State = EntityState.Modified;
                    //    db.SaveChanges();
                    //}
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");

            //return View(module);
        }
        private Image HandleImageUpload(byte[] binaryImage, string path)
        {
            Image img = RezizeImage(Image.FromStream(BytearrayToStream(binaryImage)), 300, 300);
            img.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            return img;
        }
        private static Image RezizeImage(Image img, int maxWidth, int maxHeight)
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
        private MemoryStream BytearrayToStream(byte[] arr)
        {
            return new MemoryStream(arr, 0, arr.Length);
        }

        // GET: Modules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Edit";

            return View("Create", module);

        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(/*Include =*/ "ModuleId,ModuleCode,ModuleName,ModuleCaption,ModuleDescription,ModuleLink,ModuleImage,ModuleImagePath,ModuleImageExtension,isInactive,SLNo")] Module module)
        {
            if (ModelState.IsValid)
            {
                db.Entry(module).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(module);
        }

        // GET: Modules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Delete";

            return View("Create", module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Module module = db.Modules.Find(id);
                //Module module = db.Modules.Where(x => x.ModuleId == id).FirstOrDefault();

                db.Modules.Remove(module);
                db.SaveChanges();
                //return RedirectToAction("Index");


                return Json(new { Success = 1, ModuleId = module.ModuleId, ex = "Success" });

            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new
                {
                    Success = 0,
                    ex = ex.InnerException.InnerException.Message.ToString()
                });
            }
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
