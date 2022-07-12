using NC_Models;
using NC_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_DLRepositories
{
    public interface IDLProductsRepo
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProduct(int productId);
        Task<int> AddProduct(Product product);
        Task<int> EditProduct(Product product);
        Task<int> DeleteProduct(int productId);

    }

    
}
