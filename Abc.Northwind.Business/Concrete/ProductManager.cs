using Abc.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Abc.Northwind.Entities.Concrete;
using Abc.Northwind.DataAccess.Abstract;

namespace Abc.Northwind.Business.Concrete
{ //Solid prensipleri açısından burada EfProductDal newlenemez. Öyle bir durumda busines katmanı entityframeworke bağımlı hale gelir. O yüzden üst katman alt katmanı newleyemez.
    public class ProductManager : IProductService
    {
        //Veri erişim katmanındaki nesneye ulaşmak için dependency injection servisi kullanıcaz.
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)//ctor(constructer)
        {//Yani product manager neewlendıgınde product dal verecek.Çünkü EfProductDal da bir IProductDal'dır.
            _productDal = productDal;
        }
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {//veritabanına getlist üzerinden sorgumuzu gönderiyoruz.
            return _productDal.GetList(p => p.CategoryID == categoryId || categoryId == 0);
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { ProductID = productId });
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
