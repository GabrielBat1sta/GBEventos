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

        public void OnGet()
        {
            TempData.Keep();
        }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();


            // Verifica se o usuário já existe
            var usuarioExistente = _context.Usuarios
                .FirstOrDefault(u => u.Email == Usuarios.Email);

            if (usuarioExistente != null)
            {
                // Se o usuário já existe, redireciona para a página de login
                ModelState.AddModelError(string.Empty, "Usuário já existe.");
                return Page();

            }
            else
            {
                // 1. Salvar o usuário no banco
                Usuarios.Id = Guid.NewGuid();
                _context.Usuarios.Add(Usuarios);
                _context.SaveChanges();

                // 2. Recuperar os dados do evento do TempData
                var tipo = TempData["TipoEvento"] as string;
                var formato = TempData["FormatoEvento"] as string;
                var nomeCelebrado = TempData["NomeCelebrado"] as string;
                var dataStr = TempData["DataEvento"] as string;
                var horaStr = TempData["HoraEvento"] as string;
                var sexo = TempData["SexoCelebrado"] as string;

                // Validando se alguma informacao não está nula ou vazia
                if (string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(formato) ||
                    string.IsNullOrEmpty(nomeCelebrado) || string.IsNullOrEmpty(dataStr) ||
                    string.IsNullOrEmpty(horaStr))
                {
                    // Algo deu errado: redireciona para criar evento novamente
                    return RedirectToPage("/Eventos/CreateEvent");
                }

                // 3. Criar o evento com base nos dados temporários
                DateTime.TryParse(dataStr, out var dataEvento);
                TimeSpan.TryParse(horaStr, out var horaEvento);

                var novoEvento = new EventosModels
                {
                    Id = Guid.NewGuid(),
                    UsuarioId = Usuarios.Id,
                    TipoEvento = tipo,
                    FormatoEvento = formato,
                    NomeCelebrado = nomeCelebrado,
                    DataEvento = dataEvento,
                    HoraEvento = horaEvento,
                    SexoCelebrado = sexo
                };

                _context.Eventos.Add(novoEvento);
                _context.SaveChanges();

                // 4. Criar o slug com nomeCelebrado + ano
                var slugNome = GerarSlug(nomeCelebrado);
                var ano = dataEvento.Year;

                // 5. Redirecionar para a rota personalizada
                return Redirect($"/{slugNome}-{ano}?new=1");
            }
        }

        private string GerarSlug(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return "";

            // Remove acentos e caracteres especiais
            var normalized = texto.Normalize(System.Text.NormalizationForm.FormD);
            var slug = new string(normalized
                .Where(c => char.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                .ToArray());

            // Transforma em minúsculas, tira espaços e caracteres não alfanuméricos
            slug = slug.ToLowerInvariant();
            slug = System.Text.RegularExpressions.Regex.Replace(slug, @"[^a-z0-9]", "");

            return slug;
        }
    }
}
