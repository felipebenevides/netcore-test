using System;

namespace Application.DTO.Request
{
    public class ConsultationRequestDTO
    {
        public Guid Id { get; set; }

        public Guid IdDoctor { get; set; }
        public Guid IdPatient { get; set; }

        public DateTime Date { get; set; }
    }
}
