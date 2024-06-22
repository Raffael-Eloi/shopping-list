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
        #region UseCases

        container.RegisterType<AddProduct>().As<IAddProduct>();
        container.RegisterType<GetProduct>().As<IGetProduct>();
        
        #endregion

        #region Validators
        
        container.RegisterType<AddProductValidator>().As<IAddProductValidator>();
        container.RegisterType<GetProductValidator>().As<IGetProductValidator>();
        
        #endregion

        #region Mappers
        
        container.RegisterType<ProductMapper>().As<IProductMapper>();
        
        #endregion

        #region Repositories

        container.RegisterType<ProductRepository>().As<IProductRepository>();
        
        #endregion

        #region DatabaseConfig
        
        container.RegisterType<ProductContext>();
        container.RegisterType<MongoDBSettings>().As<IDatabaseConfiguration>();
        
        #endregion
    }
}