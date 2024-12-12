using APICasamento.Data.Context;
using APICasamento.Entities;
using APICasamento.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APICasamento.Services.Implementation
{
    public class FormularioService : IFormularioService
    {
        private readonly MySQLContext _context;

        public FormularioService(MySQLContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Formulario formulario)
        {
            await _context.Formulario.AddAsync(formulario);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Formulario>> GetAllAsync()
        {
            return await _context.Formulario.ToListAsync();
        }
    }
}
