using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestAuthentification.Data;
using TestAuthentification.Models;

namespace TestAuthentification.Controllers
{
    public class TypeConsultationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeConsultationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeConsultations
        public async Task<IActionResult> Index()
        {
              return View(await _context.TypeConsultation.ToListAsync());
        }

        // GET: TypeConsultations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeConsultation == null)
            {
                return NotFound();
            }

            var typeConsultation = await _context.TypeConsultation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeConsultation == null)
            {
                return NotFound();
            }

            return View(typeConsultation);
        }

        // GET: TypeConsultations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeConsultations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Description")] TypeConsultation typeConsultation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeConsultation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeConsultation);
        }

        // GET: TypeConsultations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeConsultation == null)
            {
                return NotFound();
            }

            var typeConsultation = await _context.TypeConsultation.FindAsync(id);
            if (typeConsultation == null)
            {
                return NotFound();
            }
            return View(typeConsultation);
        }

        // POST: TypeConsultations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Description")] TypeConsultation typeConsultation)
        {
            if (id != typeConsultation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeConsultation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeConsultationExists(typeConsultation.Id))
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
            return View(typeConsultation);
        }

        // GET: TypeConsultations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeConsultation == null)
            {
                return NotFound();
            }

            var typeConsultation = await _context.TypeConsultation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeConsultation == null)
            {
                return NotFound();
            }

            return View(typeConsultation);
        }

        // POST: TypeConsultations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeConsultation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TypeConsultation'  is null.");
            }
            var typeConsultation = await _context.TypeConsultation.FindAsync(id);
            if (typeConsultation != null)
            {
                _context.TypeConsultation.Remove(typeConsultation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeConsultationExists(int id)
        {
          return _context.TypeConsultation.Any(e => e.Id == id);
        }
    }
}
