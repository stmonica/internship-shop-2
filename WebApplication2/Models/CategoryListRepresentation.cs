﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Domain;

namespace WebApplication2.Models
{
    public class CategoryListRepresentation
    {
        public CategoryListRepresentation(List<Category> categories)
        {
            this.Categories = categories.Select(x => new CategoryRepresentation(x.CategoryID, x.Name, x.Description)).ToList();
        }

        [JsonProperty(PropertyName = "categories")]
        public List<CategoryRepresentation> Categories { get; set; }
    }
}
