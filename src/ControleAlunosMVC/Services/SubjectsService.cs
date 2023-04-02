using ControleAlunosMVC.Data;
using ControleAlunosMVC.Models;
using ControleAlunosMVC.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ControleAlunosMVC.Services
{
    public class SubjectsService
    {
        private readonly ControleAlunosMVCContext _context;

        public SubjectsService(ControleAlunosMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> FindAllAsync()
        {
            return await _context.Subject.ToListAsync();
        }

        public async Task InsertAsync(Subject subject)
        {
            _context.Add(subject);
            await _context.SaveChangesAsync();
        }

        public async Task<Subject> FindByIdAsync(int id)
        {
            return await _context.Subject.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var subject = await _context.Subject.FindAsync(id);
            _context.Subject.Remove(subject);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Subject subject)
        {
            bool hasAny = await _context.Subject.AnyAsync(x => x.Id == subject.Id);

            if (!hasAny)
            {
                throw new NotFiniteNumberException("Disciplina não encontrada");
            }

            try
            {
                _context.Update(subject);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
