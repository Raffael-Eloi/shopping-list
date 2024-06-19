using FluentValidation.Results;

namespace ShoppingList.Application.Contracts.Validators;

public interface IValidator
{
    ValidationResult Validate<T>(T model);
}