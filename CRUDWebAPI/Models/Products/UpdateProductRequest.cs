namespace CRUDWebAPI.Models.Products
{
    public class UpdateProductRequest
    {
        public string? ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int ProductCount { get; set; }
    }
}
