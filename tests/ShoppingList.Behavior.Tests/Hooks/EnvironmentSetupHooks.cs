using BoDi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ShoppingList.Behavior.Tests.Hooks;

[Binding]
public sealed class EnvironmentSetupHooks
{
    [BeforeTestRun]
    public static void BeforeTestRun(IObjectContainer testThreadContainer)
    {
        HttpClient? apiHttpClient;

        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("Development");
        });

        apiHttpClient = application.CreateClient();

        var shoppingListClient = new ShoppingListClient("", apiHttpClient);

        testThreadContainer.RegisterInstanceAs(shoppingListClient);
    }
}