using Newtonsoft.Json;

namespace WebApplication2.Models
{
    public class ProductRepresentation
    {
        public ProductRepresentation(int productID, string name, string description, decimal price, decimal basePrice , int categoryId, string filename)
        {
            this.ProductID = productID;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.BasePrice = basePrice;
            this.CategoryID = categoryId;
            this.FileName = filename;
        }

        [JsonProperty(PropertyName = "productId")]
        public int ProductID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "basePrice")]
        public decimal BasePrice { get; set; }
        [JsonProperty(PropertyName = "categoryId")]
        public int CategoryID { get; set; }

        [JsonProperty(PropertyName = "filename")]
        public string FileName { get; set; }
    }
}
