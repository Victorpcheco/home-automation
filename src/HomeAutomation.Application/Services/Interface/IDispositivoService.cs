using HomeAutomation.Application.DTOs;

namespace HomeAutomation.Application.Services.Interface
{
    public interface IDispositivoService
    {
        Task<IReadOnlyList<DispositivoResponseDto>> ListarTodos();
        Task<DispositivoResponseDto> ObterPorId(int id);
        Task<DispositivoResponseDto> Adicionar(DispositivoRequestDto request);
        Task<DispositivoResponseDto> Atualizar(int id, DispositivoRequestDto request);
        Task<bool> Remover(int id);
    }
}
