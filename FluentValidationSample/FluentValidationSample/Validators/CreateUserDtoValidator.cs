using FluentValidation;
using FluentValidationSample.Dtos;

namespace FluentValidationSample.Validators;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(u => u.UserName).NotEmpty()
            .WithMessage("username is null or empty");

        RuleFor(u => u.Password).NotEmpty();
        RuleFor(u => u.Password).Length(6, 30);

        RuleFor(u => u.Email).NotEmpty();

        RuleFor(u => u.Password).Equal(u => u.ConfirmPassword)
            .WithMessage("Confirmed password must be equal to Password");
    }
}