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

    }
}
