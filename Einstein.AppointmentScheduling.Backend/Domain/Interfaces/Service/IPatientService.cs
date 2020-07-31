using Domain.Entities;

namespace Domain.Interfaces.Service
{
    public interface IPatientService: IService<Patient>
    {
        public Patient FindByCPF(string cpf);
    }
}
