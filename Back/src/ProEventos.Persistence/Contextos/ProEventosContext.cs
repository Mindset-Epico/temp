using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

using ProEventos.Domain.Biblioteca;

namespace ProEventos.Persistence.Contextos
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) 
            : base(options) { }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }


        public DbSet<Acervo> Acervos { get; set; }
        public DbSet<Patrimonio> Patrimonios { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId});

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Emprestimo>()
                .HasKey(E => new {E.PatrimonioId, E.UsuarioId});
        }
    }
}