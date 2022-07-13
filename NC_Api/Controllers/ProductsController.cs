using Microsoft.AspNetCore.Mvc;
using NC_BLRepositories;
using NC_Models.ViewModels;

namespace NC_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IBLProductsRepo blRepo;

        public ProductsController(IBLProductsRepo _blRepo)
        {
            blRepo = _blRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await blRepo.GetAllProducts().ConfigureAwait(false));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            return Ok(await blRepo.GetProduct(productId).ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductVM product)
        {
            return Ok(await blRepo.AddProduct(product).ConfigureAwait(false));
        }

        [HttpPut]
        public async Task<IActionResult> EditProduct([FromBody] ProductVM product)
        {
            return Ok(await blRepo.EditProduct(product).ConfigureAwait(false));
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            return Ok(await blRepo.DeleteProduct(productId).ConfigureAwait(false));
        }

    }
}