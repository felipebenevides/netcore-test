using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace Domain.Entities
{
    public class Consultation : BaseEntity, ITrackableEntity
    {
        public Guid IdDoctor { get; set; }
        public Doctor Doctor { get; set; }
        public Guid IdPatient { get; set; }
        public Patient Patient { get; set; }

        public DateTime Date { get; set; }
        public string Hour { get; set; }
        public string HourFormater => Date.Hour + ":00";

        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}

