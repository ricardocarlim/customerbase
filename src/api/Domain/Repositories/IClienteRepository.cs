using api.Domain.Models;
using api.Domain.Models.Queries;
using api.Models;
using api.Models.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<QueryResult<Cliente>> ListAsync(ClientesQuery query);
        Task AddAsync(Cliente cliente);
        Task<Cliente> FindByIdAsync(int id);
        void Update(Cliente cliente);
        void Remove(Cliente cliente);
    }
}
