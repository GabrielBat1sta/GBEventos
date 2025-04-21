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
            Console.WriteLine("entrei no post");
            if (!ModelState.IsValid)
                return Page();


            Eventos.Id = Guid.NewGuid();
            Eventos.UsuariosId = Guid.Parse("80D4D8E4-A373-43CF-92FB-7555E4A5C386");
            try
            {
                _context.Eventos.Add(Eventos);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar: " + ex.Message);
                // ou TempData["msg"] = "Erro ao salvar no banco: " + ex.Message;
                return Page();
            }

            return RedirectToPage("/Eventos/eventos");
        }
    }
}
