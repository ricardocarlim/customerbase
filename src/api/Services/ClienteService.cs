using api.Domain.Models;
using api.Domain.Repositories;
using api.Domain.Services;
using api.Domain.Services.Communication;
using api.Models;
using api.Models.Filters;
using api.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api.Services
{    
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ClienteService(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {            
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
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

        public Task<IEnumerable<Cliente>> Get([FromQuery] ClienteFilter filter)
        {
            return _clienteRepository.Get(filter);
        }

        public async Task<ClienteResponse> SaveAsync(Cliente cliente)
        {
            try
            {
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

            clienteExistente.Nome = cliente.Nome;

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
    }
}
