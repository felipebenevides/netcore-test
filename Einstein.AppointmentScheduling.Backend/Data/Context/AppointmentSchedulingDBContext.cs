using Data.Mappings;
//using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Data.Context
{
    public class AppointmentSchedulingDBContext : DbContext
    {
        public AppointmentSchedulingDBContext(DbContextOptions<AppointmentSchedulingDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Consultation> Consultation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoctorMapping());
            modelBuilder.ApplyConfiguration(new PatientMapping());
            modelBuilder.ApplyConfiguration(new ConsultationMapping());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries<ITrackableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreateDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("ModifyDate").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
