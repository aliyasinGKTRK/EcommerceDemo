using Entity;
using System.Collections.Generic;

namespace WebUI.Models
{
    public class ProductDetailsModel
    {
        public Product  Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
