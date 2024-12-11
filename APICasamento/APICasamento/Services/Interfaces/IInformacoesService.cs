using APICasamento.Entities;

namespace APICasamento.Services.Interfaces
{
    public interface IInformacoesService
    {
        Task AdicionarAsync(Informacoes informacoes);
        Task AlterarAsync(Informacoes informacoes);
        Task ExcluirAsync(int id);
        Task<IEnumerable<Informacoes>> GetAllAsync();
    }
}
