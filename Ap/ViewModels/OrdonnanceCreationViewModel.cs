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
        public List<int> SelectedMedicaments { get; set; } = new List<int>();

        public string? MedecinId { get; set; }
    }
}
