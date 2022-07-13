using System;
using System.Collections.Generic;
using System.Linq;
using NC_Models;
using NC_Models.Common;
using System.Linq;
using Xunit;

namespace NC_DLRepositories.Tests
{
    public class DLProductsRepoTests
    {
        IDLProductsRepo dlRepo;

        Product? product = new Product
        {
            Name = "New Product",
            Price = 100,
            Status = (int)StatusEnm.Active
        };

        #region Tests in Memory

        [Fact]
        public void AddProduct_Test_InMemory()
        {
            using (var ctx = DbContextFactory.Create(nameof(AddProduct_Test_InMemory)))
            {
                dlRepo = new DLProductsRepo(ctx);
                product.Id = dlRepo.AddProduct(product).Result;

                Product? savedProduct = dlRepo.GetProduct(product.Id).Result;
                Assert.Equal(product.Name, savedProduct.Name);
                Assert.Equal(product.Price, savedProduct.Price);
                Assert.Equal(product.Status, savedProduct.Status);
            }
        }

        [Fact]
        public void EditProduct_Test_InMemory()
        {
            using (var ctx = DbContextFactory.Create(nameof(EditProduct_Test_InMemory)))
            {
                dlRepo = new DLProductsRepo(ctx);
                product.Id = dlRepo.AddProduct(product).Result;

                Product? savedProduct = dlRepo.GetProduct(product.Id).Result;
                savedProduct.Name = "New Prod";
                savedProduct.Price = 200;
                savedProduct.Status = (int)StatusEnm.Removed;
                dlRepo.EditProduct(savedProduct);

                Product? editedProduct = dlRepo.GetProduct(savedProduct.Id).Result;
                Assert.Equal(editedProduct.Name, savedProduct.Name);
                Assert.Equal(editedProduct.Price, savedProduct.Price);
                Assert.Equal(editedProduct.Status, savedProduct.Status);
            }
        }

        [Fact]
        public void DeleteProduct_Test_InMemory()
        {
            using (var ctx = DbContextFactory.Create(nameof(DeleteProduct_Test_InMemory)))
            {
                dlRepo = new DLProductsRepo(ctx);
                product.Id = dlRepo.AddProduct(product).Result;

                dlRepo.DeleteProduct(product.Id);

                Product? editedProduct = dlRepo.GetProduct(product.Id).Result;
                Assert.Null(editedProduct);
            }
        }

        [Fact]
        public void GetProduct_Test_InMemory()
        {
            using (var ctx = DbContextFactory.Create(nameof(GetProduct_Test_InMemory)))
            {
                dlRepo = new DLProductsRepo(ctx);
                product.Id = dlRepo.AddProduct(product).Result;

                Product? savedProduct = dlRepo.GetProduct(product.Id).Result;

                Assert.Equal(product.Name, savedProduct.Name);
                Assert.Equal(product.Price, savedProduct.Price);
                Assert.Equal(product.Status, savedProduct.Status);
            }
        }

        [Fact]
        public void GetAllProduct_Test_InMemory()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Name = "New Product 1",
                    Price = 100,
                    Status = (int)StatusEnm.Active
                },
                new Product()
                {
                    Name = "New Product 2",
                    Price = 200,
                    Status = (int)StatusEnm.Inactive
                }
            };
            using (var ctx = DbContextFactory.Create(nameof(GetAllProduct_Test_InMemory)))
            {
                dlRepo = new DLProductsRepo(ctx);
                foreach (Product prod in products)
                {
                    prod.Id = dlRepo.AddProduct(prod).Result;
                }

                List<Product> result = dlRepo.GetAllProducts().Result;
                Assert.Equal(products.Count, result.Count);

                foreach (Product prod in result)
                {
                    Assert.Contains(prod.Id, products.Select(x => x.Id));
                    Assert.Contains(prod.Name, products.Select(x => x.Name));
                }
            }
        }
    }

    #endregion

}

