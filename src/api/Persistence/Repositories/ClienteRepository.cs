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
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
        }

        public async Task<Cliente> FindByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> Get([FromQuery] ClienteFilter filter)
        {
            return await _context.Clientes.ToListAsync();
        }

        public void Remove(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
        }

        public void Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
        }
    }
}
