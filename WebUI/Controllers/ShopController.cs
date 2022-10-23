using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ShopController : Controller
    {
        IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Details(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails((int)id);
            if (product==null)
            {
                return NotFound();
            }
            return View(new ProductDetailsModel()
            {
                Product = product,
                Categories=product.ProductCategories.Select(i=>i.Category).ToList()
            });
        }

        public IActionResult List(string category , int page=1)
        {
            const int pageSize = 3;
            return View(new ProductListModel()
            {
                PageInfo = new PageInfo()
                {
                    TotalItems=_productService.GetCountByCategory(category),
                    CurrentPage =page,
                    ItemsPerPage=pageSize,
                    CurrentCategory=category
                },
                Products = _productService.GetProductsByCategory(category,page,pageSize)
            });
        }
    }
}
