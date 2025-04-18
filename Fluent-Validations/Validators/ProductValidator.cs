using Fluent_Validations.Models;
using FluentValidation;

namespace Fluent_Validations.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("Id is required.");
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .Length(2, 50)
                .WithMessage("Name must be between 2 and 50 characters.");
            RuleFor(p => p.Price)
                .NotEmpty()
                .WithMessage("Price is required.")
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0.");
        }
    }
}
