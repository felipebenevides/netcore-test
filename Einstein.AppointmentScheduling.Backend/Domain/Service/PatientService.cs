using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public void AddBulk(IEnumerable<Patient> entities)
        {
            _patientRepository.AddBulk(entities);
        }

        public void AddOrUpdate(Patient entity)
        {
            _patientRepository.AddOrUpdate(entity);
        }


        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _patientRepository.GetAllAsync();
        }

        public Patient GetById(Guid id)
        {
          return _patientRepository.GetById(id);
        }

        public void Remove(Patient entity)
        {
            _patientRepository.Remove(entity);
        }

        public Patient FindByCPF(string cpf)
        {
            return _patientRepository.FindByCPF(cpf);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
