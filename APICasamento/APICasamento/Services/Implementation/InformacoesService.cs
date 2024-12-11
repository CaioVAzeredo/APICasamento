using APICasamento.Data.Context;
using APICasamento.Entities;
using APICasamento.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace APICasamento.Services.Implementation
{
    public class InformacoesService : IInformacoesService
    {
        private readonly MySQLContext _context;

        public InformacoesService(MySQLContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Informacoes informacoes)
        {
            await _context.Informacoes.AddAsync(informacoes);
            await _context.SaveChangesAsync();
        }

        public async Task AlterarAsync(Informacoes informacoes)
        {
            _context.Informacoes.Update(informacoes);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var informacao = await _context.Informacoes.FindAsync(id);
            if (informacao != null)
            {
                _context.Informacoes.Remove(informacao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Informacoes>> GetAllAsync()
        {
            return await _context.Informacoes.ToListAsync();
        }
    }
}
