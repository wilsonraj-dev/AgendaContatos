using AgendaContatos.Context;
using AgendaContatos.Entities;
using AgendaContatos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendaContatos.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AppDbContext _context;

        public ContatoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contato>> GetAll()
        {
            return await _context.Contatos.AsNoTracking().ToListAsync();
        }

        public async Task<Contato> GetContatoPeloId(int id)
        {
            return await _context.Contatos.FindAsync(id) ?? throw new ArgumentException();
        }

        public async Task<IEnumerable<Contato>> GetContatosFavoritos()
        {
            return await _context.Contatos.AsNoTracking().Where(x => x.Favorito == 'Y').ToListAsync();
        }

        public async Task<IEnumerable<Contato>> GetContatosPeloNome(string nome)
        {
            return await _context.Contatos.AsNoTracking().Where(x => x.Nome.Contains(nome)).ToListAsync();
        }

        public async Task AddAsync(Contato contato)
        {
            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contato contato)
        {
            _context.Contatos.Update(contato);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int? id)
        {
            _context.Contatos.Remove(await _context.Contatos.FindAsync(id) ?? throw new ArgumentException());
            await _context.SaveChangesAsync();
        }
    }
}
