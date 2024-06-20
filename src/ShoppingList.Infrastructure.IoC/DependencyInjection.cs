using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Application.Contracts.UseCases;
using ShoppingList.Application.Contracts.Validators;
using ShoppingList.Application.UseCases;
using ShoppingList.Application.Validators;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Infrastructure.Repositories;

namespace ShoppingList.Infrastructure.IoC;

public static class DependencyInjection
{
    public static void AddDependencies(this ContainerBuilder container)
    {
        container.RegisterType<AddProduct>().As<IAddProduct>();
        container.RegisterType<ProductRepository>().As<IProductRepository>();
        container.RegisterType<AddProductValidator>().As<IAddProductValidator>();
    }
}