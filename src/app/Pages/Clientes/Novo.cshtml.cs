using app.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace app.Pages.Clientes
{
    public class NovoModel : PageModel
    {
        private readonly ApiCliente _apiClient;

        public NovoModel(ApiCliente apiClient)
        {
            _apiClient = apiClient;
        }

        [BindProperty]
        public ClienteResource Cliente { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiClient.CreateClienteAsync(Cliente);

            return RedirectToPage("./Index");
        }
    }
}
