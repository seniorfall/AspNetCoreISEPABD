using Microsoft.EntityFrameworkCore;
using TestAuthentification.Data;
using TestAuthentification.Interface;
using TestAuthentification.Models;
using X.PagedList;

namespace TestAuthentification.Service
{
    public class ConsultationRepository : IGeneric<Consultation>, IConsultationRepository
    {
        private readonly ApplicationDbContext _context;
        public ConsultationRepository(ApplicationDbContext contex) {
            _context= contex;
        }
        public async Task<bool> Add(Consultation entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return true;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Consultation>> GetAllAsync()
        {
            return await _context.Consultation
                .Include(c => c.Medecin).Include(c => c.Patient)
            .Include(c => c.TypeConsultation).ToListAsync();
        }

        public async Task<Consultation> GetById(int id)
        {
            return await _context.Consultation
                .Include(c => c.Medecin).Include(c => c.Patient)
            .Include(c => c.TypeConsultation)
            .FirstOrDefaultAsync(t=>t.Id==id);
        }

        public async Task<IPagedList<Consultation>> GetConsultation(int page, int nombre)
        {
            return await _context.Consultation
                .Include(c => c.Medecin).Include(c => c.Patient)
            .Include(c => c.TypeConsultation)
            .ToPagedListAsync(page, nombre);
        }

        public async Task<IPagedList<Consultation>> GetConsultation(int page, int nombre, int medecinId)
        {
            return await _context.Consultation
               .Include(c => c.Medecin).Include(c => c.Patient)
           .Include(c => c.TypeConsultation).Where(c=>c.MedecinId==medecinId)
           .ToPagedListAsync(page, nombre);
        }

        public Task<List<Exam>> GetExamByConsultation(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Consultation entity)
        {
            throw new NotImplementedException();
        }
    }
}
