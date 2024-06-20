using FluentValidation.Results;

namespace ShoppingList.Application.Models;

public class GetProductResponse
{
    public GetProductResponse()
    {
        Errors = [];
    }

    public Guid Id { get; set; }

    public bool IsValid => !Errors.Any();

    public IEnumerable<ValidationFailure> Errors { get; set; }
}