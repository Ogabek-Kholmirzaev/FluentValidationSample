using FluentValidation;
using FluentValidationSample.Dtos;
using FluentValidationSample.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationSample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SampleController : ControllerBase
{
    private readonly IValidator<CreateOrderProductDto> _createOrderProductValidator;
    private readonly IValidator<CreateOrderDto> _createOrderDtoValidator;

    public SampleController(IValidator<CreateOrderProductDto> createOrderProductValidator, IValidator<CreateOrderDto> createOrderDtoValidator)
    {
        _createOrderProductValidator = createOrderProductValidator;
        _createOrderDtoValidator = createOrderDtoValidator;
    }

    [HttpPost("CreateUser")]
    public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
    {
        var createUserValidator = new CreateUserDtoValidator();
        var result = createUserValidator.Validate(createUserDto);

        if (!result.IsValid) 
            return BadRequest(result);

        return Ok();
    }

    [HttpPost("CreateOrderProduct")]
    public IActionResult CreateOrderProduct([FromBody] CreateOrderProductDto createOrderProductDto)
    {
        var result = _createOrderProductValidator.Validate(createOrderProductDto);

        if (!result.IsValid) 
            return BadRequest(result);

        return Ok();
    }

    [HttpPost("CreateOrder")]
    public IActionResult CreateOrder([FromBody] CreateOrderDto createOrderDto)
    {
        var result = _createOrderDtoValidator.Validate(createOrderDto);

        if (!result.IsValid)
            return BadRequest(result);

        return Ok();
    }
}