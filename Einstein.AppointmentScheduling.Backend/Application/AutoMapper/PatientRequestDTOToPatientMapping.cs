using Application.DTO.Request;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class PatientRequestDTOToPatientMapping : Profile
    {
        public PatientRequestDTOToPatientMapping()
        {
            CreateMap<PatientRequestDTO,Patient>();
        }
    }
}
