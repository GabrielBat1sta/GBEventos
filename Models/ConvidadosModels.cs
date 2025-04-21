namespace GBEventos.Models
{
    public class ConvidadosModels
    {
        public Guid Id { get; set; }
        public Guid EventosId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Confirmado { get; set; }
        public EventosModels Eventos { get; set; }
    }
}
