using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using APIDoanV.Services;
using APIDoanV.Models;
namespace APIDoanV.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : Controller
    {
        private IUserService _userService;
        ApiContext db = new ApiContext();
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);
            if (user == null)
                return BadRequest(new { message = "not correct!" });
            return Ok(user);
        }
    }    
}
