using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NC_DLRepositories;
using NC_Models;
using NC_Models.Common;
using NC_Models.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_BLRepositories.Tests
{
    public class BLProductsRepoTests
    {
        private BLProductsRepo blRepo;
        private Mock<IDLProductsRepo> mockDLRepo = new Mock<IDLProductsRepo>();
        ProductVM? product = new ProductVM
        {
            Name = "New Product",
            Price = 100,
            Status = (int)StatusEnm.Active,
            StatusName = "Active"
        };

        public BLProductsRepoTests()
        {
            blRepo = new BLProductsRepo(mockDLRepo.Object);
        }

        [Test]
        public void AddProduct_Test()
        {
            int expected = 101;
            mockDLRepo.Setup(svc => svc.AddProduct(product)).ReturnsAsync(expected);
            int result = blRepo.AddProduct(product).Result.Data;

            mockDLRepo.Verify(svc => svc.AddProduct(product));
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetAllProducts_Test()
        {
            List<Product>? products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Prod 1",
                    Price = 25.50m,
                    Status = 1
                },
                new Product()
                {
                    Id = 2,
                    Name = "Prod 2",
                    Price = 55m,
                    Status = 1
                }
            };

            mockDLRepo.Setup(svc => svc.GetAllProducts()).ReturnsAsync(products);
            List<ProductVM>? expected = products.Select(res => new ProductVM(res)).ToList();
            List<ProductVM>? result = blRepo.GetAllProducts().Result.DataList;

            Func<ProductVM, object> selector = o => new { o.Id, o.Name };
            Assert.That(result.Select(selector), Is.EquivalentTo(expected.Select(selector)));
            mockDLRepo.Verify(svc => svc.GetAllProducts());
        }

        [Test]
        public void GetProduct_Test()
        {
            product.Id = 101;
            mockDLRepo.Setup(svc => svc.GetProduct(product.Id)).ReturnsAsync(product);
            ProductVM? result = blRepo.GetProduct(product.Id).Result.Data;

            Assert.AreEqual(product.Name, result.Name);
            Assert.AreEqual(product.Price, result.Price);
            mockDLRepo.Verify(svc => svc.GetProduct(product.Id));
        }

        [Test]
        public void EditProduct_Test()
        {
            ProductVM expected = new ProductVM()
            {
                Id = 1,
                Name = "Prod 5",
                Price = 50.50m,
                Status = 1
            };

            mockDLRepo.Setup(svc => svc.EditProduct(expected)).ReturnsAsync(1);
            int resultId = blRepo.EditProduct(expected).Result.Data;
            mockDLRepo.Verify(svc => svc.EditProduct(expected));

            mockDLRepo.Setup(svc => svc.GetProduct(expected.Id)).ReturnsAsync(expected);
            ProductVM result = blRepo.GetProduct(expected.Id).Result.Data;

            Assert.AreEqual(result.Id, expected.Id);
            Assert.AreEqual(result.Name, expected.Name);
            Assert.AreEqual(result.Price, expected.Price);
            Assert.AreNotEqual(result.Name, product.Name);
            Assert.AreNotEqual(result.Price, product.Price);
        }

        [Test]
        public void DeleteProduct_Test()
        {
            product.Id = 101;
            mockDLRepo.Setup(svc => svc.DeleteProduct(product.Id)).ReturnsAsync(1);
            int resultId = blRepo.DeleteProduct(product.Id).Result.Data;
            mockDLRepo.Verify(svc => svc.DeleteProduct(product.Id));

            product = new ProductVM();
            mockDLRepo.Setup(svc => svc.GetProduct(product.Id)).ReturnsAsync(product);
            ProductVM? result = blRepo.GetProduct(product.Id).Result.Data;

            Assert.AreEqual(result.Name, product.Name);
            Assert.AreEqual(result.Price, product.Price);
        }

    }
}