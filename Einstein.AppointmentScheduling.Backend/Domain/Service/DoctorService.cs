using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public void AddBulk(IEnumerable<Doctor> entities)
        {
            _doctorRepository.AddBulk(entities);
        }

        public void AddOrUpdate(Doctor entity)
        {
            _doctorRepository.AddOrUpdate(entity);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _doctorRepository.GetAllAsync();
        }

        public Doctor GetById(Guid id)
        {
            return _doctorRepository.GetById(id);
        }

        public Doctor FindByCPF(string cpf)
        {
            return _doctorRepository.FindByCPF(cpf);
        }

        public void Remove(Doctor entity)
        {
            _doctorRepository.Remove(entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
