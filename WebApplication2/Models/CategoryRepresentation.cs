using Newtonsoft.Json;

namespace WebApplication2.Models
{
    public class CategoryRepresentation
    {
        public CategoryRepresentation()
        {

        }
        public CategoryRepresentation(int categoryID, string name, string description)
        {
            this.CategoryID = categoryID;
            this.Name = name;
            this.Description = description;
            
        }

        [JsonProperty(PropertyName = "categoryId")]
        public int CategoryID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
