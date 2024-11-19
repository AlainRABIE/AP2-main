using System;
using System.ComponentModel.DataAnnotations;

namespace ASPBookProject.Models;

public class Incompatibilite
{

    public int IncompatibiliteId { get; set; }
    public string? Interdiction { get; set; }

    public List<Medicament> Medicaments { get; set; } = new();
    public List<Patient> Patients { get; set; } = new();
}
