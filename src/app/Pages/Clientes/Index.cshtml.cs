using app.Resources;
using app.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace app.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly ApiCliente _apiClient;

        public IndexModel(ApiCliente apiClient)
        {
            _apiClient = apiClient;
        }

        public QueryResultResource<ClienteResource> Clientes { get; set; }

        public async Task OnGetAsync()
        {
            Clientes = await _apiClient.GetClientesAsync();
        }
    }
}
