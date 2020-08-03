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
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationAppService _consultationAppService;
        public ConsultationController(IConsultationAppService consultationAppService)
        {
            _consultationAppService = consultationAppService;
        }

        [HttpGet]
        public async Task<IActionResult> ListConsultationAssync()
        {
            try
            {
                var result = await _consultationAppService.GetAllAsync();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateConsultation([FromBody] ConsultationRequestDTO consultationRequestDTO)
        {
            try
            {
                _consultationAppService.AddOrUpdate(consultationRequestDTO);
                return StatusCode(200, true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateConsultation([FromBody] ConsultationRequestDTO consultationRequestDTO)
        {
            try
            {
                _consultationAppService.AddOrUpdate(consultationRequestDTO);
                return StatusCode(200, true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }
    }
}
