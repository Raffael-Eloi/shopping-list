using Microsoft.AspNetCore.Mvc;
using ShoppingList.API.Extensions;
using ShoppingList.Application.Contracts.UseCases;
using ShoppingList.Application.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ShoppingList.API.Controllers;

[Route("api/products")]
[ApiController]
public class AddProductController(IAddProduct addProduct) : ControllerBase
{
    [HttpGet(Name = "AddProduct")]
    [SwaggerOperation(
        Summary = "Add product",
        Description = "Add a new product.")]
    [ProducesResponseType(typeof(IEnumerable<AddProductResponse>),
        StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails),
        StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> AddProduct(AddProductRequest request)
    {
        AddProductResponse response = await addProduct.AddAsync(request);

        if (!response.IsValid)
        {
            return ValidationProblem(ModelState.AddErrosFromNofifications(response.Errors));
        }

        return StatusCode(StatusCodes.Status201Created, response);
    }
}