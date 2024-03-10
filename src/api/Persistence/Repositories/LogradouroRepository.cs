using api.Domain.Models;
using api.Domain.Repositories;
using api.Models;
using api.Models.Filters;
using api.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace api.Persistence.Repositories
{
    public class LogradouroRepository : BaseRepository, ILogradouroRepository
    {
        public LogradouroRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Logradouro logradouro)
        {
            await _context.Logradouros.AddAsync(logradouro);
        }

        public async Task<Logradouro> FindByIdAsync(int id)
        {
            return await _context.Logradouros.FindAsync(id);
        }      

        public async Task Remove(Logradouro logradouro)
        {
            _context.Logradouros.Remove(logradouro);
        }

        public async Task Update(Logradouro logradouro)
        {
            _context.Logradouros.Update(logradouro);
        }
    }
}
