using NC_DLRepositories;
using NC_Models.Common;
using NC_Models.ViewModels;

namespace NC_BLRepositories
{
    public class BLProductsRepo : IBLProductsRepo
    {
        private IDLProductsRepo dlRepo;

        public BLProductsRepo(IDLProductsRepo _dlRepo)
        {
            dlRepo = _dlRepo;
        }

        public Task<Response<int>> AddProduct(ProductVM product)
        {
            Response<int> res = new Response<int>();
            try
            {
                res.Data = dlRepo.AddProduct(product).Result;
                res.IsSuccess = true;
                res.Message = "Product Added Successfully";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Some Error While Adding Product: " + ex.Message;
            }
            return Task.FromResult(res);
        }

        public Task<Response<int>> DeleteProduct(int productId)
        {
            Response<int> res = new Response<int>();
            try
            {
                res.Data = dlRepo.DeleteProduct(productId).Result;
                res.IsSuccess = true;
                res.Message = "Product Deleted Successfully";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Some Error While Deleting Product: " + ex.Message;
            }
            return Task.FromResult(res);
        }

        public Task<Response<int>> EditProduct(ProductVM product)
        {
            Response<int> res = new Response<int>();
            try
            {
                res.Data = dlRepo.EditProduct(product).Result;
                res.IsSuccess = true;
                res.Message = "Product Updated Successfully";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Some Error While Updating Product: " + ex.Message;
            }
            return Task.FromResult(res);
        }

        public Task<Response<ProductVM>> GetAllProducts()
        {
            Response<ProductVM> res = new Response<ProductVM>();
            try
            {
                res.IsSuccess = true;
                res.Message = "Products list fetched successfully";
                res.DataList = dlRepo.GetAllProducts().Result
                    .Select(res => new ProductVM(res))
                    .ToList();
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Some Error While Fetching All Products: " + ex.Message;
            }
            return Task.FromResult(res);
        }

        public Task<Response<ProductVM>> GetProduct(int productId)
        {
            Response<ProductVM> res = new Response<ProductVM>();
            try
            {
                res.IsSuccess = true;
                res.Message = "Product fetched successfully";
                res.Data = new ProductVM(dlRepo.GetProduct(productId).Result);
                if (res.Data?.Id == 0)
                    res.Message = "Invalid Product";

            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Some Error While Fetching Single Product: " + ex.Message;
            }
            return Task.FromResult(res);
        }
    }
}
