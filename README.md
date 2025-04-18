# ✅ ASP.NET Core Web API – FluentValidation Example

This project demonstrates how to integrate and use **FluentValidation** in an ASP.NET Core Web API for model validation with cleaner and maintainable code.


## 📦 Technologies Used

- ASP.NET Core 8 Web API
- FluentValidation
- Entity Framework Core (optional)
- Swagger (Swashbuckle)


## 🎯 Features

- FluentValidation integration
- Model-level validation
- Custom validation rules
- Swagger UI support
- Centralized error handling (optional)


## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/sumit-jadhav-19/FluentValidationAPI.git
```
### 2. Install FluentValidation Package
```
dotnet add package FluentValidation.AspNetCore
```
### 3. Configure FluentValidation in Program.cs
```
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
```
### 4. Create Model
```
public class UserModel
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}
```
### 5. Create Validator
```
using FluentValidation;

public class UserModelValidator : AbstractValidator<UserModel>
{
    public UserModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MinimumLength(3);

        RuleFor(x => x.Age)
            .InclusiveBetween(18, 60).WithMessage("Age must be between 18 and 60.");

        RuleFor(x => x.Email)
            .NotEmpty().EmailAddress().WithMessage("Invalid email address.");
    }
}
```
### 6. Create Controller
```
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IValidator<Product> _validator;
    public ProductController(IValidator<Product> validator)
    {
        _validator = validator;
    }
    [HttpPost]
    public IActionResult CreateProduct([FromBody] Product product)
    {
        var validationResult = _validator.Validate(product);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        // If validation is successful, save to database or perform your logic
        return Ok(new { message = "Product created successfully" });
    }
}
```
