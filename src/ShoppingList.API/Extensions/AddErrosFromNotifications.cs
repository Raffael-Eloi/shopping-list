using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ShoppingList.API.Extensions;

public static class AddErrosFromNotifications
{
    public static ModelStateDictionary AddErrosFromNofifications(this ModelStateDictionary modelState, IEnumerable<ValidationFailure> errors)
    {
        foreach (ValidationFailure item in errors)
        {
            modelState.AddModelError(item.ErrorCode, item.ErrorMessage);
        }

        return modelState;
    }
}