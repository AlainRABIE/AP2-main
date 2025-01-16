using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASPBookProject.Models;
namespace ASPBookProject.ViewModels
{
    public class AntecedentEditViewModel
    {
        public string? Nom { get; set; }

        public Antecedent Antecedent { get; set; } = new Antecedent();
        public List<Medicament> Medicaments { get; set; } = new List<Medicament>();
        public List<int> SelectedMedicamentIds { get; set; } = new List<int>();

        public List<Patient> Patients { get; set; } = new List<Patient>();
        public List<int> SelectedPatientIds { get; set; } = new List<int>();
    }
}
