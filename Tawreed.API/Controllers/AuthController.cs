using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tawreed.BLL.Contracts.Authentication;
using Tawreed.BLL.Services.AuthService;

namespace Tawreed.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(
     IAuthService authService,
     IValidator<LoginRequest> loginValidator,
     IValidator<RegisterBuyerRequest> registerBuyerValidator,
     IValidator<RegisterSupplierRequest> registerSupplierValidator) : ControllerBase
    {
        private readonly IAuthService _authService = authService;
        private readonly IValidator<LoginRequest> _loginValidator = loginValidator;
        private readonly IValidator<RegisterBuyerRequest> _registerBuyerValidator = registerBuyerValidator;
        private readonly IValidator<RegisterSupplierRequest> _registerSupplierValidator = registerSupplierValidator;

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginRequest request,
            CancellationToken cancellationToken)
        {
            var validation = await _loginValidator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
                return BadRequest(validation.Errors.Select(e => e.ErrorMessage));

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
            var validation = await _registerBuyerValidator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
                return BadRequest(validation.Errors.Select(e => e.ErrorMessage));

            var response = await _authService.RegisterBuyerAsync(request, cancellationToken);

            if (response is null)
                return Conflict("Email is already registered.");

            return CreatedAtAction(nameof(Login), response);
        }

        // POST api/auth/register/supplier
        [HttpPost("register/supplier")]
        public async Task<IActionResult> RegisterSupplier(
            [FromBody] RegisterSupplierRequest request,
            CancellationToken cancellationToken)
        {
            var validation = await _registerSupplierValidator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
                return BadRequest(validation.Errors.Select(e => e.ErrorMessage));

            var response = await _authService.RegisterSupplierAsync(request, cancellationToken);

            if (response is null)
                return Conflict("Email is already registered.");

            // 202 Accepted — account created but pending admin approval
            return Accepted(new { message = "Registration successful. Your account is pending admin approval.", userId = response.Id });
        }
    }
}
