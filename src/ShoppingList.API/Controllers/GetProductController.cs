using Microsoft.AspNetCore.Mvc;
using ShoppingList.API.Extensions;
using ShoppingList.Application.Contracts.UseCases;
using ShoppingList.Application.Models;
using ShoppingList.Domain.Models;
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

    [HttpGet(Name = "GetProducts")]
    [SwaggerOperation(
        Summary = "Get products with filter",
        Description = "Get all the products according to defined filter.")]
    [ProducesResponseType(typeof(IEnumerable<GetProductResponse>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> GetProducts([FromQuery] GetProductFilter filter)
    {
        IEnumerable<GetProductResponse> products = await getProduct.GetAsync(filter);

        return Ok(products);
    }

    [HttpGet("all", Name = "GetAllProducts")]
    [SwaggerOperation(
        Summary = "Get all products",
        Description = "Get all the products.")]
    [ProducesResponseType(typeof(IEnumerable<GetProductResponse>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> GetAllProducts()
    {
        IEnumerable<GetProductResponse> products = await getProduct.GetAllAsync();

        return Ok(products);
    }
}