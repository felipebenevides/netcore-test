using Domain.Entities;

namespace Domain.Interfaces.Repository
{
    public interface IDoctorRepository: IRepository<Doctor>
    {
        Doctor FindByCPF(string cpf);
    }
}
