using GBEventos.Data;
using GBEventos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GBEventos.Pages
{
    public class EventoDetalheModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EventoDetalheModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public EventosModels Eventos { get; set; }
        public UsuariosModels Usuarios { get; set; }

        public IActionResult OnGet(string slug, bool? @new)
        {
            // Ex: slug = "teste12-2025"
            if (string.IsNullOrEmpty(slug))
                return RedirectToPage("/Index");

            var partes = slug.Split('-');
            if (partes.Length != 2 || !int.TryParse(partes[1], out int ano))
                return RedirectToPage("/Index");

            string nomeCelebrado = partes[0].Replace("-", " ").ToLower();

            Eventos = _context.Eventos.FirstOrDefault(e =>
                e.NomeCelebrado.ToLower().Replace(" ", "") == nomeCelebrado &&
                e.DataEvento.Value.Year == ano);

            if (Eventos == null)
                return RedirectToPage("/Index");

            Usuarios = _context.Usuarios.FirstOrDefault(u => u.Id == Eventos.UsuarioId);

            return Page();
        }
    }
}
