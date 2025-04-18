using GBEventos.Data;
using GBEventos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GBEventos.Pages.Eventos
{
    public class EventosModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<EventosModels> Eventos { get; set; }

        public EventosModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Eventos = _context.Eventos.ToList();
        }
        
    }
}
