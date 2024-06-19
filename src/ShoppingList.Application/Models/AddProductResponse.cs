using FluentValidation.Results;

namespace ShoppingList.Application.Models;

public class AddProductResponse
{
    public AddProductResponse()
    {
        Errors = [];
    }
    
    public Guid? ProductId { get; set; }

    public bool IsValid => !Errors.Any();

    public IEnumerable<ValidationFailure> Errors { get; set; }
}