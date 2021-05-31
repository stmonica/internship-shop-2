
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Domain;

namespace WebApplication2.Models
{
    public class ProductListRepresentation
    {

        public ProductListRepresentation(List<Product> products)
        {
            this.Products = products.Select(x => new ProductRepresentation(x.ProductID, x.Name, x.Description, x.Price, x.BasePrice, x.CategoryID, x.FileName)).ToList();
        }

        [JsonProperty(PropertyName = "products")]
        public List<ProductRepresentation> Products { get; set; }
    }
}
