using ASPBookProject.Data;
using ASPBookProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPBookProject.ViewModels;

public class PatientEditViewModel
{
    public Patient? Patient { get; set; }
    public Patient? Interdiction { get; set; }
    public List<Antecedent>? Antecedents { get; set; }
    public List<Incompatibilite>? Incompatibilites { get; set; }
    public List<int> SelectedAntecedentIds { get; set; } = new List<int>();
    public List<int> SelectedIncompatibilitesId { get; set; } = new List<int>();
}

namespace ASPBookProject.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var patients = await _context.Patients.ToListAsync();
            return View(patients);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _context.Patients
                .Include(p => p.Antecedents)
                .Include(p => p.Incompatibilites)
                .FirstOrDefaultAsync(p => p.PatientId == id);

            if (patient == null)
            {
                return NotFound();
            }

            var viewModel = new PatientEditViewModel
            {
                Patient = patient,
                Antecedents = await _context.Antecedents.ToListAsync(),
                Incompatibilites = await _context.Incompatibilites.ToListAsync(),
                SelectedAntecedentIds = patient.Antecedents?.Select(a => a.AntecedentId).ToList() ?? new List<int>(),
                SelectedIncompatibilitesId = patient.Incompatibilites?.Select(i => i.IncompatibiliteId).ToList() ?? new List<int>()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PatientEditViewModel viewModel)
        {
            if (id != viewModel.Patient.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var patient = await _context.Patients
                        .Include(p => p.Antecedents)
                        .FirstOrDefaultAsync(p => p.PatientId == id);

                    if (patient == null)
                    {
                        return NotFound();
                    }
                    patient.Age = viewModel.Patient.Age;
                    patient.Prenom = viewModel.Patient.Prenom;
                    patient.Nom = viewModel.Patient.Nom;

                    patient.Antecedents.Clear();
                    patient.Antecedents = _context.Antecedents
                        .Where(a => viewModel.SelectedAntecedentIds.Contains(a.AntecedentId))
                        .ToList();

                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(viewModel.Patient.PatientId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            viewModel.Antecedents = await _context.Antecedents.ToListAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _context.Patients
                .Include(p => p.Antecedents)
                .Include(p => p.Incompatibilites)
                .FirstOrDefaultAsync(p => p.PatientId == id);

            if (patient == null)
            {
                return NotFound();
            }

            var viewModel = new PatientEditViewModel
            {
                Patient = patient,
                Antecedents = await _context.Antecedents.ToListAsync(),
                Incompatibilites = await _context.Incompatibilites.ToListAsync(),
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.PatientId == id);
        }

        [HttpGet]
        public async Task<IActionResult> ShowDetail(int id)
        {
            var patient = await _context.Patients
                .Include(p => p.Antecedents)
                .Include(p => p.Incompatibilites)
                .FirstOrDefaultAsync(p => p.PatientId == id);

            if (patient == null)
            {
                return NotFound();
            }

            var viewModel = new PatientEditViewModel
            {
                Patient = patient,
                Antecedents = patient.Antecedents?.ToList(),
                Incompatibilites = patient.Incompatibilites?.ToList()
            };

            return View("Details", viewModel);
        }


        public async Task<IActionResult> ShowMedicaments()
        {
            var medicaments = await _context.Medicaments.ToListAsync();
            return View(medicaments);
        }

        public IActionResult ListPatients()
        {
            var patients = _context.Patients.ToList();
            return View(patients);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string identifiant, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(identifiant) || string.IsNullOrWhiteSpace(password))
            {
                return BadRequest("Identifiant et mot de passe sont requis.");
            }

            var exists = _context.Medecins.Any(m => m.Identifiant == identifiant);
            if (exists)
            {
                return BadRequest("Cet identifiant existe déjà.");
            }

            var medecin = new Medecin
            {
                Identifiant = identifiant,
                UserName = username ?? identifiant,
                Email = $"{identifiant}@example.com",
                PasswordHash = password
            };

            try
            {
                _context.Medecins.Add(medecin);
                _context.SaveChanges();

                return Ok("Médecin inscrit avec succès !");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de l'inscription : {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Models.Medecin model)
        {
            if (ModelState.IsValid)
            {
                var medecin = _context.Medecins.FirstOrDefault(m => m.Identifiant == model.Identifiant);

                if (medecin != null && model.PasswordHash == medecin.PasswordHash)
                {
                    return RedirectToAction("index", "Patient");
                }

                ModelState.AddModelError(string.Empty, "Identifiant ou mot de passe incorrect.");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ShowOrdonnance()
        {
            return View(new ShowOrdonnanceViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> ShowOrdonnance(string patientName)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.Nom.Contains(patientName));

            if (patient == null)
            {
                return View("~/Views/Erreur/NoPatient.cshtml");
            }

            var ordonnances = await _context.Ordonnances
     .Where(o => o.PatientId == patient.PatientId)
     .Include(o => o.Patient)
     .Include(o => o.Medecin)
     .Include(o => o.Medicaments)  // Ajout de l'inclusion des médicaments
     .ToListAsync();

            if (!ordonnances.Any())
            {
                return View("~/Views/Erreur/NoOrdonnances.cshtml");
            }
            var viewModel = new ShowOrdonnanceViewModel
            {
                PatientId = patient.PatientId,
                Ordonnances = ordonnances
            };

            return View(viewModel);
        }
        public async Task<IActionResult> AddPatient()
        {
            var viewModel = new PatientEditViewModel
            {
                Antecedents = await _context.Antecedents.ToListAsync(),
                Incompatibilites = await _context.Incompatibilites.ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPatient(PatientEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var patient = model.Patient;

                // Récupérer les antécédents sélectionnés
                patient.Antecedents = await _context.Antecedents
                    .Where(a => model.SelectedAntecedentIds.Contains(a.AntecedentId))
                    .ToListAsync();

                // Récupérer les incompatibilités (allergies) sélectionnées
                patient.Incompatibilites = await _context.Incompatibilites
                    .Where(i => model.SelectedIncompatibilitesId.Contains(i.IncompatibiliteId))
                    .ToListAsync();

                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            // Recharger les listes d'antécédents et d'incompatibilités en cas d'erreur de validation
            model.Antecedents = await _context.Antecedents.ToListAsync();
            model.Incompatibilites = await _context.Incompatibilites.ToListAsync();
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> DownloadOrdonnance(int ordonnanceId)
        {
            var ordonnance = await _context.Ordonnances
                .Include(o => o.Medicaments)
                .FirstOrDefaultAsync(o => o.OrdonnanceId == ordonnanceId);

            if (ordonnance == null)
            {
                return NotFound();
            }

            var fileContent = $"Ordonnance ID: {ordonnance.OrdonnanceId}\n" +
                              $"Date Début: {ordonnance.DateDébut:yyyy-MM-dd}\n" +
                              $"Date Fin: {ordonnance.DateFin:yyyy-MM-dd}\n" +
                              $"Pathologie: {ordonnance.Patologie}\n" +
                              $"Médecin ID: {ordonnance.Medicaments}\n\n" +
                              "Médicaments:\n";

            foreach (var medicament in ordonnance.Medicaments)
            {
                fileContent += $"- {medicament.Nom}: {medicament.Posologie}\n";
            }

            // Convertir le texte en PDF avec les options de base d'en-tête.
            byte[] pdfBytes;
            using (var ms = new MemoryStream())
            {
                var writer = new StreamWriter(ms);
                writer.Write(fileContent);
                writer.Flush();

                pdfBytes = ms.ToArray(); // Contenu en mémoire au lieu de lib tierce
            }

            var fileName = $"Ordonnance_{ordonnanceId}.pdf";

            return File(pdfBytes, "application/pdf", fileName);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrdonnance()
        {
            var medicaments = await _context.Medicaments.ToListAsync();
            var patients = await _context.Patients.ToListAsync();
            var viewModel = new OrdonnanceViewModel
            {
                Patients = patients,
                Medicaments = medicaments
            };
            if (medicaments == null || !medicaments.Any())
            {
                Console.WriteLine("Aucun médicament disponible dans la base de données.");
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrdonnance(OrdonnanceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var patient = await _context.Patients.FindAsync(viewModel.PatientId);

                if (patient == null)
                {
                    ModelState.AddModelError("", "Le patient spécifié est introuvable.");
                    viewModel.Patients = await _context.Patients.ToListAsync();
                    return View(viewModel);
                }

                var ordonnanceExistante = await _context.Ordonnances
                    .FirstOrDefaultAsync(o => o.PatientId == viewModel.PatientId);

                if (ordonnanceExistante != null)
                {
                    ModelState.AddModelError("", "Ce patient a déjà une ordonnance.");
                    viewModel.Patients = await _context.Patients.ToListAsync();
                    return View(viewModel);
                }

                // Créer l'ordonnance
                var ordonnance = new Ordonnance
                {
                    PatientId = viewModel.PatientId,
                    Patologie = viewModel.Patologie,
                    DateDébut = viewModel.DateDébut,
                    DateFin = viewModel.DateFin,
                    MedecinId = viewModel.MedecinId,
                    Patient = patient
                };

                // Sélectionner les médicaments basés sur les IDs choisis
                var selectedMedicaments = await _context.Medicaments
                    .Where(m => viewModel.SelectedMedicaments.Contains(m.MedicamentId))
                    .ToListAsync();

                ordonnance.Medicaments = selectedMedicaments;

                // Enregistrer l'ordonnance
                _context.Ordonnances.Add(ordonnance);
                await _context.SaveChangesAsync();

                // Rediriger vers la vue de l'ordonnance
                return RedirectToAction("ShowOrdonnance", new { patientId = viewModel.PatientId });
            }

            // Si le modèle est invalide, renvoyer la vue avec les erreurs
            viewModel.Patients = await _context.Patients.ToListAsync();
            viewModel.Medicaments = await _context.Medicaments.ToListAsync();  // Assurez-vous de charger la liste des médicaments
            return View(viewModel);
        }

    }
}
