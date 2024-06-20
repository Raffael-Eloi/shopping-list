using FluentValidation.Results;
using ShoppingList.Application.Models;

namespace ShoppingList.Application.Contracts.Validators;

public interface IAddProductValidator
{
    ValidationResult Validate(AddProductRequest request);
}