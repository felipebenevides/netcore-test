using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Patient : BaseEntity, ITrackableEntity
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CEP { get; set; }
        public string Telephone { get; set; }
        public ICollection<Consultation> Consultations { get; set; }


        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
