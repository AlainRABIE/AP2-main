using ASPBookProject.Data;
using ASPBookProject.Models;
using Microsoft.AspNetCore.Mvc;
namespace ASPBookProject.Controllers
{
    public class MedecinController : Controller 
    {
       
        private readonly ApplicationDbContext _dbContext;

        public MedecinController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Medecins); 

        }


        public IActionResult DisplayAll()
        {
       
            return View("Index");
        }

        public IActionResult ShowAll()
        {
            return RedirectToAction("Index", _dbContext.Medecins);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Medecin Medecins)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _dbContext.Medecins.Add(Medecins);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            Medecin? medec = _dbContext.Medecins.FirstOrDefault<Medecin>(ins => ins.Id == id.ToString());

            if (medec != null)
            {
                return View(medec);
            }

            return NotFound();

        }

        [HttpPost]
        public IActionResult Edit(Medecin Medecins)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Medecin? medec = _dbContext.Medecins.FirstOrDefault<Medecin>(ins => ins.Id == Medecins.Id);

            if (medec != null)
            {
                medec.UserName = Medecins.UserName;
                medec.Identifiant = Medecins.Identifiant;
                medec.PasswordHash = Medecins.PasswordHash;
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Delete(int MedecinId)
        {
            Medecin? medec = _dbContext.Medecins.FirstOrDefault<Medecin>(ins => ins.Id == MedecinId.ToString());

            if (medec != null) 
            {
                return View(medec); 
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int MedecinId)

        {
            Medecin? medec = _dbContext.Medecins.FirstOrDefault<Medecin>(ins => ins.Id == MedecinId.ToString());


            if (medec != null) 
            {
                _dbContext.Medecins.Remove(medec); 
                _dbContext.SaveChanges(); 
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult ShowDetails(int MedecinId)
        {
            Medecin? medec = _dbContext.Medecins.FirstOrDefault<Medecin>(ins => ins.Id == MedecinId.ToString());
            if (medec != null)
            {
                return View(medec);
            }
            return NotFound();
        }
    }
}
