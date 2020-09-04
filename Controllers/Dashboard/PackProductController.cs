using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Peak.Discount.Dashboard.Context;
using Peak.Discount.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Peak.Discount.Dashboard.Dashboard
{
    [Authorize(Roles = "admin")]
    public class PackProductController : Controller
    {
        private readonly AppDbContext _context;

        public PackProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PackProduct
        public async Task<IActionResult> Index()
        {

            var packs = _context.Pack.Include(x => x.PackProducts).ThenInclude(x => x.Product).ToList();

            

            return View(packs);
        }

        // GET: PackProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packProduct = await _context.PackProduct
                .Include(p => p.Pack)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.PackId == id);
            if (packProduct == null)
            {
                return NotFound();
            }

            return View(packProduct);
        }

        // GET: PackProduct/Create
        public IActionResult Create()
        {
            ViewData["PackId"] = new SelectList(_context.Pack, "Id", "Name");
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name");
            return View();
        }

        // POST: PackProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PackId,ProductId")] PackProduct packProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(packProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PackId"] = new SelectList(_context.Pack, "Id", "Name", packProduct.PackId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", packProduct.ProductId);
            return View(packProduct);
        }

        // GET: PackProduct/Edit/5
        public async Task<IActionResult> Edit(int? PackId, int? ProductId)
        {
            if (PackId == null)
            {
                return NotFound();
            }

            var packProduct = await _context.PackProduct.FindAsync(PackId, ProductId);
            if (packProduct == null)
            {
                return NotFound();
            }
            ViewData["PackId"] = new SelectList(_context.Pack, "Id", "Name", packProduct.PackId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", packProduct.ProductId);
            return View(packProduct);
        }

        // POST: PackProduct/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PackId,ProductId")] PackProduct packProduct)
        {
            if (id != packProduct.PackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(packProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackProductExists(packProduct.PackId))
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
            ViewData["PackId"] = new SelectList(_context.Pack, "Id", "Name", packProduct.PackId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", packProduct.ProductId);
            return View(packProduct);
        }

        // GET: PackProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packProduct = await _context.PackProduct
                .Include(p => p.Pack)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.PackId == id);
            if (packProduct == null)
            {
                return NotFound();
            }

            return View(packProduct);
        }

        // POST: PackProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int PackId , int ProductId)
        {
            var packProduct = await _context.PackProduct.FindAsync(PackId,ProductId);
            _context.PackProduct.Remove(packProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackProductExists(int id)
        {
            return _context.PackProduct.Any(e => e.PackId == id);
        }
    }
}
