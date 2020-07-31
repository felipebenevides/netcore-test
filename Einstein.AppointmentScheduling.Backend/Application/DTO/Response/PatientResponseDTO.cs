using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Request
{
    public class PatientResponseDTO
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CEP { get; set; }
        public string Telephone { get; set; }
    }
}
