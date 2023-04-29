using GTERP.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;



//using GroupDocs.Viewer.Options;
//using GroupDocs.Viewer;
//using GroupDocs.Viewer.Results;

namespace GTERP.Controllers.HR
{
    [OverridableAuthorize]

    public class DocumentController : Controller
    {
        private readonly GTRDBContext _context;
        [Obsolete]
        private IHostingEnvironment _env;

        [Obsolete]
        public DocumentController(GTRDBContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Document
        public async Task<IActionResult> Index()
        {
            return View(await _context.HR_Emp_Document.ToListAsync());
        }


        // GET: Document/Create
        public IActionResult Create()
        {
            ViewBag.VarType = new SelectList(_context.Cat_Variable
                .Where(v => v.VarType == "DocumentType"), "VarName", "VarName");
            ViewBag.Title = "Create";
            return View();
        }

        // POST: Document/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Create(HR_Emp_Document model)
        {
            if (model == null ||
                model.FileToUpload == null || model.FileToUpload.Length == 0)
                return Content("File not selected");

            var path = _env.WebRootPath + "\\EmpDocument\\";


            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string comid = HttpContext.Session.GetString("comid");
            string userid = HttpContext.Session.GetString("userid");

            if (model.Id > 0)
            {
                var exist = _context.HR_Emp_Document.Find(model.Id);

                if (Directory.Exists(path + exist.FilePath))
                {
                    System.IO.File.Delete(exist.FilePath);
                }


                path = Path.Combine(path, GetFilename(model.RefCode, model.FileToUpload));
                exist.RefCode = model.RefCode;
                exist.Title = model.Title;
                exist.Remarks = model.Remarks;
                exist.FileName = model.FileToUpload.FileName;
                exist.FilePath = model.RefCode + "_" + model.FileName;

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.FileToUpload.CopyToAsync(stream);
                }

                exist.UpdateByUserId = userid;
                exist.DateUpdated = DateTime.Now;

                _context.Entry(exist).State = EntityState.Modified;
                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
            }
            else
            {
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, GetFilename(model.RefCode, model.FileToUpload));

                    model.FileName = model.FileToUpload.FileName;
                    model.FilePath = model.RefCode + "_" + model.FileName; ;
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.FileToUpload.CopyToAsync(stream);
                    }

                    model.ComId = comid;
                    model.UserId = userid;
                    model.DateAdded = DateTime.Now;

                    _context.Add(model);
                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Obsolete]
        public IActionResult Download(int id)
        {
            var document = _context.HR_Emp_Document.Find(id);


            if (document == null)
            {
                return Content("Document not found");
            }

            string filepath = _env.WebRootPath + "\\EmpDocument\\" + document.FilePath;
            if (!System.IO.File.Exists(filepath))
            {
                return NotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(filepath);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = document.FilePath
            };
            return response;


            //var path = Path.Combine(
            //               Directory.GetCurrentDirectory(),
            //               @"Content\EmpDocument\",document.RefCode+"_"+document.FileName);

            //if (!System.IO.File.Exists(filePath))
            //{
            //    return Content("File not present");
            //}

            //if (!Directory.Exists(filePath))
            //return Content("filename not present");


            //var memory = new MemoryStream();
            //using (var stream = new FileStream(filePath, FileMode.Open))
            //{
            //    await stream.CopyToAsync(memory);
            //}
            ////memory.Position = 0;
            //return File(memory, GetContentType(path), Path.GetFileName(path));
        }


        // ----------------------------------test document preview by himu
        //[HttpPost]
        //[Obsolete]
        //public IActionResult DocumentPreview(int id)
        //{
        //    var document = _context.HR_Emp_Document.Find(id);
        //    if (document == null)
        //    {
        //        return Content("Document not found");
        //    }

        //    string filepath = _env.WebRootPath + "\\EmpDocument\\" + document.FilePath;
        //    if (!System.IO.File.Exists(filepath))
        //    {
        //        return NotFound();
        //    }

        //    int pageCount = 0;
        //    using (Viewer viewer = new Viewer(filepath))
        //    {
        //        ViewInfo info = viewer.GetViewInfo(ViewInfoOptions.ForPngView(false));
        //        pageCount = info.Pages.Count;

        //        PngViewOptions options = new PngViewOptions(filepath);
        //        viewer.View(options);
        //    }
        //    return new JsonResult(new { pageCount = pageCount, filepath = filepath });
        //}

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"},
                {".mp4", "video/mp4"}
            };
        }



        string GetFilename(string code, IFormFile file)
        {
            var name = ContentDispositionHeaderValue.Parse(
                            file.ContentDisposition).FileName.ToString().Trim('"');
            return code + "_" + name;
        }

        // GET: Document/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Edit";
            var hR_Emp_Document = await _context.HR_Emp_Document.FindAsync(id);
            if (hR_Emp_Document == null)
            {
                return NotFound();
            }

            ViewBag.VarType = new SelectList(_context.Cat_Variable
               .Where(v => v.VarType == "DocumentType"), "VarName", "VarName");

            return View("Create", hR_Emp_Document);
        }


        // GET: Document/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hR_Emp_Document = await _context.HR_Emp_Document
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hR_Emp_Document == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Delete";
            ViewBag.VarType = new SelectList(_context.Cat_Variable
               .Where(v => v.VarType == "DocumentType"), "VarName", "VarName");
            return View("Create", hR_Emp_Document);
        }

        // POST: Document/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hR_Emp_Document = await _context.HR_Emp_Document.FindAsync(id);
            _context.HR_Emp_Document.Remove(hR_Emp_Document);

            if (System.IO.File.Exists(hR_Emp_Document.FilePath))
            {
                System.IO.File.Delete(hR_Emp_Document.FilePath);
            }
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            TempData["Message"] = "Data Delete Successfully";
            return Json(new { Success = 1, ex = TempData["Message"].ToString() });
        }

        private bool HR_Emp_DocumentExists(int id)
        {
            return _context.HR_Emp_Document.Any(e => e.Id == id);
        }
    }
}
