using NC_Models.Common;

namespace NC_Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public decimal Price { get; set; } = 0;
        public byte Status { get; set; } = (byte)StatusEnm.Active;
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }
}