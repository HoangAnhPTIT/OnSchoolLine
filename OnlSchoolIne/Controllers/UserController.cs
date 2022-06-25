using Microsoft.AspNetCore.Mvc;
using OnSchoolLine.Models;
using OnSchoolLine.Services;
using System.Threading.Tasks;

namespace OnSchoolLine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthenticationRequest model)
        {
            try
            {
                var result = await _userService.RegisterUser(model);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationRequest model)
        {
            try
            {
                var result = await _userService.LoginAction(model);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
