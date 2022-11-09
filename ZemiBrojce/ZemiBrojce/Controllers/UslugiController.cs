using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZemiBrojce.Models;
using ZemiBrojce.Services;

namespace ZemiBrojce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UslugiController : ControllerBase
    {
        private readonly  IUslugaService _uslugaService;

        public UslugiController(IUslugaService uslugaService)
        {
            _uslugaService=uslugaService;
        }
        [HttpGet]
        public ActionResult GetUslugi()
        {
            return Ok(_uslugaService.GetUsluga());
        }
        [HttpGet("choose-task")]
        public ActionResult ChoseUsluga(int id)
        {
            return Ok(_uslugaService.ChoseUsluga(id));
        }
    }
}
