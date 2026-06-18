using FluentValidation;

namespace Tawreed.BLL.Contracts.Authentication;

public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidator()
    {
        RuleFor(X => X.token)
            .NotEmpty();

        RuleFor(X => X.refreshToken)
            .NotEmpty();
    }
}
