namespace CRUDWebAPI.Models.Products;

using System.ComponentModel.DataAnnotations;

public class ProductRequest
{

        [Required]
        public string? ProductName { get; set; }

        [Required]
        public int ProductPrice { get; set; }

        [Required]
        public int ProductCount { get; set; }

}

