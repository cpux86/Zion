using Application.Features.Catalog.ProductFeatures.Commandes.AddProduct;
using ApplicationTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationTests.Features.Catalog.ProductFeatures.Commands
{
    public class AddProductHadlerTest : TestCommandBase
    {
        [Theory]
        [InlineData("Продукт 1", 3, 200)]
        [InlineData("Продукт 2", 3, 300)]
        [InlineData("Продукт 3", 3, 500)]
        public async void AddProduct(string product, long catId, decimal price)
        {
            var handler = new AddProductHandler(Context);
            var productId = await handler.Handle(new AddProductCommand
            {
                Name = product,
                CategoryId = catId,
                Price = price
            },
            CancellationToken.None);
            Assert.True(productId > 0);
        }
    }
}
