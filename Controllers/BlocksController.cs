using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projectweb.Models;

namespace projectweb.Controllers
{
    public class BlocksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlocksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Blocks.Include(b => b.Hall);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var block = await _context.Blocks
                .Include(b => b.Hall)
                .FirstOrDefaultAsync(m => m.BlockID == id);
            if (block == null)
            {
                return NotFound();
            }

            return View(block);
        }

        public IActionResult Create()
        {
            ViewData["HallID"] = new SelectList(_context.Halls, "HallId", "HallName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlockID,BlockName,StartTime,EndTime,HallID")] Block block)
        {
            if (ModelState.IsValid)
            {
                _context.Add(block);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HallID"] = new SelectList(_context.Halls, "HallId", "HallName", block.HallID);
            return View(block);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var block = await _context.Blocks.FindAsync(id);
            if (block == null)
            {
                return NotFound();
            }
            ViewData["HallID"] = new SelectList(_context.Halls, "HallId", "HallName", block.HallID);
            return View(block);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlockID,BlockName,StartTime,EndTime,HallID")] Block block)
        {
            if (id != block.BlockID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(block);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlockExists(block.BlockID))
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
            ViewData["HallID"] = new SelectList(_context.Halls, "HallId", "HallName", block.HallID);
            return View(block);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var block = await _context.Blocks
                .Include(b => b.Hall)
                .FirstOrDefaultAsync(m => m.BlockID == id);
            if (block == null)
            {
                return NotFound();
            }

            return View(block);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var block = await _context.Blocks.FindAsync(id);
            if (block != null)
            {
                _context.Blocks.Remove(block);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlockExists(int id)
        {
            return _context.Blocks.Any(e => e.BlockID == id);
        }
    }
}