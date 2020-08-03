using Domain.Entities;
using System;

namespace Domain.Interfaces.Repository
{
    public interface IConsultationRepository : IRepository<Consultation>
    {
        Consultation FindConsultation(Guid idDoctor, DateTime DateTimeInitial, DateTime DateTimeFinal);
    }
}
