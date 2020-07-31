using Application.DTO.Request;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class DoctorToDoctorRequestDTOMapping : Profile
    {
        public DoctorToDoctorRequestDTOMapping()
        {
            CreateMap<Doctor,DoctorRequestDTO>();
        }
    }
}
