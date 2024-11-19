namespace ASPBookProject.Models;

public class Ordonnance
{
    public int OrdonnanceId { get; set; }
    public required string Patologie { get; set; }
    public DateTime DateDébut { get; set; }
    public DateTime DateFin { get; set; }
    public string? MedecinId { get; set; }
    public Medecin? Medecin { get; set; }
    public int PatientId { get; set; }
    public required Patient Patient { get; set; }
    public List<Medicament> Medicaments { get; set; } = new();
    
    public List<Patient> patients { get; set; } = new();
}