using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.ViewComponents
{
    public class CategoryListComponent:ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryListComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            return View(new CategoryListModel()
            {
                SelectedItem = RouteData.Values["category"]?.ToString(),
                Categories = _categoryService.GetAll()
            }) ;
        }
    }
}
