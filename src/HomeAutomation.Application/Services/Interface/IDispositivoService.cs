using HomeAutomation.Application.DTOs;

namespace HomeAutomation.Application.Services.Interface
{
    public interface IDispositivoService
    {
        Task<IReadOnlyList<DispositivoResponse>> ListarTodos();
        Task<DispositivoResponse> ObterPorId(int id);
    }
}
