﻿using ShoppingList.Application.Contracts.Mappers;
using ShoppingList.Application.Models;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Mappers;

public class ProductMapper : IProductMapper
{
    public GetProductResponse Map(Product product)
    {
        return new GetProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            Quantity = product.Quantity,
            CreatedAt = product.CreatedAt
        };
    }
}