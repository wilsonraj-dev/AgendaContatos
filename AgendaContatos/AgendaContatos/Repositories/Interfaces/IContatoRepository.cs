using AgendaContatos.Entities;

namespace AgendaContatos.Repositories.Interfaces
{
    public interface IContatoRepository
    {
        Task<IEnumerable<Contato>> GetAll();
        Task<Contato> GetContatoPeloId(int id);
        Task<IEnumerable<Contato>> GetContatosPeloNome(string nome);
        Task<IEnumerable<Contato>> GetContatosFavoritos();
        Task AddAsync(Contato contato);
        Task UpdateAsync(Contato contato);
        Task RemoveAsync(int? id);
    }
}
