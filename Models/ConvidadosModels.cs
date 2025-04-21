namespace GBEventos.Models
{
    public class ConvidadosModels
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid EventoId { get; set; }

        public string Nome { get; set; } = string.Empty;
        public string? Email { get; set; }
        public bool Confirmado { get; set; } = false;

        public EventosModels Evento { get; set; } = default!;
    }
}
