using System.ComponentModel.DataAnnotations;

namespace GBEventos.Models
{
    public class EventosModels
    {
        public Guid Id { get; set; }
        public Guid UsuariosId { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }
        
        public DateTime Data { get; set; }
        public string Endereco { get; set; }
        public string LinkPersonalizado { get; set; }

        public UsuariosModels Usuarios { get; set; }
        //public ICollection<ConvidadosModels> Convidados { get; set; }
        //public ICollection<PresentesModels> Presentes { get; set; }
    }
}
