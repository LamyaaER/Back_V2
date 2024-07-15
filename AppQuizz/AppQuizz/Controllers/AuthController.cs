using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppQuizz.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model.Username == "test" && model.Password == "password")
            {

                var token = "example-token";
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
