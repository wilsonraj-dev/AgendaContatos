using AgendaContatos.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaContatos.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> op) : base(op) { }

        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            builder.Entity<Contato>().HasKey(x => x.Id);
            builder.Entity<Contato>().Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Entity<Contato>().Property(x => x.Sobrenome).HasMaxLength(100);
            builder.Entity<Contato>().Property(x => x.Celular).IsRequired();
            builder.Entity<Contato>().Property(x => x.Favorito).HasMaxLength(1).IsRequired();
        }
    }
}
