using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Mappings
{
    public class DoctorMapping : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CPF).HasMaxLength(11);
            builder.Property(x => x.CRM).HasMaxLength(10);
            builder.Property(x => x.Telephone).HasMaxLength(10);
            builder.Property(x => x.Email).HasMaxLength(50);
        }
    }
}
