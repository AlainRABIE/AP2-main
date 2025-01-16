using System;
using ASPBookProject.Models;

namespace ASPBookProject.ViewModels;

public class PatientAdd
{
    public class PatientEditViewModel
    {
        public Patient? Patient { get; set; }
        public List<Antecedent>? Antecedents { get; set; }

        public List<Antecedent>? Allergie { get; set; }

        public List<Incompatibilite> Incompatibilites { get; set; } = new();
        public List<int> SelectedAntecedentIds { get; set; } = new List<int>();
        public List<int> SelectedAllergieIds { get; set; } = new List<int>();

    }

}
