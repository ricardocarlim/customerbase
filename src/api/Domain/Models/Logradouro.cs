namespace api.Domain.Models
{
    public class Logradouro
    {
        public int Id { get; set; }
        public virtual Cliente? Cliente { get; set; }
        public int ClienteId { get; set; }
        public string Endereco { get; set; }        
    }
}
