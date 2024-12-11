using APICasamento.Entities;
using APICasamento.Services.Interfaces;
using APICasamento.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace APICasamento.Services.Implementation
{
    public class PresenteService : IPresenteService
    {


        private readonly MySQLContext _context;

        public PresenteService(MySQLContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Presente presente)
        {
            await _context.Presente.AddAsync(presente);
            await _context.SaveChangesAsync();
        }

        public async Task AlterarAsync(Presente presente)
        {
            _context.Presente.Update(presente);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var presente = await _context.Presente.FindAsync(id);
            if (presente != null)
            {
                _context.Presente.Remove(presente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Presente>> GetAllAsync()
        {
            return await _context.Presente.ToListAsync();
        }

        public async Task<IEnumerable<Presente>> PesquisarPorId(int id)
        {
            var presente = await _context.Presente.FindAsync(id);

        return presente != null ? new List<Presente> { presente } : new List<Presente>();

        }
    }
}

