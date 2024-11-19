
namespace ASPBookProject.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public required int Age { get; set; }  
        public required string Prenom { get; set; }
        public required string Nom { get; set; } = string.Empty; 
        public List<Antecedent> Antecedents { get; set; } = new();
        public List<Incompatibilite> Incompatibilites { get; set; } = new();
        public Ordonnance? Ordonnance { get; set; }
        public List<Ordonnance> Ordonnances { get; set; } = new();

    }
}
