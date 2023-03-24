namespace TestAuthentification.Models
{
    public class TypeConsultation
    {
        public int Id { get; set; }

        public string Nom { get; set; }
        public string Description { get; set; }

        public virtual List<Consultation>? Consultations { get; set; }  
    }


}
