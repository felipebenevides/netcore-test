using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ConsultationMapping : IEntityTypeConfiguration<Consultation>
    {
        public void Configure(EntityTypeBuilder<Consultation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.Consultations)
                .HasForeignKey(x => x.IdPatient);

            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.Consultations)
                .HasForeignKey(x => x.IdDoctor);
        }
    }
}
