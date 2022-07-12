using NC_Models.Common;
using NC_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_BLRepositories
{
    public interface IBLProductsRepo
    {
        Task<Response<ProductVM>> GetAllProducts();
        Task<Response<ProductVM>> GetProduct(int productId);
        Task<Response<int>> AddProduct(ProductVM product);
        Task<Response<int>> EditProduct(ProductVM product);
        Task<Response<int>> DeleteProduct(int productId);
    }
}
