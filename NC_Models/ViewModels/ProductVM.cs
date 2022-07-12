using NC_Models.Common;

namespace NC_Models.ViewModels
{
    public class ProductVM : Product
    {
        public ProductVM()
        {

        }

        public ProductVM(Product product)
        {
            if (product != null)
            {
                Id = product.Id;
                Name = product.Name;
                Price = product.Price;
                Status = product.Status;
                StatusName = ((StatusEnm)product.Status).ToString();
                CreatedDateTime = product.CreatedDateTime;
                ModifiedDateTime = product.ModifiedDateTime;
            }
        }
        public string? StatusName { get; set; } = String.Empty;
    }
}
