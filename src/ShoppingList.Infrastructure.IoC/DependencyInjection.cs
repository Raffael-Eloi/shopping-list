using Autofac;
using ShoppingList.Application.Contracts.Mappers;
using ShoppingList.Application.Contracts.UseCases;
using ShoppingList.Application.Contracts.Validators;
using ShoppingList.Application.Mappers;
using ShoppingList.Application.UseCases;
using ShoppingList.Application.Validators;
using ShoppingList.Domain.Contracts.DatabaseConfig;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Infrastructure.Database.Config;
using ShoppingList.Infrastructure.Database.Contexts;
using ShoppingList.Infrastructure.Repositories;

namespace ShoppingList.Infrastructure.IoC;

public static class DependencyInjection
{
    public static void AddDependencies(this ContainerBuilder container)
    {
        container.RegisterType<AddProduct>().As<IAddProduct>();
        container.RegisterType<ProductRepository>().As<IProductRepository>();
        container.RegisterType<AddProductValidator>().As<IAddProductValidator>();
        container.RegisterType<ProductContext>();
        container.RegisterType<MongoDBSettings>().As<IDatabaseConfiguration>();
        container.RegisterType<GetProduct>().As<IGetProduct>();
        container.RegisterType<GetProductValidator>().As<IGetProductValidator>();
        container.RegisterType<ProductMapper>().As<IProductMapper>();
    }
}