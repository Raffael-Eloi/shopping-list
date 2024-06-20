using FluentAssertions;
using FluentValidation.Results;
using ShoppingList.Application.Contracts.Validators;
using ShoppingList.Application.Validators;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Tetsts.Validators;

internal class GetProductValidatorShould
{
    [Test]
    public void Return_Notification_When_Product_Does_Not_Exist()
    {
        #region Arrange(Given)

        Product? unexistingProduct = null;

        IGetProductValidator validator = new GetProductValidator();

        #endregion

        #region Act(When)

        ValidationResult result = validator.Validate(unexistingProduct);

        #endregion

        #region Assert(Then)

        result.IsValid.Should().BeFalse();

        result.Errors.First().ErrorMessage.Should().Be("Product not found.");

        #endregion
    }
}