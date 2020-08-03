using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class ConsultationService : IConsultationService
    {
        private readonly IConsultationRepository _consultationRepository;
        public ConsultationService(IConsultationRepository consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }

        public void AddBulk(IEnumerable<Consultation> entities)
        {
            _consultationRepository.AddBulk(entities);
        }
   
        private bool ValidateTimeConsultation(Consultation entity)
        {
            var searchConsultation = _consultationRepository.FindConsultation(entity.IdDoctor, entity.Date, entity.Date.AddMinutes(60));

            if (searchConsultation != null)
               return false;

            return true;
        }
        public void AddOrUpdate(Consultation entity)
        {
            entity.Hour = entity.HourFormater;
            if (!ValidateTimeConsultation(entity))
            throw new Exception("Não foi possivel agendar a consulta neste horario!");
            
            _consultationRepository.AddOrUpdate(entity);
        }

        public IEnumerable<Consultation> GetAll()
        {
            return _consultationRepository.GetAll();
        }

        public async Task<IEnumerable<Consultation>> GetAllAsync()
        {
            return await _consultationRepository.GetAllAsync();
        }

        public Consultation GetById(Guid id)
        {
            return _consultationRepository.GetById(id);
        }

        public void Remove(Consultation entity)
        {
            _consultationRepository.Remove(entity);
        }

     

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
