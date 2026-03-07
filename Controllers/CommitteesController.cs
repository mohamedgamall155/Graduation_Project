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
    public class CommitteesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommitteesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Committees.Include(c => c.Block);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var committee = await _context.Committees
                .Include(c => c.Block)
                .FirstOrDefaultAsync(m => m.CommitteeID == id);
            if (committee == null)
            {
                return NotFound();
            }

            return View(committee);
        }

        public IActionResult Create()
        {
            ViewData["BlockID"] = new SelectList(_context.Blocks, "BlockID", "BlockID");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommitteeID,CommitteeNumber,RequiredMentors,RequiredObservers,RequiredHeads,NumberOfStudent,StatusOfCommittee,BlockID")] Committee committee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(committee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlockID"] = new SelectList(_context.Blocks, "BlockID", "BlockID", committee.BlockID);
            return View(committee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var committee = await _context.Committees.FindAsync(id);
            if (committee == null)
            {
                return NotFound();
            }
            ViewData["BlockID"] = new SelectList(_context.Blocks, "BlockID", "BlockID", committee.BlockID);
            return View(committee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommitteeID,CommitteeNumber,RequiredMentors,RequiredObservers,RequiredHeads,NumberOfStudent,StatusOfCommittee,BlockID")] Committee committee)
        {
            if (id != committee.CommitteeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(committee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommitteeExists(committee.CommitteeID))
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
            ViewData["BlockID"] = new SelectList(_context.Blocks, "BlockID", "BlockID", committee.BlockID);
            return View(committee);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var committee = await _context.Committees
                .Include(c => c.Block)
                .FirstOrDefaultAsync(m => m.CommitteeID == id);
            if (committee == null)
            {
                return NotFound();
            }

            return View(committee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var committee = await _context.Committees.FindAsync(id);
            if (committee != null)
            {
                _context.Committees.Remove(committee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommitteeExists(int id)
        {
            return _context.Committees.Any(e => e.CommitteeID == id);
        }
    }
}