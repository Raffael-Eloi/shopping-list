﻿using ShoppingList.Application.Models;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Tetsts.Mappers;

public class ProductMapper : IProductMapper
{
    public GetProductResponse Map(Product product)
    {
        return new GetProductResponse
        {
            Name = product.Name,
        };
    }
}