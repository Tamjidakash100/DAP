using GTERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GTERP.Controllers
{
    [OverridableAuthorize]
    public class AssetsController : Controller
    {
        private readonly GTRDBContext _context;

        public AssetsController(GTRDBContext context)
        {
            _context = context;
        }

        // GET: Assets
        public async Task<IActionResult> Index()
        {
            var gTRDBContext = _context.Asset
                //.Include(a => a.Company)
                .Include(a => a.Location);
            return View(await gTRDBContext.ToListAsync());
        }

        // GET: Assets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                //.Include(a => a.AssetCategory)
                //.Include(a => a.Company)
                .Include(a => a.Location)
                .FirstOrDefaultAsync(m => m.AssetId == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // GET: Assets/Create
        public IActionResult Create()
        {
            var comid = HttpContext.Session.GetString("comid");
            ViewData["Items"] = new SelectList(_context.Products.Where(x => x.comid == comid), "ProductId", "ProductName");
            ViewData["AssetCategoryId"] = new SelectList(_context.Set<AssetCategory>(), "AssetCategoryId", "CatName");
            ViewData["ComId"] = new SelectList(_context.Companys.Where(x => x.CompanyCode == comid), "ComId", "CompanyName");
            ViewData["LocationId"] = new SelectList(_context.Cat_Location.Where(x => x.ComId == comid), "LId", "LocationName");
            ViewData["Custodian"] = new SelectList(_context.HR_Emp_Info.Where(x => x.ComId == comid), "EmpId", "EmpName");
            ViewData["CategoryId"] = new SelectList(_context.Categories.Where(c => c.comid == comid).Select(x => new { x.CategoryId, x.Name }), "CategoryId", "Name");
            ViewData["PurchaseType"] = new SelectList(_context.PurchaseTypes.Where(x => x.ComId == comid), "PurchaseTypeId", "TypeName");
            ViewData["Supplier"] = new SelectList(_context.Suppliers.Where(x => x.comid == comid), "SupplierId", "SupplierName");
            ViewData["DepreciationMethod"] = new SelectList(_context.DepreciationMethods, "DMId", "DMName");
            ViewData["Department"] = new SelectList(_context.Cat_Department.Where(x => x.ComId == comid), "DeptId", "DeptName");
            ViewData["AssetName"] = new SelectList(_context.Asset.Where(x => x.ComId == comid), "AssetId", "AssetName");
            ViewData["FoDId"] = new SelectList(_context.depreciationFrequencies.Where(x => x.ComId == comid).Select(x => new { x.FoDId, Text = x.Title + " -(" + x.CompoundingPeriod + ")" }), "FoDId", "Text");
            ViewData["Employees"] = new SelectList(_context.HR_Emp_Info.Where(c => c.ComId == comid).Select(x => new { x.EmpId, Text = x.EmpCode + " -" + x.EmpName }), "EmpId", "Text");

            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssetId,AssetName,AssetCategoryId,ComId,LocationId,PurchaseDate")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetCategoryId"] = new SelectList(_context.Set<AssetCategory>(), "AssetCategoryId", "AssetCategoryId");
            ViewData["ComId"] = new SelectList(_context.Companys, "ComId", "AppKey", asset.ComId);
            ViewData["LocationId"] = new SelectList(_context.Cat_Location, "LId", "LocationName", asset.LocationId);
            return View(asset);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DepreiationMethod(DepreciationMethod input)
        {
            if (input.DMId > 0)
            {
                _context.Entry(input).State = EntityState.Modified;
            }
            else
            {
                _context.Entry(input).State = EntityState.Added;

            }
            _context.SaveChanges();
            return Json(new { success = 1 });
        }

        // GET: Assets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            ViewData["AssetCategoryId"] = new SelectList(_context.Set<AssetCategory>(), "AssetCategoryId", "AssetCategoryId");
            ViewData["ComId"] = new SelectList(_context.Companys, "ComId", "AppKey", asset.ComId);
            ViewData["LocationId"] = new SelectList(_context.Cat_Location, "LId", "LocationName", asset.LocationId);
            return View(asset);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssetId,AssetName,AssetCategoryId,ComId,LocationId,PurchaseDate")] Asset asset)
        {
            if (id != asset.AssetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetExists(asset.AssetId))
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
            ViewData["AssetCategoryId"] = new SelectList(_context.Set<AssetCategory>(), "AssetCategoryId", "AssetCategoryId");
            ViewData["ComId"] = new SelectList(_context.Companys, "ComId", "AppKey", asset.ComId);
            ViewData["LocationId"] = new SelectList(_context.Cat_Location, "LId", "LocationName", asset.LocationId);
            return View(asset);
        }

        // GET: Assets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                //.Include(a => a.AssetCategory)
                //.Include(a => a.Company)
                .Include(a => a.Location)
                .FirstOrDefaultAsync(m => m.AssetId == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asset = await _context.Asset.FindAsync(id);
            _context.Asset.Remove(asset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetExists(int id)
        {
            return _context.Asset.Any(e => e.AssetId == id);
        }
    }
}
