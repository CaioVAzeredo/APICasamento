using APICasamento.Entities;

namespace APICasamento.Services.Interfaces
{
    public interface IFormularioService
    {
        Task AdicionarAsync(Formulario formulario );
        Task<IEnumerable<Formulario>> GetAllAsync();
    }
}
