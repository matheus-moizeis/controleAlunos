using ControleAlunosMVC.Data;
using ControleAlunosMVC.Models;
using ControleAlunosMVC.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ControleAlunosMVC.Services
{
    public class StudentService
    {
        private readonly ControleAlunosMVCContext _context;

        public StudentService(ControleAlunosMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> FindAllAsync()
        {
            return await _context.Student.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(Student student)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task<Student> FindByIdAsync(int id)
        {
            return await _context.Student.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            bool hasAny = await _context.Student.AnyAsync(x => x.Id == student.Id);

            if (!hasAny)
            {
                throw new NotFiniteNumberException("Aluno não encontrado");
            }

            try
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
