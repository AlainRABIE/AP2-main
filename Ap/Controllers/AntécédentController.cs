using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPBookProject.Data;
using ASPBookProject.Models;
using ASPBookProject.ViewModels;  

namespace ASPBookProject.Controllers
{
    public class AntecedentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AntecedentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var antecedents = await _context.Antecedents.ToListAsync();
            return View(antecedents);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new AntecedentEditViewModel
            {
                Medicaments = _context.Medicaments.ToList(),
                Patients = _context.Patients.ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Antecedent antecedent)
        {
            if (ModelState.IsValid)
            {
                _context.Antecedents.Add(antecedent);  
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(antecedent);  
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var antecedent = await _context.Antecedents
                .Include(a => a.Medicaments)
                .Include(a => a.Patients)
                .FirstOrDefaultAsync(a => a.AntecedentId == id);

            if (antecedent == null)
            {
                return NotFound();
            }

            var viewModel = new AntecedentEditViewModel
            {
                Antecedent = antecedent,
                Nom = antecedent.Nom, 
                Medicaments = antecedent.Medicaments,
                Patients = antecedent.Patients
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AntecedentEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var antecedent = await _context.Antecedents.FindAsync(viewModel.Antecedent.AntecedentId);
                if (antecedent == null)
                {
                    return NotFound();
                }

                antecedent.Nom = viewModel.Nom ?? string.Empty; 

                antecedent.Medicaments = _context.Medicaments
                    .Where(m => viewModel.SelectedMedicamentIds.Contains(m.MedicamentId))
                    .ToList();
                antecedent.Patients = _context.Patients
                    .Where(p => viewModel.SelectedPatientIds.Contains(p.PatientId))
                    .ToList();

                _context.Update(antecedent);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var antecedent = await _context.Antecedents.FindAsync(id);
            if (antecedent == null)
            {
                return NotFound();
            }

            _context.Antecedents.Remove(antecedent);  
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
