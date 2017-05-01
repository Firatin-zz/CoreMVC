using Abc.Northwind.Business.Abstract;
using Abc.Northwind.MvcUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
        public ActionResult Index(int page = 1, int category = 0)
        {
            int pageSize = 10;
            //var products = _productService.GetAll();//
            var products = _productService.GetByCategory(category);

            ProductListVM model = new ProductListVM
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),//diyoruz ki: varsayılan pagigng 1 ve sıralama pagesize değeri kadar olsun. Bu işlem örn param 2 geldi 2-1*10=10 yani ilk 10 ürünü atla


                //Taghelper imizi yazıyoruz.
                PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),//gelen değeri double ile ondalıklı tutup ceiling ile yukarı yuvarlıyoruz.
                PageSize = pageSize,
                CurrentCategory = category,
                CurrentPage = page
                //Taghelper end
            };

            return View(model);
        }
    }
}
