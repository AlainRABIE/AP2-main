using System.Collections.Generic;
using ASPBookProject.Models;

namespace ASPBookProject.ViewModels
{
    public class ShowOrdonnanceViewModel
    {
        public int PatientId { get; set; }
        public List<Patient> Patients { get; set; } = new List<Patient>();
        public List<Ordonnance> Ordonnances { get; set; } = new List<Ordonnance>();
        public List<Medicament> Medicaments { get; set; } = new List<Medicament>();
    }
}
