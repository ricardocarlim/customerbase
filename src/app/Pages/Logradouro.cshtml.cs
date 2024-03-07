using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace app.Pages
{
    public class LogradouroModel : PageModel
    {
        [BindProperty]
        public List<Logradouro> Logradouros { get; set; }
        public void OnGet()
        {
        }
    }
}
