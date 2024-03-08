using api.Domain.Models;
using api.Models;
using api.Models.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api.Domain.Repositories
{
    public interface ILogradouroRepository
    {
        Task AddAsync(Logradouro cliente);
        Task<Logradouro> FindByIdAsync(int id);
        void Update(Logradouro cliente);
        void Remove(Logradouro cliente);
    }
}
