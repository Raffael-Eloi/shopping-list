using FluentAssertions;
using ShoppingList.Application.Models;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Tetsts.Mappers;

internal class ProductMapperShould
{
    [Test]
    public void Map_Name()
    {
		#region Arrange(Given)

		string name = "Product Name";

        var product = new Product
        {
            Name = name,
        };

        IProductMapper mapper = new ProductMapper();

        #endregion

        #region Act(When)

        GetProductResponse response = ProductMapper.Map(product);

        #endregion

        #region Assert(Then)

        response.Should().NotBeNull();

        response.Name.Should().Be(name);

        #endregion
    }
}