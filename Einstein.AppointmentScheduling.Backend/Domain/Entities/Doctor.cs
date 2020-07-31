using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Doctor : BaseEntity, ITrackableEntity
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string CRM { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public ESpecialty ESpecialty { get; set; }

        public ICollection<Consultation> Consultations { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
