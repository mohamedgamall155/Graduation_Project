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
    public class RelativesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelativesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Relatives.Include(r => r.Person).Include(r => r.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relative = await _context.Relatives
                .Include(r => r.Person)
                .Include(r => r.Student)
                .FirstOrDefaultAsync(m => m.RelativeId == id);
            if (relative == null)
            {
                return NotFound();
            }

            return View(relative);
        }

        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "FullName");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RelativeId,StudentId,PersonId,RelationType,AcademicYear")] Relative relative)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relative);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "FullName", relative.PersonId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FullName", relative.StudentId);
            return View(relative);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relative = await _context.Relatives.FindAsync(id);
            if (relative == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "FullName", relative.PersonId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FullName", relative.StudentId);
            return View(relative);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RelativeId,StudentId,PersonId,RelationType,AcademicYear")] Relative relative)
        {
            if (id != relative.RelativeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relative);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelativeExists(relative.RelativeId))
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
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "FullName", relative.PersonId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FullName", relative.StudentId);
            return View(relative);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relative = await _context.Relatives
                .Include(r => r.Person)
                .Include(r => r.Student)
                .FirstOrDefaultAsync(m => m.RelativeId == id);
            if (relative == null)
            {
                return NotFound();
            }

            return View(relative);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relative = await _context.Relatives.FindAsync(id);
            if (relative != null)
            {
                _context.Relatives.Remove(relative);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelativeExists(int id)
        {
            return _context.Relatives.Any(e => e.RelativeId == id);
        }
    }
}