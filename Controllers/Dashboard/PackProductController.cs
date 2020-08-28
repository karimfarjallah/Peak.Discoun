using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Peak.Discoun.Context;
using Peak.Discoun.Models;

namespace Peak.Discoun.Controllers.Dashboard
{
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
            var appDbContext = _context.PackProduct.Include(p => p.Pack).Include(p => p.Product);
            return View(await appDbContext.ToListAsync());
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packProduct = await _context.PackProduct.FindAsync(id);
            if (packProduct == null)
            {
                return NotFound();
            }
            ViewData["PackId"] = new SelectList(_context.Pack, "Id", "Name", packProduct.PackId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", packProduct.ProductId);
            return View(packProduct);
        }

        // POST: PackProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var packProduct = await _context.PackProduct.FindAsync(id);
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
