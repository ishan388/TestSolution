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
        private IServiceProvider ServicesProvider { get; set; }
        private Mock<IDLProductsRepo> mockDLRepo = new Mock<IDLProductsRepo>();
        private BLProductsRepo blRepo;

        public BLProductsRepoTests()
        {
            ServicesProvider = DependencySetupFixture.ConfigureDependencies();
        }

        [Test]
        public void AddProduct_Test()
        {
            int expected = 1003;
            mockDLRepo.Setup(svc => svc.AddProduct(It.IsAny<ProductVM>())).ReturnsAsync(expected);
            blRepo = new BLProductsRepo(mockDLRepo.Object);
            int result = blRepo.AddProduct(It.IsAny<ProductVM>()).Result.Data;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetAllProducts_Test()
        {
            List<Product>? response = new List<Product>()
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

            mockDLRepo.Setup(svc => svc.GetAllProducts()).ReturnsAsync(response);
            blRepo = new BLProductsRepo(mockDLRepo.Object);
            List<ProductVM>? expected = response.Select(res => new ProductVM(res)).ToList();
            List<ProductVM>? result = blRepo.GetAllProducts().Result.DataList;

            Func<ProductVM, object> selector = o => new { o.Id, o.Name };
            Assert.That(result.Select(selector), Is.EquivalentTo(expected.Select(selector)));
        }

        [Test]
        public void GetProductsById_Test()
        {
            ProductVM expected = new ProductVM()
            {
                Id = 1,
                Name = "Prod 1",
                Price = 25.50m,
                Status = 1
            };

            mockDLRepo.Setup(svc => svc.GetProduct(It.IsAny<int>())).ReturnsAsync(expected);
            blRepo = new BLProductsRepo(mockDLRepo.Object);
            ProductVM? result = blRepo.GetProduct(expected.Id).Result.Data;

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Name, result.Name);
        }

        [Test]
        public void EditProduct_Test()
        {
            ProductVM request = new ProductVM()
            {
                Id = 1,
                Name = "Prod 1",
                Price = 25.50m,
                Status = 1
            };

            ProductVM expected = new ProductVM()
            {
                Id = 1,
                Name = "Prod 5",
                Price = 50.50m,
                Status = 1
            };

            mockDLRepo.Setup(svc => svc.EditProduct(expected)).ReturnsAsync(1);
            blRepo = new BLProductsRepo(mockDLRepo.Object);
            int resultId = blRepo.EditProduct(expected).Result.Data;
            ProductVM result = blRepo.GetProduct(expected.Id).Result.Data;

            Assert.AreEqual(result.Id, request.Id);
            Assert.AreNotEqual(result.Name, request.Name);
        }
    }
}