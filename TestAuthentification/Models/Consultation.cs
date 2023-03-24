
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAuthentification.Models
{
    public class Consultation
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Motif consultation")]
        public string Motif { get; set; }
        [Required]
        [DisplayName("Les remarques du medecin")]
        [DataType(DataType.MultilineText)]
        public string Remarques { get; set; }

        [ForeignKey("Patient")]
        [DisplayName("Le patient")]
        public int PatientId { get; set; }

        public virtual Patient? Patient { get; set; }

        [ForeignKey("Medecin")]
        [DisplayName("Le medecin")]
        public int MedecinId { get; set; }
        public virtual Medecin? Medecin { get; set; }

        [Column("date_consultation")]
        [DisplayFormat(DataFormatString ="{0:dd MMM yyyy}")]
        public DateTime? DateConsultation { get; set; }


        [ForeignKey("TypeConsultation")]
        [DisplayName("Type de consultation")]
        public int TypeConsultationId { get; set; }
        public virtual TypeConsultation? TypeConsultation { get; set; }

        [DisplayName("Date RV")]
        public DateTime? ProchainConsultation { get; set; }
    }
}
