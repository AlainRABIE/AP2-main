using System;
using ASPBookProject.Models;

namespace ASPBookProject.ViewModels;

public class PatientDetail
{
public class PatientEditViewModel
{
    public Patient? Patient { get; set; }
    public List<Antecedent>? Antecedents { get; set; }
    
    public List<Incompatibilite>? Incompatibilite { get; set; }
    public List<int> SelectedAntecedentIds { get; set; } = new List<int>();
    public List<int> SelectedAllergieIds { get; set; } = new List<int>();
}
}
