using Domain.Entities;

namespace Domain.Interfaces.Repository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        public Patient FindByCPF(string cpf);
    }
}
