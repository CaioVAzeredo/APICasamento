using APICasamento_Teste.Entities;

namespace APICasamento_Teste.Services.Interfaces
{
    public interface IFormularioService
    {
        Task AdicionarAsync(Formulario formulario);
        Task<IEnumerable<Formulario>> GetAllAsync();
    }
}
