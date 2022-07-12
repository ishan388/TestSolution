using NC_Models;
using Microsoft.EntityFrameworkCore;

namespace NC_DLRepositories
{
    public class DLProductsRepo : IDLProductsRepo
    {
        private MyShopContext dbCtx;

        public DLProductsRepo(MyShopContext ctx)
        {
            dbCtx = ctx;
        }

        public async Task<int> AddProduct(Product product)
        {
            Product newProduct = product;
            await dbCtx.Products.AddAsync(newProduct);
            await dbCtx.SaveChangesAsync();
            return newProduct.Id;
        }

        public async Task<int> DeleteProduct(int productId)
        {
            dbCtx.Products.Remove(GetProduct(productId).Result);
            return await dbCtx.SaveChangesAsync();
        }

        public async Task<int> EditProduct(Product product)
        {
            Product productToUpdate = GetProduct(product.Id).Result;
            productToUpdate.Status = product.Status;
            productToUpdate.ModifiedDateTime = DateTime.Now;
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            return await dbCtx.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await dbCtx.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await dbCtx.Products.Where(e => e.Id == productId).SingleOrDefaultAsync();
        }
    }
}
