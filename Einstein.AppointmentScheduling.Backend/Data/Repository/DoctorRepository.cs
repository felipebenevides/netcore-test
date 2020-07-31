using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        protected readonly AppointmentSchedulingDBContext _context;

        public DoctorRepository(AppointmentSchedulingDBContext ctx) : base(ctx)
        {
            _context = ctx;
        }

        public Doctor FindByCPF(string cpf)
        {
            string query = $"select * from Doctor where CPF = '{cpf}'";
            return _context.Doctor.FromSqlRaw(query).FirstOrDefault();
        }
    }
}
