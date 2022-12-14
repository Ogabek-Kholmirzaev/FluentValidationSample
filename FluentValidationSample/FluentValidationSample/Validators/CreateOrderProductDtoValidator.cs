using FluentValidation;
using FluentValidationSample.Dtos;

namespace FluentValidationSample.Validators;

public class CreateOrderProductDtoValidator:AbstractValidator<CreateOrderProductDto>
{
    public CreateOrderProductDtoValidator()
    {
        RuleFor(op => op.ProductId).NotNull().When(op => string.IsNullOrWhiteSpace(op.SerialNumber));
        RuleFor(op => op.SerialNumber).NotNull().When(op => op.ProductId == null);
    }
}