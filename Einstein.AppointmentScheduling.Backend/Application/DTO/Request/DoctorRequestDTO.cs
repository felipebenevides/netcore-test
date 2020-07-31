using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Request
{
    public class DoctorRequestDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string CRM { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public ESpecialty ESpecialty { get; set; }

    }
}
