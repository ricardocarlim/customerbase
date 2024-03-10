using app.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace app.Pages.Clientes
{
    public class EditarModel : PageModel
    {
        private readonly IApiCliente _apiClient;

        public EditarModel(IApiCliente apiClient)
        {
            _apiClient = apiClient;
        }

        [BindProperty]
        public ClienteResource Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Cliente = await _apiClient.GetClienteAsync(id);
            if (Cliente == null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiClient.UpdateClienteAsync(Cliente.id, Cliente);

            return RedirectToPage("./Index");
        }
    }

}
