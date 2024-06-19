using FluentValidation.Results;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Tetsts.Validators;

public class GetProductValidator : IGetProductValidator
{
    public ValidationResult Validate(Product? product)
    {
        if (product is null)
        {
            return new ValidationResult(new List<ValidationFailure>
            {
                new ValidationFailure("Product", "Product not found.")
            });
        }

        return new ValidationResult();
    }
}