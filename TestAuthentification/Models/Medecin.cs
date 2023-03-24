using System.ComponentModel.DataAnnotations.Schema;

namespace TestAuthentification.Models
{
    public class Medecin
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }

        [NotMapped]
        public string DisplayName { get => Prenom + " " + Nom; }

        public virtual List<Consultation>? Consultations { get; set; }
    }

    public class Patient
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }

        public virtual List<Consultation>? Consultations { get; set; }

        public string Profession { get; set; }
        [NotMapped]
        public string DisplayName { get => Prenom + " " + Nom; }
    }
}
