using Application.DTO.Request;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class ConsultationRequestDTOToConsultationMapping : Profile
    {
        public ConsultationRequestDTOToConsultationMapping()
        {
            CreateMap<ConsultationRequestDTO,Consultation>();
        }
    }
}
