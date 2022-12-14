using FluentValidation;
using FluentValidationSample.Dtos;

namespace FluentValidationSample.Validators;

public class CreateOrderDtoValidator:AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(o=>o.UserId).NotNull();

        RuleFor(o=>o.Products).NotNull();
        RuleFor(o => o.Products).Must(product => product!.Count > 0);

        RuleForEach(o=>o.Products).NotEmpty();

        RuleFor(o => o.CreateUser).NotNull();
    }
}