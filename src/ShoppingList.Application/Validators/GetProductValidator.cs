using FluentValidation.Results;
using ShoppingList.Application.Contracts.Validators;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Validators;

public class GetProductValidator : IGetProductValidator
{
    public ValidationResult Validate(Product? product)
    {
        if (ProductDoesNExist(product))
        {
            return ValidationResultWithErrors();
        }

        return new ValidationResult();
    }

    private static ValidationResult ValidationResultWithErrors()
    {
        return new ValidationResult(new List<ValidationFailure>
        {
            new("Product", "Product not found.")
        });
    }

    private static bool ProductDoesNExist(Product? product)
    {
        return product is null;
    }
}