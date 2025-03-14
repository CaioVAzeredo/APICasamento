using APICasamento.Entities;
using APICasamento.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APICasamento.Services.Implementation
{
    public class PresenteService : IPresenteService
    {


        private readonly SQLiteServerContext _context;

        public PresenteService(SQLiteServerContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Presente presente)
        {
            await _context.Presentes.AddAsync(presente);
            await _context.SaveChangesAsync();
        }

        public async Task AlterarAsync(Presente presente)
        {
            _context.Presentes.Update(presente);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var presente = await _context.Presentes.FindAsync(id);
            if (presente != null)
            {
                _context.Presentes.Remove(presente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Presente>> GetAllAsync()
        {
            return await _context.Presentes.ToListAsync();
        }

        public async Task<IEnumerable<Presente>> PesquisarPorId(int id)
        {
            var presente = await _context.Presentes.FindAsync(id);

            return presente != null ? new List<Presente> { presente } : new List<Presente>();

        }
    }
}

