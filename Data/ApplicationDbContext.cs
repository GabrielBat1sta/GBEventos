using Microsoft.EntityFrameworkCore;
using GBEventos.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GBEventos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UsuariosModels> Usuarios { get; set; }
        public DbSet<EventosModels> Eventos { get; set; }
        public DbSet<ConvidadosModels> Convidados { get; set; }
        public DbSet<PresentesModels> Presentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuariosModels>()
                .HasMany(u => u.Eventos)
                .WithOne(e => e.Usuarios)
                .HasForeignKey(e => e.UsuarioId);

            modelBuilder.Entity<EventosModels>()
                .HasMany(e => e.Convidados)
                .WithOne(c => c.Evento)
                .HasForeignKey(c => c.EventoId);

            modelBuilder.Entity<EventosModels>()
                .HasMany(e => e.Presentes)
                .WithOne(p => p.Evento)
                .HasForeignKey(p => p.EventoId);
        }

    }
}
