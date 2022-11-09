using Microsoft.AspNetCore.Mvc;
using ZemiBrojce.Models;
using ZemiBrojce.Services;

namespace ZemiBrojce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;   
        }
       [HttpPost("change-user-position")]
       public ActionResult ChangeUser(int userId,int salterId)
        {
           
            return Ok(_userService.ChangeNumber(userId,salterId));
        }

        [HttpGet("get-all-users")]
        public ActionResult GetUsers()
        {

            return Ok(_userService.GetAllUsers());
        }


        [HttpGet("get-single-user")]
        public ActionResult GetUser(int id)
        {

            return Ok(_userService.GetUser(id));
        }
    }
}
