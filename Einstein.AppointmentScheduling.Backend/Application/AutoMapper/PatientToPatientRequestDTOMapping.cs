using Application.DTO.Request;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class PatientToPatientRequestDTOMapping : Profile
    {
        public PatientToPatientRequestDTOMapping()
        {
            CreateMap<Patient, PatientRequestDTO>();
        }
    }
}
