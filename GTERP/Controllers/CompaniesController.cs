using GTERP.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class CompaniesController : Controller
    {
        public GTRDBContext db;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public CompaniesController(GTRDBContext context, IHostingEnvironment hostingEnvironment)
        {
            db = context;
            _hostingEnvironment = hostingEnvironment;

        }

        public Image _currentBitmap;
        string _FileName = "";
        string _path = "";
        string fileName = null;
        string Extension = null;

        // GET: Companies
        public ActionResult Index()
        {
            return View(db.Companys.Include(x => x.vCountryCompany).Include(x => x.vBusinessTypeCompany).ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Company company = db.Companys.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            ViewBag.BusinessTypeId = new SelectList(db.BusinessType, "BusinessTypeId", "Name");
            ViewBag.BaseComId = new SelectList(db.Companys.Where(p => p.IsGroup == true), "ComId", "CompanyName");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");

            ViewBag.Title = "Details";
            return View("Create", company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            ViewBag.BusinessTypeId = new SelectList(db.BusinessType, "BusinessTypeId", "Name");
            ViewBag.VoucherNoCreatedTypeId = new SelectList(db.Acc_VoucherNoCreatedTypes, "VoucherNoCreatedTypeId", "VoucherNoCreatedTypeName");

            ViewBag.BaseComId = new SelectList(db.Companys.Where(p => p.IsGroup == true), "ComId", "CompanyName");

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");

            ViewBag.Title = "Create";
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create([Bind(/*Include =*/ "ComId,AppKey,CompanyCode,CompanySecretCode,CompanyName,CompanyShortName,PrimaryAddress,SecoundaryAddress,comPhone,comPhone2,comFax,comEmail,comWeb,BusinessTypeId,VoucherNoCreatedTypeId,BaseComId,CountryId,DecimalField,ContPerson,ContDesig,IsShowCurrencySymbol,IsInActive,isBarcode,isProduct,isCorporate,isPOSprint,IsService,isOldDue,isShortcutSale,isRestaurantSale,isTouch,isShoeSale,isIMEISale,isMultipleWh,  isMultiCurrency      ,isMultiDebitCredit,isVoucherDistributionEntry, isChequeDetails         ,ComImageHeader,ComLogo,IsGroup,HeaderImagePath,HeaderFileExtension,LogoImagePath,LogoFileExtension")] Company company, IFormFile fileImageHeader, IFormFile fileLogo)
        {

            var errors = ModelState.Where(x => x.Value.Errors.Any())
                  .Select(x => new { x.Key, x.Value.Errors });

            if (ModelState.IsValid)
            {



                if (company.ComId > 0)
                {
                    if (fileImageHeader != null && fileImageHeader.Length > 0)
                    {
                        fileName = Path.GetFileName(fileImageHeader.FileName);
                        Extension = Path.GetExtension(fileName);
                        var uploadlocation = "Content/img/Companies/comimageheader/";
                        company.HeaderImagePath = uploadlocation;
                        company.HeaderFileExtension = Extension;

                        _FileName = company.ComId + Extension;
                        _path = uploadlocation + _FileName;// Path.Combine(Server.MapPath("~/Content/img/Companies/comimageheader/"), _FileName);
                        byte[] fileData = null;
                        using (BinaryReader binaryreader = new BinaryReader(fileImageHeader.OpenReadStream()))
                        {
                            fileData = binaryreader.ReadBytes((int)fileImageHeader.Length);
                        }

                        Image cropimage = HandleImageUpload(fileData, "wwwroot/" + _path);
                        MemoryStream ms = new MemoryStream();
                        cropimage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] imageData = ms.ToArray();


                        company.ComImageHeader = imageData;// ImageToByteArray(cropimage);
                        //string imageUrls = "/Content/img/companies/comimageheader/" + _FileName;

                    }

                    if (fileLogo != null && fileLogo.Length > 0)
                    {
                        fileName = Path.GetFileName(fileLogo.FileName);
                        Extension = Path.GetExtension(fileName);
                        var uploadlocation = "Content/img/Companies/comlogo/";
                        company.LogoImagePath = uploadlocation;
                        company.LogoFileExtension = Extension;

                        //string webRootPath = _hostingEnvironment.WebRootPath;
                        //string contentRootPath = _hostingEnvironment.ContentRootPath;

                        _FileName = company.ComId + Extension;

                        string _path = uploadlocation + _FileName;// Path.GetFullPath(company.LogoImagePath);

                        //var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

                        //_path = "";//Path.Combine(Server.MapPath("~/Content/img/Companies/comlogo/"), _FileName);
                        byte[] fileData = null;
                        //using (BinaryReader binaryReader = new BinaryReader(fileLogo.OpenReadStream()))
                        //{
                        //    fileData = binaryReader.ReadBytes(fileLogo.Length);
                        //}

                        using (BinaryReader binaryreader = new BinaryReader(fileLogo.OpenReadStream()))
                        {
                            fileData = binaryreader.ReadBytes((int)fileLogo.Length);
                        }

                        Image cropimage = HandleImageUpload(fileData, "wwwroot/" + _path);
                        MemoryStream ms = new MemoryStream();
                        cropimage.Save(ms, ImageFormat.Png);
                        byte[] imageData = ms.ToArray();


                        company.ComLogo = imageData;
                        //string imageUrls = "/Content/img/companies/comlogo/" + _FileName;


                        //if (!Directory.Exists(uploadlocation))
                        //{
                        //    Directory.CreateDirectory(uploadlocation);
                        //}

                        //string filePath = uploadlocation + Path.GetFileName(fileLogo.FileName);
                        //string extension = Path.GetExtension(fileLogo.FileName);



                    }

                    db.Entry(company).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.Companys.Add(company);
                    db.SaveChanges();

                    db.Entry(company).GetDatabaseValues();
                    string id = company.ComId.ToString(); // Yes it's here

                    if (fileImageHeader != null && fileImageHeader.Length > 0)
                    {
                        var uploadlocation = "Content/img/Companies/comimageheader/";
                        fileName = Path.GetFileName(fileImageHeader.FileName);
                        Extension = Path.GetExtension(fileName);

                        company.HeaderImagePath = uploadlocation;
                        company.HeaderFileExtension = Extension;

                        _FileName = id.ToString() + Extension;
                        _path = uploadlocation;// Path.Combine(Server.MapPath("~/Content/img/Companies/comimageheader/"), _FileName);
                        byte[] fileData = null;

                        using (BinaryReader binaryreader = new BinaryReader(fileImageHeader.OpenReadStream()))
                        {
                            fileData = binaryreader.ReadBytes((int)fileImageHeader.Length);
                        }
                        //using (var binaryReader = new BinaryReader(fileImageHeader.InputStream))
                        //{
                        //    fileData = binaryReader.ReadBytes(fileImageHeader.Length);
                        //}

                        Image cropimage = HandleImageUpload(fileData, _path);
                        MemoryStream ms = new MemoryStream();
                        cropimage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] imageData = ms.ToArray();


                        company.ComImageHeader = imageData;
                        string imageUrls = "/Content/img/companies/comimageheader/" + _FileName;

                    }
                    if (fileLogo != null && fileLogo.Length > 0)
                    {
                        var uploadlocation = "Content/img/Companies/comlogo/";
                        fileName = Path.GetFileName(fileLogo.FileName);
                        Extension = Path.GetExtension(fileName);

                        company.LogoImagePath = uploadlocation;
                        company.LogoFileExtension = Extension;

                        _FileName = id.ToString() + Extension;
                        _path = uploadlocation;// Path.Combine(Server.MapPath("~/Content/img/Companies/comlogo/"), _FileName);
                        byte[] fileData = null;
                        //using (var binaryReader = new BinaryReader(fileLogo.InputStream))
                        //{
                        //    fileData = binaryReader.ReadBytes(fileLogo.Length);
                        //}
                        using (BinaryReader binaryreader = new BinaryReader(fileLogo.OpenReadStream()))
                        {
                            fileData = binaryreader.ReadBytes((int)fileLogo.Length);
                        }

                        Image cropimage = HandleImageUpload(fileData, _path);


                        MemoryStream ms = new MemoryStream();
                        cropimage.Save(ms, cropimage.RawFormat);
                        byte[] imageData = ms.ToArray();


                        company.ComLogo = imageData;
                        string imageUrls = "/Content/img/companies/comlogo/" + _FileName;

                    }

                    db.Entry(company).State = EntityState.Modified;
                    db.SaveChanges();

                }



                return RedirectToAction("Index");
            }


            ViewBag.BusinessTypeId = new SelectList(db.BusinessType, "BusinessTypeId", "Name");
            ViewBag.BaseComId = new SelectList(db.Companys.Where(p => p.IsGroup == true), "ComId", "CompanyName");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");

            ViewBag.Title = "Create";
            return View("Create", company);
        }


        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Company company = db.Companys.Find(id);
            if (company == null)
            {
                return NotFound();
            }


            ViewBag.BusinessTypeId = new SelectList(db.BusinessType, "BusinessTypeId", "Name", company.BusinessTypeId);
            ViewBag.VoucherNoCreatedTypeId = new SelectList(db.Acc_VoucherNoCreatedTypes, "VoucherNoCreatedTypeId", "VoucherNoCreatedTypeName", company.VoucherNoCreatedTypeId);

            ViewBag.BaseComId = new SelectList(db.Companys.Where(p => p.IsGroup == true), "ComId", "CompanyName", company.BaseComId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", company.CountryId);

            //ViewBag.BusinessTypeList = db.BusinessType;// new SelectList(db.BusinessType, "BusinessTypeId", "Name");
            //ViewBag.BaseComList = db.Companys.Where(p => p.IsGroup == true);

            ////ViewBag.BaseComId = new SelectList(db.Companys.Where(p => p.IsGroup == true), "ComId", "CompanyName").ToList();
            ////ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            //ViewBag.CountryList = db.Countries;


            ViewBag.Title = "Edit";
            return View("Create", company);
        }

        private Image HandleImageUpload(byte[] binaryImage, string path)
        {
            //var i2 = new Bitmap(i);
            //i2.Save(i2Path, ImageFormat.Png);


            Image img = ResizeImage(Image.FromStream(BytearrayToStream(binaryImage)), 300, 300);

            //string uploadlocation = Path.GetFullPath(path);
            //var fileStream = new FileStream(path+"1.jpg", FileMode.Create);
            //img.Save(fileStream, ImageFormat.Png);
            //fileStream.Close();

            img.Save(path, ImageFormat.Png);
            return img;
        }



        private Image ResizeImage(Image img, int maxWidth, int maxHeight)
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
                    gr.Clear(Color.Transparent);

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


        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Company company = db.Companys.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            ViewBag.BusinessTypeId = new SelectList(db.BusinessType, "BusinessTypeId", "Name", company.BusinessTypeId);
            ViewBag.VoucherNoCreatedTypeId = new SelectList(db.Acc_VoucherNoCreatedTypes, "VoucherNoCreatedTypeId", "VoucherNoCreatedTypeName", company.VoucherNoCreatedTypeId);

            ViewBag.BaseComId = new SelectList(db.Companys.Where(p => p.IsGroup == true), "ComId", "CompanyName", company.BaseComId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", company.CountryId);

            ViewBag.Title = "Delete";
            return View("Create", company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {

            try
            {
                Company Company = db.Companys.Find(id);
                db.Companys.Remove(Company);
                db.SaveChanges();


                string fullPath = ("~/" + Company.HeaderImagePath + Company.ComId + Company.HeaderFileExtension);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }

                string fullPathLogo = ("~/" + Company.LogoImagePath + Company.ComId + Company.LogoFileExtension);
                if (System.IO.File.Exists(fullPathLogo))
                {
                    System.IO.File.Delete(fullPathLogo);
                }
                return Json(new { Success = 1, CompanyId = Company.ComId, ex = "" });

            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.Message.ToString() });

            }

            // return Json(new { Success = 0, ex = new Exception("Unable to Delete").Message.ToString() });

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
