using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Tawreed.BLL.Contracts.Authentication;
using Tawreed.BLL.Services.AuthService;

namespace Tawreed.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;
        

        [HttpPost("")]
        public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
        {
            var authResult = await _authService.GetTokenAsync(request.Email, request.Password, cancellationToken);

            //return authResult is null ?
            //     BadRequest("Invalid Email Or Password.") 
            //     : Ok(authResult);
            return authResult.IsSuccess ? Ok(authResult.Value) : 
                Problem(statusCode: StatusCodes.Status400BadRequest, title: authResult.Error.Code, detail:authResult.Error.Description);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var authResult = await _authService.GetRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);
           
            if (authResult is null)
                return BadRequest("Invalid Token.");
            return Ok(authResult);
        }


        [HttpPost("revoke-refresh-token")]
        public async Task<IActionResult> RevokeRefreshToken([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var isRevoked = await _authService.RevokeRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);
            if (isRevoked)
                return Ok();
            else
                return BadRequest("Operation Failed.");
        }


        // POST api/auth/register/buyer
        [HttpPost("register/buyer")]
        public async Task<IActionResult> RegisterBuyer([FromBody] RegisterBuyerRequest request, CancellationToken cancellationToken)
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
            var result = await _authService.RegisterSupplierAsync(request, cancellationToken);

            //return result.IsSuccess
            //    ? Ok("Registration successful. Your account is pending admin approval.")
            //    : Conflict("Email is already registered.");
            return result.IsSuccess ? Ok(result.Value) :
              Problem(statusCode: StatusCodes.Status409Conflict, title: result.Error.Code, detail: result.Error.Description);
        }
        //if (response is null)
        //    return Conflict("Email is already registered.");

        //// 202 Accepted — account created but pending admin approval
        //return Accepted(new { message = "Registration successful. Your account is pending admin approval.", userId = response.Id });
    
    }
}
