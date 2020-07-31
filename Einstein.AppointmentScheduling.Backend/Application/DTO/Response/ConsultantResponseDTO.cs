using System;

namespace Application.DTO.Request
{
    public class ConsultantResponseDTO
    {
        public Guid IdDoctor { get; set; }
        public Guid IdPatient { get; set; }

        public DateTime Hour { get; set; }
    }
}
