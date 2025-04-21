namespace GBEventos.Models
{
    public class PresentesModels
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid EventoId { get; set; }

        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public string? ReservadoPor { get; set; }

        public EventosModels Evento { get; set; } = default!;
    }
}
