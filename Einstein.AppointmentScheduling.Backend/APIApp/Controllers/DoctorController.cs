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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorAppService _doctorAppService;
        public DoctorController(IDoctorAppService doctorAppService)
        {
            _doctorAppService = doctorAppService;
        }

        [HttpGet]
        public async Task<IActionResult> ListDoctorAssync()
        {
            try
            {
                var result = await _doctorAppService.GetAllAsync();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody]DoctorRequestDTO doctorRequestDTO)
        {
            try
            {
                _doctorAppService.AddOrUpdate(doctorRequestDTO);
                return StatusCode(200, true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDoctor([FromBody] DoctorRequestDTO doctorRequestDTO)
        {
            try
            {
                _doctorAppService.AddOrUpdate(doctorRequestDTO);
                return StatusCode(200, true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

        [HttpGet("doctor/{cpf}")]
        public async Task<IActionResult> FindByCPF(string cpf)
        {
            try
            {
                var result = _doctorAppService.FindByCPF(cpf);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }


    }
}
