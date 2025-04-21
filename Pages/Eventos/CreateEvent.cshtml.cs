using GBEventos.Data;
using GBEventos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GBEventos.Pages.Eventos
{
    public class CreateEventModel : PageModel
    {
        public readonly ApplicationDbContext _context;

        [BindProperty]

        public EventosModels Eventos { get; set; }

        public CreateEventModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();


            Eventos.Id = Guid.NewGuid();
            
            try
            {
                _context.Eventos.Add(Eventos);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar: " + ex.Message);
                return Page();
            }

            return RedirectToPage("/Eventos/eventos");
        }

        public IActionResult OnPostAvancar()
        {
            // Guardar os dados do evento temporariamente com TempData
            TempData["TipoEvento"] = Eventos.TipoEvento;
            TempData["FormatoEvento"] = Eventos.FormatoEvento;
            TempData["NomeCelebrado"] = Eventos.NomeCelebrado;
            TempData["DataEvento"] = Eventos.DataEvento?.ToString("dd-MM-yyyy");
            TempData["HoraEvento"] = Eventos.HoraEvento?.ToString();
            TempData["SexoCelebrado"] = Eventos.SexoCelebrado;
            

            return RedirectToPage("/Account/CreateUser");
        }


    }
}
