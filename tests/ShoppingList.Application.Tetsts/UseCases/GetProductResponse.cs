using FluentValidation.Results;

namespace ShoppingList.Application.Tetsts.UseCases
{
    internal class GetProductResponse
    {
        public Guid Id { get; set; }

        public bool IsValid => !Errors.Any();

        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}