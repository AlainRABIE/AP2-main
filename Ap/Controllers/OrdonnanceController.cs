using ASPBookProject.Data;
using ASPBookProject.Models;
using ASPBookProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPBookProject.Controllers
{
    public class OrdonnanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdonnanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]


        public async Task<IActionResult> Index()
        {
            var ordonnances = await _context.Ordonnances
                .Include(o => o.Patient)
                .Include(o => o.Medecin)
                .ToListAsync();

            return View(ordonnances);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ordonnance = await _context.Ordonnances
                .Include(o => o.Patient)
                .FirstOrDefaultAsync(o => o.OrdonnanceId == id);

            if (ordonnance == null)
            {
                return NotFound();
            }

            var viewModel = new OrdonnanceViewModel
            {
                OrdonnanceId = ordonnance.OrdonnanceId,
                PatientId = ordonnance.PatientId,
                Patologie = ordonnance.Patologie,
                DateDébut = ordonnance.DateDébut,
                DateFin = ordonnance.DateFin,
                MedecinId = ordonnance.MedecinId,
                Patients = await _context.Patients.ToListAsync(),
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrdonnanceViewModel viewModel)
        {
            if (id != viewModel.OrdonnanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ordonnance = await _context.Ordonnances.FindAsync(id);
                    if (ordonnance == null)
                    {
                        return NotFound();
                    }

                    ordonnance.PatientId = viewModel.PatientId;
                    ordonnance.Patologie = viewModel.Patologie;
                    ordonnance.DateDébut = viewModel.DateDébut;
                    ordonnance.DateFin = viewModel.DateFin;
                    ordonnance.MedecinId = viewModel.MedecinId;

                    _context.Update(ordonnance);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdonnanceExists(viewModel.OrdonnanceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            viewModel.Patients = await _context.Patients.ToListAsync();
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var ordonnance = await _context.Ordonnances
                .Include(o => o.Patient)
                .Include(o => o.Medecin)
                .FirstOrDefaultAsync(o => o.OrdonnanceId == id);

            if (ordonnance == null)
            {
                return NotFound();
            }

            return View(ordonnance);
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


        private bool OrdonnanceExists(int id)
        {
            return _context.Ordonnances.Any(e => e.OrdonnanceId == id);
        }


        [HttpGet]
        public async Task<IActionResult> EditOrdonnance(int id)
        {
            var ordonnance = await _context.Ordonnances
                .Include(o => o.Patient) 
                .Include(o => o.Medecin) 
                .Include(o => o.Medicaments)
                .FirstOrDefaultAsync(o => o.OrdonnanceId == id);

            if (ordonnance == null)
            {
                return NotFound();
            }

            return View(ordonnance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOrdonnance(int id, Ordonnance ordonnance)
        {
            if (id != ordonnance.OrdonnanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordonnance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Ordonnances.Any(o => o.OrdonnanceId == id))
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
            return View(ordonnance);
        }
    }
}