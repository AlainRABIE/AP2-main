using System;

namespace ASPBookProject.Models;

public class Antecedent
{

    public int AntecedentId { get; set; }
    public string Nom { get; set; }

    public List<Medicament> Medicaments { get; set; } = new();
    public List<Patient> Patients { get; set; } = new();

    public Antecedent()
    {
        Nom = string.Empty; // Initialisation par défaut
    }
}