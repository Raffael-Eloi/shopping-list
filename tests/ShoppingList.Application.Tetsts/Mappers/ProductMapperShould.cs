using FluentAssertions;
using ShoppingList.Application.Contracts.Mappers;
using ShoppingList.Application.Mappers;
using ShoppingList.Application.Models;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Tetsts.Mappers;

internal class ProductMapperShould
{
    private IProductMapper mapper;
    
    private Product product;

    [SetUp]
    public void SetUp()
    {
        mapper = new ProductMapper();

        product = new Product();
    }

    [Test]
    public void Map_Id()
    {
		#region Arrange(Given)

		var id = Guid.NewGuid();
        product.Id = id;

        #endregion

        #region Act(When)

        GetProductResponse response = mapper.Map(product);

        #endregion

        #region Assert(Then)

        response.Should().NotBeNull();

        response.Id.Should().Be(id);

        #endregion
    }
    
    [Test]
    public void Map_Name()
    {
		#region Arrange(Given)

		string name = "Product Name";
        product.Name = name;

        #endregion

        #region Act(When)

        GetProductResponse response = mapper.Map(product);

        #endregion

        #region Assert(Then)

        response.Name.Should().Be(name);

        #endregion
    }
    
    [Test]
    public void Map_Price()
    {
		#region Arrange(Given)

		decimal price = 11L;
        product.Price = price;

        #endregion

        #region Act(When)

        GetProductResponse response = mapper.Map(product);

        #endregion

        #region Assert(Then)

        response.Price.Should().Be(price);

        #endregion
    }

    [Test]
    public void Map_Description()
    {
        #region Arrange(Given)

        string description = "Product Description";
        product.Description = description;

        #endregion

        #region Act(When)

        GetProductResponse response = mapper.Map(product);

        #endregion

        #region Assert(Then)

        response.Description.Should().Be(description);

        #endregion
    }

    [Test]
    public void Map_Quantity()
    {
        #region Arrange(Given)

        int quantity = 5;
        product.Quantity = quantity;

        #endregion

        #region Act(When)

        GetProductResponse response = mapper.Map(product);

        #endregion

        #region Assert(Then)

        response.Quantity.Should().Be(quantity);

        #endregion
    }
}