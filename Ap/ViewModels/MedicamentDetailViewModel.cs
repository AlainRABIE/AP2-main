using System;
using ASPBookProject.Models;

namespace ASPBookProject.ViewModels 
{
    public class MedicamentViewModel 
    {
        public Medicament? Medicament { get; set; }

        public Medicament? Interdiction { get; set; }

        public List<Antecedent> Antecedents { get; set; } = new();
        public List<Ordonnance> Ordonnances { get; set; } = new();
    }
}
