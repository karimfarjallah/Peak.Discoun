using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peak.Discount.Model;
using Peak.Discount.Dashboard.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Peak.Discount.Dashboard.Controllers.Dashboard
{
    [Authorize(Roles = "admin")]
    public class PacksController : Controller
    {
        private readonly AppDbContext _context;

        public PacksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Packs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pack.ToListAsync());
        }

        // GET: Packs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pack = await _context.Pack
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pack == null)
            {
                return NotFound();
            }

            return View(pack);
        }

        // GET: Packs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Packs/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,secondes")] Pack pack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pack);
        }

        // GET: Packs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pack = await _context.Pack.FindAsync(id);
            if (pack == null)
            {
                return NotFound();
            }
            return View(pack);
        }

        // POST: Packs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Description,secondes")] Pack pack)
        {
            if (id != pack.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackExists(pack.Id))
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
            return View(pack);
        }

        // GET: Packs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pack = await _context.Pack
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pack == null)
            {
                return NotFound();
            }

            return View(pack);
        }

        // POST: Packs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pack = await _context.Pack.FindAsync(id);
            _context.Pack.Remove(pack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackExists(int id)
        {
            return _context.Pack.Any(e => e.Id == id);
        }

        [HttpPost]
      
        public async Task<IActionResult> disable(int id)
        {
            var pack = await _context.Pack.FindAsync(id);
            _context.Pack.Remove(pack);
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Discount (int id )
        {
            var pack =  _context.Pack.Find(id);
            
            BackgroundJob.Schedule(() => DeleteConfirmed(id), TimeSpan.FromSeconds(pack.secondes));
            return RedirectToAction(nameof(Index));
        }

    }
}
