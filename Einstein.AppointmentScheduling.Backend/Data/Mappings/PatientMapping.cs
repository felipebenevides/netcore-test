using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Mappings
{
    public class PatientMapping : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CPF).HasMaxLength(11);
            builder.Property(x => x.Address).HasMaxLength(100);
            builder.Property(x => x.CEP).HasMaxLength(9);
            builder.Property(x => x.Telephone).HasMaxLength(10);
            builder.Property(x => x.Email).HasMaxLength(50);

            //        modelBuilder.Entity<Employee>()
            //.HasOne(e => e.Company)
            //.WithMany(c => c.Employees);

            
            //builder.HasOne(x => x.Account)
            // .WithMa(x => x.LegalPerson)
            // .HasForeignKey<LegalPerson>(x => x.AccountID);
        }
    }
}
