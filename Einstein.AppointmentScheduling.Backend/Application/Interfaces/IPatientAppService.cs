using Application.DTO.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IPatientAppService: IAppService<PatientRequestDTO>
    {
        public PatientRequestDTO FindByCPF(string cpf);
    }
}
