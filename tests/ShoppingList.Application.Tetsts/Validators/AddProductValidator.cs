using FluentValidation;
using ShoppingList.Application.Models;

namespace ShoppingList.Application.Tetsts.Validators;

internal class AddProductValidator : AbstractValidator<AddProductRequest>
{
    public AddProductValidator()
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .WithMessage("'Name' must not be empty.");
    }
}