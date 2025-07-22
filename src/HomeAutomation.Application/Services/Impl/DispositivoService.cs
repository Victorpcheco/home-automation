using AutoMapper;
using HomeAutomation.Application.DTOs;
using HomeAutomation.Application.Services.Interface;
using HomeAutomation.Domain.Entidades;
using HomeAutomation.Domain.Interfaces;

namespace HomeAutomation.Application.Services.Impl
{
    public class DispositivoService : IDispositivoService
    {

        private readonly IRepositorioGenerico<Dispositivo> ?_repo;
        private readonly IMapper _mapper;

        public DispositivoService(IRepositorioGenerico<Dispositivo>? repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<DispositivoResponseDto>> ListarTodos()
        {
            var lista = await _repo.ListarTodosAsync();

            if (lista == null || !lista.Any())
            {
                throw new KeyNotFoundException("Nenhum dispositivo encontrado.");
            }

            var response = lista.Select(d => new DispositivoResponseDto
            {
                Id = d.Id,
                Nome = d.Nome,
                Tipo = d.Tipo,
                Estado = d.Estado.ToString(),
                Localizacao = d.Localizacao
            }).ToList();

            return response.AsReadOnly();
        }

        public async Task<DispositivoResponseDto> ObterPorId(int id)
        {
            var dispositivo = await _repo.ObterPorIdAsync(id);
            if (dispositivo == null)
            {
                throw new KeyNotFoundException($"Dispositivo com ID {id} não encontrado.");
            }
            return new DispositivoResponseDto
            {
                Id = dispositivo.Id,
                Nome = dispositivo.Nome,
                Tipo = dispositivo.Tipo,
                Estado = dispositivo.Estado.ToString(),
                Localizacao = dispositivo.Localizacao
            };
        }

        public async Task<DispositivoResponseDto> ObterPorNome(string nome)
        {
            var dispositivo = await _repo.ObterPorNomeAsync(nome);
            if (dispositivo == null)
            {
                throw new KeyNotFoundException($"Dispositivo com nome '{nome}' não encontrado.");
            }
            return new DispositivoResponseDto
            {
                Id = dispositivo.Id,
                Nome = dispositivo.Nome,
                Tipo = dispositivo.Tipo,
                Estado = dispositivo.Estado.ToString(),
                Localizacao = dispositivo.Localizacao
            };
        }

        public async Task<DispositivoResponseDto> Adicionar(DispositivoRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "O objeto de solicitação não pode ser nulo.");
            }

            var dispositivo = _mapper.Map<Dispositivo>(request);

            await _repo.AdicionarAsync(dispositivo);
            return _mapper.Map<DispositivoResponseDto>(dispositivo);
        }

        public async Task<DispositivoResponseDto> Atualizar(int id, DispositivoRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "O objeto de solicitação não pode ser nulo.");
            }
            var dispositivoExistente = await _repo.ObterPorIdAsync(id);
            if (dispositivoExistente == null)
            {
                throw new KeyNotFoundException($"Dispositivo com ID {id} não encontrado.");
            }
            _mapper.Map(request, dispositivoExistente);

            dispositivoExistente.Nome = request.Nome;
            dispositivoExistente.Tipo = request.Tipo;
            dispositivoExistente.Estado = request.Estado;
            dispositivoExistente.Localizacao = request.Localizacao;

            await _repo.AtualizarAsync(dispositivoExistente);
            return _mapper.Map<DispositivoResponseDto>(dispositivoExistente);
        }

        public async Task<bool> Remover(int id)
        {
            var dispositivo = await _repo.ObterPorIdAsync(id);
            if (dispositivo == null)
            {
                throw new KeyNotFoundException($"Dispositivo com ID {id} não encontrado.");
            }
            await _repo.RemoverAsync(dispositivo);
            return true;
        }
    }
}
