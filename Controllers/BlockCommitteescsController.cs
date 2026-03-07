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
    public class BlockCommitteesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlockCommitteesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BlockCommittees.Include(b => b.Block).Include(b => b.Committee);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? blockId, int? committeeId)
        {
            if (blockId == null || committeeId == null)
            {
                return NotFound();
            }

            var blockCommittee = await _context.BlockCommittees
                .Include(b => b.Block)
                .Include(b => b.Committee)
                .FirstOrDefaultAsync(m => m.BlockID == blockId && m.CommitteeID == committeeId);

            if (blockCommittee == null)
            {
                return NotFound();
            }

            return View(blockCommittee);
        }

        public IActionResult Create()
        {
            ViewData["BlockID"] = new SelectList(_context.Blocks, "BlockID", "BlockName");
            ViewData["CommitteeID"] = new SelectList(_context.Committees, "CommitteeID", "CommitteeNumber");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlockID,CommitteeID")] BlockCommittee blockCommittee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blockCommittee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlockID"] = new SelectList(_context.Blocks, "BlockID", "BlockName", blockCommittee.BlockID);
            ViewData["CommitteeID"] = new SelectList(_context.Committees, "CommitteeID", "CommitteeNumber", blockCommittee.CommitteeID);
            return View(blockCommittee);
        }

        public async Task<IActionResult> Edit(int? blockId, int? committeeId)
        {
            if (blockId == null || committeeId == null)
            {
                return NotFound();
            }

            var blockCommittee = await _context.BlockCommittees
                .FirstOrDefaultAsync(m => m.BlockID == blockId && m.CommitteeID == committeeId);

            if (blockCommittee == null)
            {
                return NotFound();
            }
            ViewData["BlockID"] = new SelectList(_context.Blocks, "BlockID", "BlockName", blockCommittee.BlockID);
            ViewData["CommitteeID"] = new SelectList(_context.Committees, "CommitteeID", "CommitteeNumber", blockCommittee.CommitteeID);
            return View(blockCommittee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int blockId, int committeeId, [Bind("BlockID,CommitteeID")] BlockCommittee blockCommittee)
        {
            if (blockId != blockCommittee.BlockID || committeeId != blockCommittee.CommitteeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blockCommittee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlockCommitteeExists(blockCommittee.BlockID, blockCommittee.CommitteeID))
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
            ViewData["BlockID"] = new SelectList(_context.Blocks, "BlockID", "BlockName", blockCommittee.BlockID);
            ViewData["CommitteeID"] = new SelectList(_context.Committees, "CommitteeID", "CommitteeNumber", blockCommittee.CommitteeID);
            return View(blockCommittee);
        }

        public async Task<IActionResult> Delete(int? blockId, int? committeeId)
        {
            if (blockId == null || committeeId == null)
            {
                return NotFound();
            }

            var blockCommittee = await _context.BlockCommittees
                .Include(b => b.Block)
                .Include(b => b.Committee)
                .FirstOrDefaultAsync(m => m.BlockID == blockId && m.CommitteeID == committeeId);

            if (blockCommittee == null)
            {
                return NotFound();
            }

            return View(blockCommittee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int blockId, int committeeId)
        {
            var blockCommittee = await _context.BlockCommittees
                .FirstOrDefaultAsync(m => m.BlockID == blockId && m.CommitteeID == committeeId);

            if (blockCommittee != null)
            {
                _context.BlockCommittees.Remove(blockCommittee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlockCommitteeExists(int blockId, int committeeId)
        {
            return _context.BlockCommittees.Any(e => e.BlockID == blockId && e.CommitteeID == committeeId);
        }
    }
}