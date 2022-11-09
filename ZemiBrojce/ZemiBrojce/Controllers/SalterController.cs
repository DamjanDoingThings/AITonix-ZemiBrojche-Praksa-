using Microsoft.AspNetCore.Mvc;
using ZemiBrojce.Models;
using ZemiBrojce.Services;

namespace ZemiBrojce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalterController : ControllerBase
    {
        private readonly ISalterService _salterService;



        public SalterController(ISalterService salterService)
        {
            _salterService= salterService;
        }
        [HttpGet("get-salter-number/{salterId}")]
        public ActionResult GetSalterNumber(int salterId)
        {
            
            return Ok(_salterService.GetSalterNumber(salterId));
        }
    }
}
