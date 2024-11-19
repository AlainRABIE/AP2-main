using Microsoft.AspNetCore.Mvc;

namespace ASPBookProject.ViewModels
{
    public class AddMedicaments : Controller
    {
        public class Medicament
        {
            public int MedicamentId { get; set; }
            public required string Allergie { get; set; }
            public required string Nom { get; set; }
            public required string Posologie { get; set; }
        }
    }
}
