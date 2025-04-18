using System.Composition.Convention;
using GBEventos.Data;
using GBEventos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GBEventos.Pages.Account
{
    public class CreateUserModel : PageModel
    {
        public readonly ApplicationDbContext _context;

        [BindProperty]

        public UsuariosModels Usuarios { get; set; }

        public CreateUserModel(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            Usuarios.Id = Guid.NewGuid();
            
                _context.Usuarios.Add(Usuarios);
                _context.SaveChanges();

            return RedirectToPage("/Account/ListarUsuarios");
        }
    }
}
