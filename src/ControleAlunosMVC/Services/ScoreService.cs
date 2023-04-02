using ControleAlunosMVC.Data;
using ControleAlunosMVC.Models;
using ControleAlunosMVC.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ControleAlunosMVC.Services
{
    public class ScoreService
    {
        private readonly ControleAlunosMVCContext _context;

        public ScoreService(ControleAlunosMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Score>> FindAllAsync()
        {
            return await _context.Score.Include(x => x.Student).Include(x => x.Subject).ToListAsync();
        }

        public async Task InsertAsync(Score score)
        {
            _context.Add(score);
            await _context.SaveChangesAsync();
        }

        public async Task<Score> FindByIdAsync(int id)
        {
            return await _context.Score.Include(x => x.Student).Include(x => x.Subject).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var score = await _context.Score.FindAsync(id);
                _context.Score.Remove(score);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new NotFiniteNumberException("Nota não encontrada");
            }
        }

        public async Task UpdateAsync(Score score)
        {
            bool hasAny = await _context.Score.AnyAsync(x => x.Id == score.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Nota não encontrada");
            }
            try
            {
                _context.Update(score);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }


    }
}
