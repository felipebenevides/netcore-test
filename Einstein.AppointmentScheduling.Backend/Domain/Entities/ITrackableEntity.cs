using System;

namespace Domain.Entities
{
    public interface ITrackableEntity
    {
        DateTime CreateDate { get; set; }
        DateTime? ModifyDate { get; set; }
    }
}
