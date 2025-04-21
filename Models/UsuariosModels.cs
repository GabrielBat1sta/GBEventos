namespace GBEventos.Models
{
    public class UsuariosModels
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public List<EventosModels> Eventos { get; set; } = new();

    }
}
