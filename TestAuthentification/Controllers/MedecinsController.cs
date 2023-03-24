using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestAuthentification.Data;
using TestAuthentification.Models;

namespace TestAuthentification.Controllers
{
    //[Authorize]
    public class MedecinsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MedecinsController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Medecins
        public async Task<IActionResult> Index(string? search)
        {
            if(string.IsNullOrEmpty(search))
              return View(await _context.Medecin.ToListAsync());
            else
                return View(await _context.Medecin
                    .Where(m=> EF.Functions.Like(m.Prenom, "%" + search + "%"))
                    .ToListAsync());
   
        }

        [Authorize(Roles ="Medecin,Admin")]
        public async Task<IActionResult> ListeConsultationByMedecin(int? id)
        {
            var medecin = await _context.Medecin.Include(t=>t.Consultations)
                .FirstOrDefaultAsync(m => m.Id == id);
            return View(medecin);
        }

        // GET: Medecins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medecin == null)
            {
                return NotFound();
            }

            var medecin = await _context.Medecin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medecin == null)
            {
                return NotFound();
            }

            return View(medecin);
        }

        // GET: Medecins/Create
        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medecins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Prenom,Nom,Email,Adresse")] Medecin medecin)
        {
            if (ModelState.IsValid)
            {
                // Création d'un medecin
                _context.Add(medecin);
                await _context.SaveChangesAsync();

                //Création d'un utilisateur
                ApplicationUser applicationUser = new() { 
                    Email= medecin.Email,
                    UserName= medecin.Email,
                    DisplayName =medecin.DisplayName,
                    MedecinId=medecin.Id
                };
                //Créer l'utilisateur
                var result=await _userManager.CreateAsync(applicationUser,"Passer@123");
                if (result.Succeeded)
                {
                    // Ajouter le role à l'utilisateur
                    await _userManager.AddToRoleAsync(applicationUser, "Medecin");
                }

                return RedirectToAction(nameof(Index));
            }
            return View(medecin);
        }

        // GET: Medecins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medecin == null)
            {
                return NotFound();
            }

            var medecin = await _context.Medecin.FindAsync(id);
            if (medecin == null)
            {
                return NotFound();
            }
            return View(medecin);
        }

        // POST: Medecins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Prenom,Nom,Email,Adresse")] Medecin medecin)
        {
            if (id != medecin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medecin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedecinExists(medecin.Id))
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
            return View(medecin);
        }

        // GET: Medecins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medecin == null)
            {
                return NotFound();
            }

            var medecin = await _context.Medecin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medecin == null)
            {
                return NotFound();
            }

            return View(medecin);
        }

        // POST: Medecins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medecin == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Medecin'  is null.");
            }
            var medecin = await _context.Medecin.FindAsync(id);
            if (medecin != null)
            {
                _context.Medecin.Remove(medecin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedecinExists(int id)
        {
          return _context.Medecin.Any(e => e.Id == id);
        }
    }
}
