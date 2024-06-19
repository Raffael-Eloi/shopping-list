using FluentValidation.Results;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Tetsts.Validators;

public interface IGetProductValidator
{
    ValidationResult Validate(Product? product);
}