using ASPBookProject.Data;
using ASPBookProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPBookProject.Controllers
{
    public class MedicamentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicamentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var medicaments = await _context.Medicaments.ToListAsync();
            return View(medicaments);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var medicament = new Medicament
            {
                Nom = string.Empty,
                Allergie = string.Empty
            };
            return View("AddMedicaments", medicament);
        }



        [HttpPost]
        public async Task<IActionResult> Add(Medicament medicament)
        {
            if (string.IsNullOrWhiteSpace(medicament.Nom))
            {
                ModelState.AddModelError("Nom", "Le champ 'Nom' est obligatoire.");
            }
            if (string.IsNullOrWhiteSpace(medicament.Allergie))
            {
                ModelState.AddModelError("Allergie", "Le champ 'Allergie' est obligatoire.");
            }

            if (!ModelState.IsValid)
            {
                return View(medicament);
            }

            try
            {
                _context.Medicaments.Add(medicament);
                await _context.SaveChangesAsync();
                return RedirectToAction("ShowMedicaments", "Patient");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Une erreur est survenue : " + ex.Message);
                return View(medicament);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var medicament = await _context.Medicaments.FindAsync(id);
            if (medicament == null)
            {
                return NotFound();
            }

            return View("EditMedicament", "Patient");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Medicament medicament)
        {
            if (id != medicament.MedicamentId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View("EditMedicament", medicament);
            }

            try
            {
                _context.Entry(medicament).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentsExists(medicament.MedicamentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var medicament = await _context.Medicaments.FindAsync(id);
            if (medicament == null)
            {
                return NotFound();
            }
            return View(medicament);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicament = await _context.Medicaments.FindAsync(id);
            if (medicament == null)
            {
                return NotFound();
            }
            _context.Medicaments.Remove(medicament);
            await _context.SaveChangesAsync();
            return RedirectToAction("ShowMedicaments", "Patient");
        }

        private bool MedicamentsExists(int id)
        {
            return _context.Medicaments.Any(e => e.MedicamentId == id);
        }
        public IActionResult ChercMedi(string searchTerm)
        {
            var medicaments = _context.Medicaments.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                medicaments = medicaments.Where(m => m.Nom.Contains(searchTerm));
            }
            return View(medicaments.ToList());
        }
        public async Task<IActionResult> StatistiquesMédicaments()
        {
            var statistiques = await _context.Ordonnances
                .Where(o => o.Medicaments.Any())
                .SelectMany(o => o.Medicaments) 
                .GroupBy(m => m.Nom)            
                .Select(g => new Medicament
                {
                    Allergie = g.Key,
                    Nom = g.Key,
                    NombreUtilisations = g.Count() 
                })
                .OrderByDescending(m => m.NombreUtilisations) 
                .ToListAsync();

            if (statistiques.Count == 0)
            {
                Console.WriteLine("Aucun médicament trouvé.");
            }
            else
            {
                foreach (var medicament in statistiques)
                {
                    Console.WriteLine($"Nom: {medicament.Nom}, Nombre d'Utilisations: {medicament.NombreUtilisations}");
                }
            }

            return View(statistiques); 
        }


    }
}