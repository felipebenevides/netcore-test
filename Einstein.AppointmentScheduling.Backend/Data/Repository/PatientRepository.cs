using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        protected readonly AppointmentSchedulingDBContext _context;

        public PatientRepository(AppointmentSchedulingDBContext ctx) : base(ctx)
        {
            _context = ctx;
        }

        public Patient FindByCPF(string cpf)
        {
            string query = $"select * from Patient where CPF = '{cpf}'";
            return _context.Patient.FromSqlRaw(query).FirstOrDefault();
        }
    }
}
