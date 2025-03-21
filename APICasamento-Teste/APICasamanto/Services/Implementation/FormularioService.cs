using APICasamanto.Data.Context;
using APICasamanto.Entities;
using APICasamanto.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APICasamanto.Services.Implementation
{
        public class FormularioService : IFormularioService
        {
            private readonly SQLServerContext _context;

            public FormularioService(SQLServerContext context)
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
