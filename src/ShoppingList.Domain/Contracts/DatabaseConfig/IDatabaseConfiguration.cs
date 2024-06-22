namespace ShoppingList.Domain.Contracts.DatabaseConfig;

public interface IDatabaseConfiguration
{
    string ConnectionURI();

    string DatabaseName();

    string CollectionName();
}