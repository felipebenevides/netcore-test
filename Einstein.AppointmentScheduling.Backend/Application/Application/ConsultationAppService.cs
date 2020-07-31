using Application.DTO.Request;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class ConsultationAppService : IConsultationAppService
    {
        private readonly IMapper _mapper;
        private readonly IConsultationService _consultationService;

        public ConsultationAppService(IMapper mapper,
                                      IConsultationService consultationService)
        {
            _mapper = mapper;
            _consultationService = consultationService;
        }

        public void AddBulk(IEnumerable<ConsultationRequestDTO> entities)
        {
            var addCommand = _mapper.Map<IEnumerable<Consultation>>(entities);
            _consultationService.AddBulk(addCommand);
        }

        public void AddOrUpdate(ConsultationRequestDTO entity)
        {
            var addCommand = _mapper.Map<Consultation>(entity);
            _consultationService.AddOrUpdate(addCommand);
        }

        public IEnumerable<ConsultationRequestDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<ConsultationRequestDTO>>(_consultationService.GetAll());
        }

        public async Task<IEnumerable<ConsultationRequestDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ConsultationRequestDTO>>(await _consultationService.GetAllAsync());
        }

        public ConsultationRequestDTO GetById(Guid id)
        {
            return _mapper.Map<ConsultationRequestDTO>(_consultationService.GetById(id));
        }

        public void Remove(ConsultationRequestDTO entity)
        {
            var addCommand = _mapper.Map<Consultation>(entity);
            _consultationService.Remove(addCommand);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
