using Abc.Northwind.Business.Abstract;
using Abc.Northwind.MvcUI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Abc.Northwind.MvcUI.Controllers
{
    public class ProductController : Controller
    {        //Solidin D'si gereği burda ProductManager çağıramıyoruz. Bunun yerine IProductService ile iletişim kurucaz.
        private IProductService _productService;//Dependency İnjection!!!

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index()
        {
            var products = _productService.GetAll();

            ProductListVM model = new ProductListVM
            {
                Products = products
            };

            return View(model);
        }
    }
}
