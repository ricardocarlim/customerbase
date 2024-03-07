namespace api.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Logotipo { get; set; }
        public List<Logradouro> Logradouros { get; set; }

    }
}
