using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ConsultationRepository : Repository<Consultation>, IConsultationRepository
    {
        protected readonly AppointmentSchedulingDBContext _context;

        public ConsultationRepository(AppointmentSchedulingDBContext ctx) : base(ctx)
        {
            _context = ctx;
        }

        public Consultation FindConsultation(Guid idDoctor, DateTime DateTimeInitial, DateTime DateTimeFinal)
        {
            string query = $"select * from Consultation where IdDoctor = '{idDoctor}' AND Date BETWEEN '{DateTimeInitial}' AND '{DateTimeFinal}'"; 
            return  _context.Consultation.FromSqlRaw(query).FirstOrDefault();
        }
    }
}
