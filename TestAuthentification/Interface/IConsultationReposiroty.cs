using TestAuthentification.Models;
using X.PagedList;

namespace TestAuthentification.Interface
{
    public interface IConsultationRepository
    {
        Task<List<Exam>> GetExamByConsultation(int id);
        Task<IPagedList<Consultation>> GetConsultation(int page, int nombre);
        Task<IPagedList<Consultation>> GetConsultation(int page, int nombre,int medecinId);
    }
}
