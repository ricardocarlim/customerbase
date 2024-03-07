using api.Domain.Models;
using api.Domain.Services.Communication;
using api.Models;
using api.Models.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api.Domain.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> Get([FromQuery] ClienteFilter filter);
        Task<ClienteResponse> SaveAsync(Cliente cliente);
        Task<ClienteResponse> UpdateAsync(int id, Cliente cliente);
        Task<ClienteResponse> DeleteAsync(int id);
    }
}
