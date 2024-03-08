using api.Domain.Models;
using api.Domain.Models.Queries;
using api.Domain.Services;
using api.Extensions;
using api.Models.Filters;
using api.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace api.Controllers
{
    [DisableRequestSizeLimit]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<ClienteResource>), 200)]
        public async Task<QueryResultResource<ClienteResource>> Get([FromQuery] ClientesQueryResource query)
        {
            var clientesQuery = _mapper.Map<ClientesQuery>(query);
            var queryResult = await _clienteService.ListAsync(clientesQuery);

            return _mapper.Map<QueryResultResource<ClienteResource>>(queryResult);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteResource), 200)]
        public async Task<ClienteResource> GetById(int id)
        {
            var result = await _clienteService.ListByIdAsync(id);
            return _mapper.Map<Cliente, ClienteResource>(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClienteResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
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
        [ProducesResponseType(typeof(ClienteResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
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
        [ProducesResponseType(typeof(ClienteResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
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
