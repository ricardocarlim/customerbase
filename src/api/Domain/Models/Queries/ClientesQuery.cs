namespace api.Domain.Models.Queries
{
    public class ClientesQuery : Query
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public ClientesQuery(string? nome, string? email, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            Nome = nome;
            Email = email;
        }
    }   
}
