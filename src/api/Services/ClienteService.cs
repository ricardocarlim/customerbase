using api.Domain.Models;
using api.Domain.Models.Queries;
using api.Domain.Repositories;
using api.Domain.Services;
using api.Domain.Services.Communication;
using api.Infraestructure;
using api.Models;
using api.Models.Filters;
using api.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace api.Services
{    
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ClienteService> _logger;
        public ClienteService(
            IClienteRepository clienteRepository, 
            IUnitOfWork unitOfWork, 
            IMemoryCache cache, 
            ILogger<ClienteService> logger)
        {            
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logger = logger;
        }

        public async Task<ClienteResponse> DeleteAsync(int id)
        {
            var clienteExistente = await _clienteRepository.FindByIdAsync(id);

            if (clienteExistente == null)
                return new ClienteResponse("Cliente não encontrado.");

            try
            {
                _clienteRepository.Remove(clienteExistente);
                await _unitOfWork.CompleteAsync();

                return new ClienteResponse(clienteExistente);
            }
            catch (Exception ex)
            {
                return new ClienteResponse($"An error occurred when deleting the cliente: {ex.Message}");
            }
        }
       
        public async Task<QueryResult<Cliente>> ListAsync(ClientesQuery query)
        {
            string cacheKey = GetCacheKeyForClientesQuery(query);

            var clientes = await _cache.GetOrCreateAsync(cacheKey, (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _clienteRepository.ListAsync(query);
            });

            return clientes!;
        }

        private static string GetCacheKeyForClientesQuery(ClientesQuery query)
            => $"{CacheKeys.ClientesList}_{query.Nome}_{query.Page}_{query.ItemsPerPage}";

        public async Task<ClienteResponse> SaveAsync(Cliente cliente)
        {
            try
            {
                var clienteExistente = await _clienteRepository.FindByEmailAsync(cliente.Email);

                if (clienteExistente != null)
                    return new ClienteResponse($"Já existe um cliente com o e-mail informado. Por favor altere o e-mail.");

                await _clienteRepository.AddAsync(cliente);
                await _unitOfWork.CompleteAsync();

                return new ClienteResponse(cliente);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ClienteResponse($"An error occurred when saving the cliente: {ex.Message}");
            }
        }

        public async Task<ClienteResponse> UpdateAsync(int id, Cliente cliente)
        {
            var clienteExistente = await _clienteRepository.FindByIdAsync(id);

            if (clienteExistente == null)
                return new ClienteResponse("Cliente não encontrado.");

            var clienteemail = await _clienteRepository.FindByEmailAsync(cliente.Email);

            if (clienteemail != null && id != clienteemail.Id)
                return new ClienteResponse($"Já existe um cliente com o e-mail informado. Por favor altere o e-mail.");

            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Email = cliente.Email;
            clienteExistente.Logotipo = cliente.Logotipo;

            try
            {
                _clienteRepository.Update(clienteExistente);
                await _unitOfWork.CompleteAsync();

                return new ClienteResponse(clienteExistente);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ClienteResponse($"An error occurred when updating the Cliente: {ex.Message}");
            }
        }

        public Task<Cliente> ListByIdAsync(int Id)
        {
            return _clienteRepository.FindByIdAsync(Id);            
        }
    }
}
