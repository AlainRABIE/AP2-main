using System;
using System.Collections.Generic;

namespace ASPBookProject.Models
{
    public class OrdonnanceViewModel
    {
        public int OrdonnanceId { get; set; }
        public int PatientId { get; set; }
        public string? Patologie { get; set; }
        public DateTime DateDébut { get; set; }
        public DateTime DateFin { get; set; }
        public List<Medicament> Medicaments { get; set; } = new List<Medicament>();
        public List<Patient> Patients { get; set; } = new List<Patient>();
        public string? MedecinId { get; set; }
    }
}
