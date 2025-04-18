namespace GBEventos.Models
{
    public class PresentesModels
    {
        public Guid Id { get; set; }
        public Guid EventosId { get; set; }
        public string NomePresente { get; set; }
        public string Descricao { get; set; }
        public string ReservadoPor { get; set; }

        public EventosModels Eventos { get; set; }
    }
}
