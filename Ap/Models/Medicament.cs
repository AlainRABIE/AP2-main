namespace ASPBookProject.Models;

public class Medicament
{
    public int MedicamentId { get; set; }
    public required string Allergie { get; set; }
    public required string Nom { get; set; }
    public string? Posologie { get; set; }
    public int NombreUtilisations { get; set; }

    public List<Antecedent> Antecedents { get; set; } = new();
    public List<Ordonnance> Ordonnances { get; set; } = new();
}
