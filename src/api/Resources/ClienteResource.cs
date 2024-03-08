using api.Domain.Models;

namespace api.Resources
{
    public class ClienteResource
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Logotipo {  get; set; }
        public List<LogradouroResource> Logradouros { get; set; }
    }
}
