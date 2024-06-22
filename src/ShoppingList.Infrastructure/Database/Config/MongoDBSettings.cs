using Microsoft.Extensions.Configuration;
using ShoppingList.Domain.Contracts.DatabaseConfig;

namespace ShoppingList.Infrastructure.Database.Config;

public class MongoDBSettings(IConfiguration configuration) : IDatabaseConfiguration
{
    public string CollectionName()
    {
        return configuration["MongoDB:CollectionName"]!;
    }

    public string ConnectionURI()
    {
        return configuration["MongoDB:ConnectionURI"]!;
    }

    public string DatabaseName()
    {
        return configuration["MongoDB:DatabaseName"]!;
    }
}