using Application.DTO.Request;

namespace Application.Interfaces
{
    public interface IDoctorAppService: IAppService<DoctorRequestDTO>
    {
        public DoctorRequestDTO FindByCPF(string cpf);
    }
}
