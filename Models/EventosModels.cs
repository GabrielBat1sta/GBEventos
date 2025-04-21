using System.ComponentModel.DataAnnotations;

namespace GBEventos.Models
{
    public class EventosModels
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; }
        public string TipoEvento { get; set; } = string.Empty;
        public string FormatoEvento { get; set; } = string.Empty;
        public string NomeCelebrado { get; set; } = string.Empty;
        public DateTime? DataEvento { get; set; }
        public TimeSpan? HoraEvento { get; set; }
        public string? SexoCelebrado { get; set; }
        public int? IdadeCelebrado { get; set; }

        public UsuariosModels Usuarios { get; set; } = default!;
        public List<ConvidadosModels> Convidados { get; set; } = new();
        public List<PresentesModels> Presentes { get; set; } = new();

        
    }
}
