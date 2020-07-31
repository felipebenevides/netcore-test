using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("PF")]
    [ApiController]
    public class PhysicalPersonController : ControllerBase
    {
        //private readonly IPhysicalPersonAppService _physicalPersonAppService;

        //public PhysicalPersonController(IPhysicalPersonAppService physicalPersonAppService)
        //{
        //    _physicalPersonAppService = physicalPersonAppService;
        //}
     
        //[HttpGet("/Register")]
        //public async Task<IActionResult> Register()
        //{
        //    try
        //    {
        //       var result = _physicalPersonAppService.GetAllAsync();
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.StackTrace);
        //    }
        //}

        //[HttpPost("/Register")]
        //public async Task<IActionResult> Register(PhysicalPersonViewModel model)
        //{
        //    try
        //    {
        //        _physicalPersonAppService.AddOrUpdate(model);
        //        return Ok(true);
        //    }
        //    catch (Exception ex)E:\Users\Felipe Benevides\Documents\Testes\Einstein\netcore-test\DigitalBank.Backend\APIApp\.gitignore
        //    {
        //        return StatusCode(500, ex.StackTrace);
        //    }

        //}
    }
}
