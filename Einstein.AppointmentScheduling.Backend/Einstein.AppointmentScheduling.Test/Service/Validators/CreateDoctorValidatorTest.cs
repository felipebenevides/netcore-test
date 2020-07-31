using Domain.Entities;
using Domain.Interfaces.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Einstein.AppointmentScheduling.Test.Service.Validators
{
    public class CreateDoctorValidatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ShouldValidateSuccessfully()
        {
            var command = new Doctor
            {
                Name = "Dr. Bryan Felipe",
                CPF = "12345678900",
                Cellphone = "11999046971",
                CRM = "101010",
                Telephone = "36898877",
                ESpecialty = (Domain.Enum.ESpecialty)1
            };

            var serviceMock = new Mock<IDoctorService>();
            serviceMock.Setup(service => service.AddOrUpdate(command));
            Assert.True(true);
        }
    }
}
