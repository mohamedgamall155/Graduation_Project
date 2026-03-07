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
    public class CommitteesAssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommitteesAssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CommitteesAssignments.Include(c => c.Committee).Include(c => c.Person).Include(c => c.Role);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var committeesAssignment = await _context.CommitteesAssignments
                .Include(c => c.Committee)
                .Include(c => c.Person)
                .Include(c => c.Role)
                .FirstOrDefaultAsync(m => m.AssignmentID == id);
            if (committeesAssignment == null)
            {
                return NotFound();
            }

            return View(committeesAssignment);
        }

        public IActionResult Create()
        {
            ViewData["CommitteeID"] = new SelectList(_context.Committees, "CommitteeID", "CommitteeID");
            ViewData["PersonID"] = new SelectList(_context.Persons, "PersonId", "FullName");
            ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignmentID,PersonID,CommitteeID,RoleID,AssignmentType,StartTime,EndTime,RoleType")] CommitteesAssignment committeesAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(committeesAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommitteeID"] = new SelectList(_context.Committees, "CommitteeID", "CommitteeID", committeesAssignment.CommitteeID);
            ViewData["PersonID"] = new SelectList(_context.Persons, "PersonId", "FullName", committeesAssignment.PersonID);
            ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleName", committeesAssignment.RoleID);
            return View(committeesAssignment);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var committeesAssignment = await _context.CommitteesAssignments.FindAsync(id);
            if (committeesAssignment == null)
            {
                return NotFound();
            }
            ViewData["CommitteeID"] = new SelectList(_context.Committees, "CommitteeID", "CommitteeID", committeesAssignment.CommitteeID);
            ViewData["PersonID"] = new SelectList(_context.Persons, "PersonId", "FullName", committeesAssignment.PersonID);
            ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleName", committeesAssignment.RoleID);
            return View(committeesAssignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignmentID,PersonID,CommitteeID,RoleID,AssignmentType,StartTime,EndTime,RoleType")] CommitteesAssignment committeesAssignment)
        {
            if (id != committeesAssignment.AssignmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(committeesAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommitteesAssignmentExists(committeesAssignment.AssignmentID))
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
            ViewData["CommitteeID"] = new SelectList(_context.Committees, "CommitteeID", "CommitteeID", committeesAssignment.CommitteeID);
            ViewData["PersonID"] = new SelectList(_context.Persons, "PersonId", "FullName", committeesAssignment.PersonID);
            ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleName", committeesAssignment.RoleID);
            return View(committeesAssignment);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var committeesAssignment = await _context.CommitteesAssignments
                .Include(c => c.Committee)
                .Include(c => c.Person) 
                .Include(c => c.Role)
                .FirstOrDefaultAsync(m => m.AssignmentID == id);

            if (committeesAssignment == null)
            {
                return NotFound();
            }

            return View(committeesAssignment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var committeesAssignment = await _context.CommitteesAssignments.FindAsync(id);
            if (committeesAssignment != null)
            {
                _context.CommitteesAssignments.Remove(committeesAssignment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommitteesAssignmentExists(int id)
        {
            return _context.CommitteesAssignments.Any(e => e.AssignmentID == id);
        }
    }
}