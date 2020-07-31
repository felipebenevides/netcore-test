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
    public class PatientAppService : IPatientAppService
    {
        private readonly IMapper _mapper;
        private readonly IPatientService _patientService;

        public PatientAppService(IMapper mapper,
                                 IPatientService patientService)
        {
            _mapper = mapper;
            _patientService = patientService;
        }

        public void AddBulk(IEnumerable<PatientRequestDTO> entities)
        {
            var addCommand = _mapper.Map<IEnumerable<Patient>>(entities);
            _patientService.AddBulk(addCommand);
        }

        public void AddOrUpdate(PatientRequestDTO entity)
        {
            var addCommand = _mapper.Map<Patient>(entity);
            _patientService.AddOrUpdate(addCommand);
        }

        public IEnumerable<PatientRequestDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<PatientRequestDTO>>(_patientService.GetAll());
        }

        public async Task<IEnumerable<PatientRequestDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PatientRequestDTO>>(await _patientService.GetAllAsync());
        }

        public PatientRequestDTO GetById(Guid id)
        {
            return _mapper.Map<PatientRequestDTO>(_patientService.GetById(id));
        }
        public PatientRequestDTO FindByCPF(string cpf)
        {
            return _mapper.Map<PatientRequestDTO>(_patientService.FindByCPF(cpf));
        }

        public void Remove(PatientRequestDTO entity)
        {
            var addCommand = _mapper.Map<Patient>(entity);
            _patientService.Remove(addCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
