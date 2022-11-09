using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZemiBrojce.Models;
using ZemiBrojce.Services;

namespace ZemiBrojce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberController : ControllerBase
    {
        private readonly INumberService _numberService;

        public NumberController(INumberService numberService)
        {
            _numberService=numberService;
        }

        [HttpGet("get-number/{uslugaId}")]
        public ActionResult GetNumber(int uslugaId)
        {
            return Ok(_numberService.GetNumber(uslugaId));
        }

        [HttpGet("update-curr-number/{uslugaId}")]
        public ActionResult NextNumber(int uslugaId)
        {
            return Ok(_numberService.NextNumber(uslugaId));
        }

    }
}

