using Application.AutoMapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIApp.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DoctorToDoctorRequestDTOMapping), typeof(DoctorRequestDTOToDoctorMapping));
            services.AddAutoMapper(typeof(PatientToPatientRequestDTOMapping), typeof(PatientRequestDTOToPatientMapping));
            services.AddAutoMapper(typeof(ConsultationToConsultationRequestDTOMapping), typeof(ConsultationRequestDTOToConsultationMapping));
        }
    }
}
