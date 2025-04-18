using System;
using GBEventos.Data;
using GBEventos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GBEventos.Pages.Account
{
    public class ListarUsuariosModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<UsuariosModels> Usuarios { get; set; }

        public ListarUsuariosModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            // Carregar os usuários do banco de dados
            Usuarios = _context.Usuarios.ToList();
        }
    }
}
