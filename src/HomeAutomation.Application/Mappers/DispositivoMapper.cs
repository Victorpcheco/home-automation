using AutoMapper;
using HomeAutomation.Application.DTOs;
using HomeAutomation.Domain.Entidades;

namespace HomeAutomation.Application.Mappers
{
    public class DispositivoMapper : Profile
    {
        public DispositivoMapper()
        {
            CreateMap<DispositivoRequestDto, Dispositivo>();
            CreateMap<Dispositivo, DispositivoResponseDto>();
        }
    }
}
