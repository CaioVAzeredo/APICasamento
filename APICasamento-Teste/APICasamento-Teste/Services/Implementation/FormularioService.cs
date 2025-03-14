using APICasamento_Teste.Entities;
using APICasamento_Teste.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APICasamento_Teste.Services.Implementation
{
    public class FormularioService : IFormularioService
    {
        private readonly SQLiteServerContext _context;

        public FormularioService(SQLiteServerContext context)
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
