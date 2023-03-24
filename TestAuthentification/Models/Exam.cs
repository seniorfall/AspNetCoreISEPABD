using System.ComponentModel.DataAnnotations.Schema;

namespace TestAuthentification.Models
{
    public class Exam
    {
        public int Id { get; set; }

        public string Result { get; set; }


        public DateTime? DateExam { get; set; }  
        public DateTime? DateResult { get; set; }

        [ForeignKey("Consultation")]
        public int ConsultationId { get; set; }

        public virtual Consultation? Consultation { get; set; }


    }
}
