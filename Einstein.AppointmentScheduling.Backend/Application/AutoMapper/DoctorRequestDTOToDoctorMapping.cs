using Application.DTO.Request;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class DoctorRequestDTOToDoctorMapping : Profile
    {
        public DoctorRequestDTOToDoctorMapping()
        {
            CreateMap<DoctorRequestDTO, Doctor>();
        }
    }
}
