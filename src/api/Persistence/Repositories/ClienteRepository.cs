using api.Domain.Models;
using api.Domain.Models.Queries;
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
            return await _context.Clientes
                            .Include(p => p.Logradouros)
                            .Where(p => p.Id == id)
                            .FirstOrDefaultAsync();
                            
        }     

        public async Task<QueryResult<Cliente>> ListAsync(ClientesQuery query)
        {
            IQueryable<Cliente> queryable = _context.Clientes
                                                   .Include(p => p.Logradouros)
                                                   .AsNoTracking();            
            if (!string.IsNullOrEmpty(query.Email))
            {
                queryable = queryable.Where(p => p.Email == query.Email);
            }
            
            int totalItems = await queryable.CountAsync();
            
            List<Cliente> clientes = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                    .Take(query.ItemsPerPage)
                                                    .ToListAsync();            
            return new QueryResult<Cliente>
            {
                Items = clientes,
                TotalItems = totalItems,
            };
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
