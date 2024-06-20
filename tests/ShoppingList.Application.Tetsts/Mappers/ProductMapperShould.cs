using FluentAssertions;
using ShoppingList.Application.Models;
using ShoppingList.Domain.Entities;
using System.Xml.Linq;

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
}