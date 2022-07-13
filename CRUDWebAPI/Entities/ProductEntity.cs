namespace CRUDWebAPI.Entities;

using System.Text.Json.Serialization;


    public class ProductEntity
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductCount { get; set; }

    }

