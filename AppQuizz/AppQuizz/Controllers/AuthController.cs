using Microsoft.AspNetCore.Mvc;

public class AuthController : ControllerBase
{
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