using api.Domain.Models;
using api.Domain.Services;
using api.Extensions;
using api.Models.Filters;
using api.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }
             
        [HttpGet("")]
        public async Task<IEnumerable<ClienteResource>> Get([FromQuery] ClienteFilter filter)
        {
            var clientes = await _clienteService.Get(filter);
            var resources = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteResource>>(clientes);
            return resources;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] SaveClienteResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var cliente = _mapper.Map<SaveClienteResource, Cliente>(resource);

            var result = await _clienteService.SaveAsync(cliente);

            if (!result.Success)
                return BadRequest(result.Message);

            var clienteResource = _mapper.Map<Cliente, ClienteResource>(result.Cliente);
            return Ok(clienteResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveClienteResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var cliente = _mapper.Map<SaveClienteResource, Cliente>(resource);
            var result = await _clienteService.UpdateAsync(id, cliente);

            if (!result.Success)
                return BadRequest(result.Message);

            var clienteResource = _mapper.Map<Cliente, ClienteResource>(result.Cliente);
            return Ok(clienteResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _clienteService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var clienteResource = _mapper.Map<Cliente, ClienteResource>(result.Cliente);
            return Ok(clienteResource);
        }

    }
}
