using TechTalk.SpecFlow.Assist;

namespace ShoppingList.Behavior.Tests.StepDefinitions;

[Binding]
public class AddProductStepDefinitions(
    ScenarioContext context,
    ShoppingListClient client)
{
    [Given(@"I want to add a new product")]
    public static void GivenIWantToAddANewProduct()
    {
    }

    [When(@"I add the product with the following details")]
    public async Task WhenIAddTheProductWithTheFollowingDetails(Table table)
    {
        var request = table.CreateInstance<AddProductRequest>();

        context.Set(request);

        AddProductResponse response = await client.AddProductAsync(request);

        context.Set(response);
    }

    [Then(@"the product should be added successfully")]
    public async Task ThenTheProductShouldBeAddedSuccessfully()
    {
        var response = context.Get<AddProductResponse>();
        response.Should().NotBeNull();
        response.IsValid.Should().BeTrue();
        response.ProductId.Should().NotBeNull();

        Guid productId = response.ProductId!.Value;

        GetProductResponse product = await client.GetProductByIdAsync(productId);
        product.Should().NotBeNull();
        product.Id.Should().Be(productId);

        var request = context.Get<AddProductRequest>();

        product.Name.Should().Be(request.Name);
        product.Description.Should().Be(request.Description);
        product.Price.Should().Be(request.Price);
        product.Quantity.Should().Be(request.Quantity);
    }
}