using NC_Models;
using NC_Models.Common;
using System.Linq;
using Xunit;

namespace NC_DLRepositories.Tests
{
    public class MyShopContextTests
    {
        [Fact]
        public void AddProductToSQLDb()
        {
            var product = new Product
            {
                Name = "New Product",
                Price = 100,
                Status = (int)StatusEnm.Active
            };
            using (var ctx = DbContextFactory.Create())
            {
                ctx.Products.Add(product);
                ctx.SaveChanges();
            }

            using (var ctx = DbContextFactory.Create())
            {
                Product? savedProduct = ctx.Products.Where(e => e.Id == product.Id).SingleOrDefault();
                Assert.Equal(product.Name, savedProduct.Name);
                Assert.Equal(product.Price, savedProduct.Price);
                Assert.Equal(product.Status, savedProduct.Status);
                ctx.Products.Remove(savedProduct);
                ctx.SaveChanges();
            }
        }

        [Fact]
        public void AddProductToMemoryDb()
        {
            var product = new Product
            {
                Name = "New Product",
                Price = 100,
                Status = (int)StatusEnm.Active
            };
            using (var ctx = DbContextFactory.Create(nameof(AddProductToMemoryDb)))
            {
                ctx.Products.Add(product);
                ctx.SaveChanges();
            }

            using (var ctx = DbContextFactory.Create(nameof(AddProductToMemoryDb)))
            {
                Product? savedProduct = ctx.Products.Where(e => e.Id == product.Id).SingleOrDefault();
                Assert.Equal(product.Name, savedProduct.Name);
                Assert.Equal(product.Price, savedProduct.Price);
                Assert.Equal(product.Status, savedProduct.Status);
            }
        }
    }
}