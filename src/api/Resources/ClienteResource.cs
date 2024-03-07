using api.Domain.Models;

namespace api.Resources
{
    public class ClienteResource
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public List<Logradouro> Logradouros { get; set; }
    }
}
