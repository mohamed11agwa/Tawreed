using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Tawreed.BLL.Contracts.Authentication;
using Tawreed.BLL.Services.AuthService;

namespace Tawreed.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(IAuthService authService, IOptions<JwtOptions> jwtOptions) : ControllerBase
    {
        private readonly IAuthService _authService = authService;
        private readonly JwtOptions _jwtOptions = jwtOptions.Value;


        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginRequest request,
            CancellationToken cancellationToken)
        {
    
            var response = await _authService.GetTokenAsync(request.Email, request.Password, cancellationToken);

            if (response is null)
                return Unauthorized("Invalid credentials or account is pending approval.");

            return Ok(response);
        }

        // POST api/auth/register/buyer
        [HttpPost("register/buyer")]
        public async Task<IActionResult> RegisterBuyer(
            [FromBody] RegisterBuyerRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _authService.RegisterBuyerAsync(request, cancellationToken);

            if (response is null)
                return Conflict("Email is already registered.");

            return CreatedAtAction(nameof(Login), response);
        }

        // POST api/auth/register/supplier
        [HttpPost("register/supplier")]
        public async Task<IActionResult> RegisterSupplier([FromBody] RegisterSupplierRequest request, CancellationToken cancellationToken)
        {
            var response = await _authService.RegisterSupplierAsync(request, cancellationToken);

            //if (response is null)
            //    return Conflict("Email is already registered.");

            //// 202 Accepted — account created but pending admin approval
            //return Accepted(new { message = "Registration successful. Your account is pending admin approval.", userId = response.Id });
            return request is null ?
                BadRequest("Email IS Duplicated") : Ok(response);
        }


        [HttpPost("refresh")]
        public async Task<ActionResult> Refresh(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var authresult = await _authService.GetRefreshTokenAsync(request.token, request.refreshToken, cancellationToken);

            if (authresult is null)
                return BadRequest("Invalid Token");
            return Ok(authresult);
        }
    }
}
