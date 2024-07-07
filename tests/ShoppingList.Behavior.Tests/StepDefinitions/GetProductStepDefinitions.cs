using TechTalk.SpecFlow.Assist;

namespace ShoppingList.Behavior.Tests.StepDefinitions;

[Binding]
public class GetProductStepDefinitions(
    ScenarioContext context,
    ShoppingListClient client)
{
    [Given(@"A product exists with the following data")]
    public async Task GivenAProductExistsWithTheFollowingData(Table table)
    {
        var request = table.CreateInstance<AddProductRequest>();

        await client.AddProductAsync(request);
    }

    [When(@"I get the products filtered by name ""([^""]*)""")]
    public async Task WhenIGetTheProductsFilteredByName(string name)
    {
        context["filteredName"] = name;

        IEnumerable<GetProductResponse> products = await client.GetProductsAsync(name, null);

        context.Set(products);
    }

    [Then(@"the the products should only have the filtered name")]
    public void ThenTheTheProductsShouldOnlyHaveTheFilteredName()
    {
        IEnumerable<GetProductResponse> products = context.Get<IEnumerable<GetProductResponse>>();

        string filteredName = context.Get<string>("filteredName");

        products.Should().NotBeNullOrEmpty();

        products.Should().OnlyContain(product => product.Name.Contains(filteredName));
    }
}