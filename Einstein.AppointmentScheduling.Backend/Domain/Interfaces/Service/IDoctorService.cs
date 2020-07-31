using Domain.Entities;

namespace Domain.Interfaces.Service
{
    public interface IDoctorService : IService<Doctor>
    {
        public Doctor FindByCPF(string cpf);
    }
}
