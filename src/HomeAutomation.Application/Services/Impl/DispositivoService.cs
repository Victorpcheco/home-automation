using HomeAutomation.Application.DTOs;
using HomeAutomation.Application.Services.Interface;
using HomeAutomation.Domain.Entidades;
using HomeAutomation.Domain.Interfaces;

namespace HomeAutomation.Application.Services.Impl
{
    public class DispositivoService : IDispositivoService
    {

        private readonly IRepositorioGenerico<Dispositivo> ?_repo;
        public DispositivoService(IRepositorioGenerico<Dispositivo>? repo)
        {
            _repo = repo;
        }

        public async Task<IReadOnlyList<DispositivoResponse>> ListarTodos()
        {
            var lista = await _repo.ListarTodosAsync();

            if (lista == null || !lista.Any())
            {
                throw new KeyNotFoundException("Nenhum dispositivo encontrado.");
            }

            var response = lista.Select(d => new DispositivoResponse
            {
                Nome = d.Nome,
                Tipo = d.Tipo,
                Estado = d.Estado.ToString(),
                Localizacao = d.Localizacao
            }).ToList();

            return response.AsReadOnly();
        }
    }
}
