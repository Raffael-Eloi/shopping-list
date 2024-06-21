using Microsoft.AspNetCore.Mvc;
using ShoppingList.API.Extensions;
using ShoppingList.Application.Contracts.UseCases;
using ShoppingList.Application.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ShoppingList.API.Controllers;

[Route("api/products")]
[ApiController]
public class GetProductController(IGetProduct getProduct) : ControllerBase
{
    [HttpGet("{id:Guid}", Name = "GetProductById")]
    [SwaggerOperation(
        Summary = "Get product by id",
        Description = "Get a product given the id.")]
    [ProducesResponseType(typeof(GetProductResponse),
        StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails),
        StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> GetProductById(Guid id)
    {
        GetProductResponse response = await getProduct.GetByIdAsync(id);

        if (!response.IsValid)
        {
            return ValidationProblem(ModelState.AddErrosFromNofifications(response.Errors));
        }

        return Ok(response);
    }
}