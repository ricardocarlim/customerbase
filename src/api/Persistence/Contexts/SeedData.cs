using api.Domain.Models;

namespace api.Persistence.Contexts
{
    public static class SeedData
    {
        public static async Task Seed(AppDbContext context)
        {
            var cliente = new Cliente
            {
                Id = 1,
                Nome = "Pessoa Teste 01",
                Email = "pessoa01@teste.com",
                Logotipo = ""
            };

            var logradouros = new List<Logradouro>
            {
                new Logradouro { Id = 1, ClienteId = 1, Endereco = "Rua teste 01, 01" },
                new Logradouro { Id = 2, ClienteId = 1, Endereco = "Rua teste 02, 02" },
            };

            context.Clientes.AddRange(cliente);
            context.Logradouros.AddRange(logradouros);
            await context.SaveChangesAsync();
        }
    }
}
