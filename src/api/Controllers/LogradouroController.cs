using api.Domain.Models;
using api.Domain.Services;
using api.Extensions;
using api.Resources;
using api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [DisableRequestSizeLimit]
    [Route("api/[controller]")]
    public class LogradouroController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogradouroService _logradouroService;

        public LogradouroController(IMapper mapper, ILogradouroService logradouroService)
        {
            _mapper = mapper;
            _logradouroService = logradouroService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClienteResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> Post([FromBody] SaveLogradouroResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var Logradouro = _mapper.Map<SaveLogradouroResource, Logradouro>(resource);

            var result = await _logradouroService.SaveAsync(Logradouro);

            if (!result.Success)
                return BadRequest(result.Message);

            var LogradouroResource = _mapper.Map<Logradouro, LogradouroResource>(result.Logradouro);
            return Ok(LogradouroResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ClienteResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveLogradouroResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var Logradouro = _mapper.Map<SaveLogradouroResource, Logradouro>(resource);
            var result = await _logradouroService.UpdateAsync(id, Logradouro);

            if (!result.Success)
                return BadRequest(result.Message);

            var LogradouroResource = _mapper.Map<Logradouro, LogradouroResource>(result.Logradouro);
            return Ok(LogradouroResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ClienteResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _logradouroService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var LogradouroResource = _mapper.Map<Logradouro, LogradouroResource>(result.Logradouro);
            return Ok(LogradouroResource);
        }
    }
}
