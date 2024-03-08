using api.Domain.Models;
using api.Domain.Services.Communication;
using api.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace api.Domain.Services
{
    public interface ILogradouroService
    {        
        Task<LogradouroResponse> SaveAsync(Logradouro logradouro);
        Task<LogradouroResponse> UpdateAsync(int id, Logradouro cliente);
        Task<LogradouroResponse> DeleteAsync(int id);
    }
}
