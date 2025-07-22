using HomeAutomation.Application.DTOs;
using HomeAutomation.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HomeAutomation.API.Controllers
{
    [ApiController]
    [Route("api/dispositivos")]
    public class DispisitivoController : ControllerBase
    {
        private readonly IDispositivoService? _service;

        public DispisitivoController(IDispositivoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<DispositivoResponseDto>> ListarTodos()
        {
            var response = await _service.ListarTodos();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DispositivoResponseDto>> ObterPorId(int id)
        {
            var response = await _service.ObterPorId(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<DispositivoResponseDto>> Adicionar([FromBody] DispositivoRequestDto request)
        {
            var dispositivoCriado = await _service.Adicionar(request);
            return StatusCode(201, dispositivoCriado);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<DispositivoResponseDto>> Atualizar(int id, [FromBody] DispositivoRequestDto request)
        {
            var atualizado = await _service.Atualizar(id, request);
            return Ok(atualizado);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Remover(int id)
        {
            var removido = await _service.Remover(id);
            return Ok(removido);
        }
    }
}

