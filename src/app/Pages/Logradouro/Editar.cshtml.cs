using app.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace app.Pages.Logradouro
{
    public class EditarModel : PageModel
    {
        private readonly IApiLogradouro _apiLogradouro;
        public EditarModel(IApiLogradouro apiLogradouro)
        {
            _apiLogradouro = apiLogradouro;
        }

        [BindProperty]
        public LogradouroResource Logradouro{ get; set; }
        public async Task<IActionResult> OnGetAsync([FromQuery]int? id, string? endereco, int idCliente)
        {
            Logradouro = new LogradouroResource();
            Logradouro.id = id.Value;                                  
            Logradouro.endereco = endereco;
            Logradouro.idCliente = idCliente;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Logradouro.id == null || Logradouro.id <= 0)
            {
                await _apiLogradouro.CreateLogradouroAsync(Logradouro);
            }

            return RedirectToPage("Cliente/Editar/"+Logradouro.idCliente);
        }
    }
}
