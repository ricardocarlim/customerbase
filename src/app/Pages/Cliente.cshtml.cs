using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace app.Pages
{
    public class ClienteModel : PageModel
    {
        [BindProperty]
        public List<Cliente> Clientes { get; set; }

        public void OnGet()
        {
        }
    }
}
