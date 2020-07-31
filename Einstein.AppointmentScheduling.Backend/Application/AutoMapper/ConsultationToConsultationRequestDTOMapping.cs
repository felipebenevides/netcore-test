using Application.DTO.Request;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class ConsultationToConsultationRequestDTOMapping : Profile
    {
        public ConsultationToConsultationRequestDTOMapping()
        {
            CreateMap<Consultation, ConsultationRequestDTO>();
        }
    }
}
