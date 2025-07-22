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
        public async Task<ActionResult<DispositivoResponse>> ListarTodos()
        {
            var response = await _service.ListarTodos();
            return Ok(response);
        }
    }
}

