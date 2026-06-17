using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Tawreed.BLL.Contracts.Authentication;
using Tawreed.BLL.Services.AuthService;

namespace Tawreed.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService, IOptions<JwtOptions> jwtOptions) : ControllerBase
    {
        private readonly IAuthService _authService = authService;
        private readonly JwtOptions _jwtOptions = jwtOptions.Value;


        [HttpPost("")]
        public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
        {
            var authResult = await _authService.GetTokenAsync(request.Email, request.Password, cancellationToken);
           
            return authResult is null ?
                BadRequest("Invalid Email Or Password") : Ok(authResult);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.RegisterAsync(request, cancellationToken);

            return request is null ?
                BadRequest("Email IS Duplicated") : Ok(result);
        }



    }
}
