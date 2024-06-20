using FluentValidation.Results;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Contracts.Validators;

public interface IGetProductValidator
{
    ValidationResult Validate(Product? product);
}