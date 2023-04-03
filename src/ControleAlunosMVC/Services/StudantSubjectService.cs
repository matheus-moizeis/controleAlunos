using ControleAlunosMVC.Data;
using ControleAlunosMVC.Models;
using ControleAlunosMVC.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ControleAlunosMVC.Services
{
    public class StudantSubjectService
    {
        private readonly ControleAlunosMVCContext _context;

        public StudantSubjectService(ControleAlunosMVCContext context)
        {
            _context = context;
        }

        public async Task<List<StudentSubject>> FindAllAsync()
        {
            return await _context.StudentSubject.Include(x => x.Student).Include(x => x.Subject).ToListAsync();
        }

        public async Task InsertAsync(StudentSubject obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<StudentSubject> FindByKeyAsync(int studentId, int subjectId)
        {
            return await _context.StudentSubject.Include(x => x.Student).Include(x => x.Subject).FirstOrDefaultAsync(obj => obj.SubjectId == subjectId && obj.StudentId == studentId);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.StudentSubject.FindAsync(id);
                _context.StudentSubject.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new NotFiniteNumberException("Matricula não encontrada");
            }
        }

        public async Task UpdateAsync(StudentSubject obj)
        {
            bool hasAny = await _context.StudentSubject.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Nota não encontrada");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
