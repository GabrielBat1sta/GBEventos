using GBEventos.Data;
using GBEventos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GBEventos.Pages.Account
{
    public class LoginModel : PageModel
    {
        public readonly ApplicationDbContext _context;

        [BindProperty]
        public UsuariosModels? Usuarios { get; set; }

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            // Removed invalid code causing CS1002 and CS0103
        }

        public IActionResult OnPost(UsuariosModels usuario)
        {
            if (ModelState.IsValid)
            {

                var usuarioEncontrado = _context.Usuarios
                    .FirstOrDefault(u => u.Email == Usuarios.Email && u.SenhaHash == Usuarios.SenhaHash);


                if (usuarioEncontrado != null)
                {
                    // Login bem-sucedido, sera redirecionado para a página de eventos do usuario
                    return RedirectToPage("/Eventos/Eventos");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email ou senha inválidos.");
                }
            }
            return Page();
        }
    }
}
