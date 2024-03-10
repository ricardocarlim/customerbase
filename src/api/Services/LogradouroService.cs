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
    public class LogradouroService : ILogradouroService
    {
        private readonly ILogradouroRepository _logradouroRepository;
        private readonly IUnitOfWork _unitOfWork;
        public LogradouroService(ILogradouroRepository logradouroRepository, IUnitOfWork unitOfWork)
        {
            _logradouroRepository = logradouroRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<LogradouroResponse> DeleteAsync(int id)
        {
            var logradouroExistente = await _logradouroRepository.FindByIdAsync(id);

            if (logradouroExistente == null)
                return new LogradouroResponse("Logradouro não encontrado.");

            try
            {
                await _logradouroRepository.Remove(logradouroExistente);
                await _unitOfWork.CompleteAsync();

                return new LogradouroResponse(logradouroExistente);
            }
            catch (Exception ex)
            {
                return new LogradouroResponse($"An error occurred when deleting the logradouro: {ex.Message}");
            }
        }

        public async Task<LogradouroResponse> SaveAsync(Logradouro logradouro)
        {
            try
            {
                await _logradouroRepository.AddAsync(logradouro);
                await _unitOfWork.CompleteAsync();

                return new LogradouroResponse(logradouro);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new LogradouroResponse($"An error occurred when saving the logradouro: {ex.Message}");
            }
        }

        public async Task<LogradouroResponse> UpdateAsync(int id, Logradouro logradouro)
        {
            var logradouroExistente = await _logradouroRepository.FindByIdAsync(id);

            if (logradouroExistente == null)
                return new LogradouroResponse("logradouro não encontrado.");

            logradouroExistente.Endereco = logradouro.Endereco;

            try
            {
                _logradouroRepository.Update(logradouroExistente);
                await _unitOfWork.CompleteAsync();

                return new LogradouroResponse(logradouroExistente);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new LogradouroResponse($"An error occurred when updating the logradouro: {ex.Message}");
            }
        }
    }
}
