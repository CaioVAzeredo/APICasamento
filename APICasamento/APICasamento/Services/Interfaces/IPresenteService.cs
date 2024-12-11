using APICasamento.Entities;

namespace APICasamento.Services.Interfaces;

public interface IPresenteService
{
    Task AdicionarAsync(Presente presente);
    Task AlterarAsync(Presente presente);
    Task ExcluirAsync(int id);
    Task<IEnumerable<Presente>> PesquisarPorId(int id);
    Task<IEnumerable<Presente>> GetAllAsync();
}
