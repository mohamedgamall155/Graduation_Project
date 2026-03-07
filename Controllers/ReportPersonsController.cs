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
    public class ReportPersonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportPersonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ReportPersons
                .Include(r => r.Person)
                .Include(r => r.Report)
                .Include(r => r.Role);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? reportId, int? personId)
        {
            if (reportId == null || personId == null)
            {
                return NotFound();
            }

            var reportPerson = await _context.ReportPersons
                .Include(r => r.Person)
                .Include(r => r.Report)
                .Include(r => r.Role)
                .FirstOrDefaultAsync(m => m.ReportID == reportId && m.PersonID == personId);

            if (reportPerson == null)
            {
                return NotFound();
            }

            return View(reportPerson);
        }

        public IActionResult Create()
        {
            ViewData["PersonID"] = new SelectList(_context.Persons, "PersonID", "FullName");
            ViewData["ReportID"] = new SelectList(_context.Reports, "ReportID", "ReportID");
            ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportID,PersonID,RoleID,Signature,SignedAt")] ReportPerson reportPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonID"] = new SelectList(_context.Persons, "PersonID", "FullName", reportPerson.PersonID);
            ViewData["ReportID"] = new SelectList(_context.Reports, "ReportID", "ReportID", reportPerson.ReportID);
            ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleName", reportPerson.RoleID);
            return View(reportPerson);
        }

        public async Task<IActionResult> Edit(int? reportId, int? personId)
        {
            if (reportId == null || personId == null)
            {
                return NotFound();
            }

            var reportPerson = await _context.ReportPersons
                .FirstOrDefaultAsync(m => m.ReportID == reportId && m.PersonID == personId);

            if (reportPerson == null)
            {
                return NotFound();
            }
            ViewData["PersonID"] = new SelectList(_context.Persons, "PersonID", "FullName", reportPerson.PersonID);
            ViewData["ReportID"] = new SelectList(_context.Reports, "ReportID", "ReportID", reportPerson.ReportID);
            ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleName", reportPerson.RoleID);
            return View(reportPerson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int reportId, int personId, [Bind("ReportID,PersonID,RoleID,Signature,SignedAt")] ReportPerson reportPerson)
        {
            if (reportId != reportPerson.ReportID || personId != reportPerson.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportPersonExists(reportPerson.ReportID, reportPerson.PersonID))
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
            ViewData["PersonID"] = new SelectList(_context.Persons, "PersonID", "FullName", reportPerson.PersonID);
            ViewData["ReportID"] = new SelectList(_context.Reports, "ReportID", "ReportID", reportPerson.ReportID);
            ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleName", reportPerson.RoleID);
            return View(reportPerson);
        }

        public async Task<IActionResult> Delete(int? reportId, int? personId)
        {
            if (reportId == null || personId == null)
            {
                return NotFound();
            }

            var reportPerson = await _context.ReportPersons
                .Include(r => r.Person)
                .Include(r => r.Report)
                .Include(r => r.Role)
                .FirstOrDefaultAsync(m => m.ReportID == reportId && m.PersonID == personId);

            if (reportPerson == null)
            {
                return NotFound();
            }

            return View(reportPerson);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int reportId, int personId)
        {
            var reportPerson = await _context.ReportPersons
                .FirstOrDefaultAsync(m => m.ReportID == reportId && m.PersonID == personId);

            if (reportPerson != null)
            {
                _context.ReportPersons.Remove(reportPerson);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportPersonExists(int reportId, int personId)
        {
            return _context.ReportPersons.Any(e => e.ReportID == reportId && e.PersonID == personId);
        }
    }
}