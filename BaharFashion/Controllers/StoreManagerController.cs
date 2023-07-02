using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaharFashion.Models;

namespace BaharFashion.Controllers
{
    public class StoreManagerController : Controller
    {
        private readonly BaharFashionEntities _context;

        public StoreManagerController(BaharFashionEntities context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var baharFashionEntities = _context.Giyims.Include(g => g.Marka).Include(g => g.Tur);
            return View(await baharFashionEntities.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Giyims == null)
            {
                return NotFound();
            }

            var giyim = await _context.Giyims
                .Include(g => g.Marka)
                .Include(g => g.Tur)
                .FirstOrDefaultAsync(m => m.GiyimId == id);
            if (giyim == null)
            {
                return NotFound();
            }

            return View(giyim);
        }

       
        public IActionResult Create()
        {
            ViewData["MarkaId"] = new SelectList(_context.Markas, "MarkaId", "MarkaId");
            ViewData["TurId"] = new SelectList(_context.Turs, "TurId", "TurId");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GiyimId,TurId,MarkaId,Title,Price,GiyimArtUrl")] Giyim giyim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giyim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarkaId"] = new SelectList(_context.Markas, "MarkaId", "MarkaId", giyim.MarkaId);
            ViewData["TurId"] = new SelectList(_context.Turs, "TurId", "TurId", giyim.TurId);
            return View(giyim);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Giyims == null)
            {
                return NotFound();
            }

            var giyim = await _context.Giyims.FindAsync(id);
            if (giyim == null)
            {
                return NotFound();
            }
            ViewData["MarkaId"] = new SelectList(_context.Markas, "MarkaId", "MarkaId", giyim.MarkaId);
            ViewData["TurId"] = new SelectList(_context.Turs, "TurId", "TurId", giyim.TurId);
            return View(giyim);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GiyimId,TurId,MarkaId,Title,Price,GiyimArtUrl")] Giyim giyim)
        {
            if (id != giyim.GiyimId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giyim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiyimExists(giyim.GiyimId))
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
            ViewData["MarkaId"] = new SelectList(_context.Markas, "MarkaId", "MarkaId", giyim.MarkaId);
            ViewData["TurId"] = new SelectList(_context.Turs, "TurId", "TurId", giyim.TurId);
            return View(giyim);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Giyims == null)
            {
                return NotFound();
            }

            var giyim = await _context.Giyims
                .Include(g => g.Marka)
                .Include(g => g.Tur)
                .FirstOrDefaultAsync(m => m.GiyimId == id);
            if (giyim == null)
            {
                return NotFound();
            }

            return View(giyim);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Giyims == null)
            {
                return Problem("Entity set 'BaharFashionEntities.Giyims'  is null.");
            }
            var giyim = await _context.Giyims.FindAsync(id);
            if (giyim != null)
            {
                _context.Giyims.Remove(giyim);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiyimExists(int id)
        {
          return (_context.Giyims?.Any(e => e.GiyimId == id)).GetValueOrDefault();
        }
    }
}
