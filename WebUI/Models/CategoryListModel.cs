using Entity;
using System.Collections.Generic;

namespace WebUI.Models
{
    public class CategoryListModel
    {
        public string SelectedItem { get; set; }
        public List<Category> Categories { get; set; }
    }
}



