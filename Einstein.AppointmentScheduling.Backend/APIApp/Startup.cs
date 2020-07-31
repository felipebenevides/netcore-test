using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Domain.Service;
using Domain.Interfaces.Service;
using Application.Interfaces;
using Application.Application;
using Domain.Interfaces.Repository;
using Data.Repository;
using AutoMapper;
using Application.AutoMapper;
using APIApp.Configurations;

namespace APIApp
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       

        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DigitalBank API Beta", Version = "v0.0.0.1" });
            });

            //AutoMapper Settings
            services.AddAutoMapperConfiguration();

            // Setting DBContexts
            services.AddDatabaseConfiguration(Configuration);


            #region Dependency Injection

            #region Application Services
            services.AddTransient<IDoctorAppService, DoctorAppService>();
            services.AddTransient<IPatientAppService, PatientAppService>();
            services.AddTransient<IConsultationAppService, ConsultationAppService>();

            #endregion

            #region Services
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IConsultationService, ConsultationService>();
            #endregion

            #region Repositories
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IConsultationRepository, ConsultationRepository>();

            #endregion

            services.AddScoped<AppointmentSchedulingDBContext>();
            
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DigitalBank API Beta");
                c.RoutePrefix = string.Empty;
            });
        }

   
    }
}
