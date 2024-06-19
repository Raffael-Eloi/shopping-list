using FluentValidation;
using ShoppingList.Application.Models;

namespace ShoppingList.Application.Validators;

public class AddProductValidator : AbstractValidator<AddProductRequest>, IValidator
{
    public AddProductValidator()
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .WithMessage("'Name' must not be empty.");

        RuleFor(request => request.Price)
            .GreaterThan(0)
            .WithMessage("'Price' must be greater than 0.");

        RuleFor(request => request.Quantity)
            .GreaterThan(0)
            .WithMessage("'Quantity' must be greater than 0.");
    }
}