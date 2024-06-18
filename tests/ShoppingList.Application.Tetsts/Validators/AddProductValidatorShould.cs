using FluentAssertions;
using FluentValidation.Results;
using ShoppingList.Application.Models;

namespace ShoppingList.Application.Tetsts.Validators;

internal class AddProductValidatorShould
{
    [Test]
    public void Return_Notification_When_Name_Is_Empty()
    {
		#region Arrange(Given)

		string name = string.Empty;

		var request = new AddProductRequest
        {
            Name = name
        };

        AddProductValidator validator = new AddProductValidator();

        #endregion

        #region Act(When)

        ValidationResult result = validator.Validate(request);

        #endregion

        #region Assert(Then)

        result.Should().NotBeNull();

        result.IsValid.Should().BeFalse();

        result.Errors.First().ErrorMessage.Should().Be("'Name' must not be empty.");

        #endregion
    }
}