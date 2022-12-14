namespace FluentValidationSample.Dtos;

public class CreateOrderDto
{
    public int? UserId { get; set; }
    public List<CreateOrderProductDto>? Products { get; set; }
    public CreateUserDto? CreateUser { get; set; }
}