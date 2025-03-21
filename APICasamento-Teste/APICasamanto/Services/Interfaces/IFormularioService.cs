using APICasamanto.Entities;

namespace APICasamanto.Services.Interfaces
{
        public interface IFormularioService
        {
            Task AdicionarAsync(Formulario formulario);
            Task<IEnumerable<Formulario>> GetAllAsync();
        }
}
