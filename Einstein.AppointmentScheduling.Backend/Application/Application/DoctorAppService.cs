using Application.DTO.Request;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Application
{
    public class DoctorAppService : IDoctorAppService
    {
        private readonly IMapper _mapper;
        private readonly IDoctorService _doctorService;

        public DoctorAppService(IMapper mapper,
                                IDoctorService doctorService)
        {
            _mapper = mapper;
            _doctorService = doctorService;
        }

        public void AddBulk(IEnumerable<DoctorRequestDTO> entities)
        {
            var addCommand = _mapper.Map<IEnumerable<Doctor>>(entities);
            _doctorService.AddBulk(addCommand);
        }

        public void AddOrUpdate(DoctorRequestDTO entity)
        {
            var addCommand = _mapper.Map<Doctor>(entity);
            _doctorService.AddOrUpdate(addCommand);
        }

        public IEnumerable<DoctorRequestDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<DoctorRequestDTO>>(_doctorService.GetAll());
        }

        public async Task<IEnumerable<DoctorRequestDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<DoctorRequestDTO>>(await _doctorService.GetAllAsync());
        }

        public DoctorRequestDTO GetById(Guid id)
        {
            return _mapper.Map<DoctorRequestDTO>(_doctorService.GetById(id));
        }

        public DoctorRequestDTO FindByCPF(string cpf)
        {
            return _mapper.Map<DoctorRequestDTO>(_doctorService.FindByCPF(cpf));
        }

        public void Remove(DoctorRequestDTO entity)
        {
            var addCommand = _mapper.Map<Doctor>(entity);
            _doctorService.Remove(addCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }

}
