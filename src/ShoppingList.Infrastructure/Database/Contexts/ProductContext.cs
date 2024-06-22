using MongoDB.Driver;
using ShoppingList.Domain.Contracts.DatabaseConfig;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Infrastructure.Database.Contexts;

public class ProductContext
{
    public readonly IMongoCollection<Product> Products;

    public ProductContext(IDatabaseConfiguration databaseSettings)
    {
        MongoClient client = new(databaseSettings.ConnectionURI());

        IMongoDatabase database = client.GetDatabase(databaseSettings.DatabaseName());

        Products = database.GetCollection<Product>(databaseSettings.CollectionName());
    }
}