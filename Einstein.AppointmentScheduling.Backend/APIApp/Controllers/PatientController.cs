using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Einstein.AppointmentScheduling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientAppService _patientAppService;

        public PatientController(IPatientAppService patientAppService)
        {
            _patientAppService = patientAppService;
        }

        [HttpGet]
        public async Task<IActionResult> ListPatientAssync()
        {
            try
            {
                var result = await _patientAppService.GetAllAsync();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] PatientRequestDTO patientRequestDTO)
        {
            try
            {
                _patientAppService.AddOrUpdate(patientRequestDTO);
                return StatusCode(200, true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePatient([FromBody] PatientRequestDTO patientRequestDTO)
        {
            try
            {
                _patientAppService.AddOrUpdate(patientRequestDTO);
                return StatusCode(200, true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }


        [HttpGet("patient/{cpf}")]
        public async Task<IActionResult> FindByCPF(string cpf)
        {
            try
            {
                var result = _patientAppService.FindByCPF(cpf);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }
    }
}
