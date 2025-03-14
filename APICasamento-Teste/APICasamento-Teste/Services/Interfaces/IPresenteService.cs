using APICasamento.Entities;

namespace APICasamento.Services.Interfaces;

public interface IPresenteService
{
    Task AdicionarAsync(Presente presentes);
    Task AlterarAsync(Presente presentes);
    Task ExcluirAsync(int id);
    Task<IEnumerable<Presente>> PesquisarPorId(int id);
    Task<IEnumerable<Presente>> GetAllAsync();
}
