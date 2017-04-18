using Abc.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace Abc.Northwind.Business.Abstract
{
    public interface IProductService//Hangi operasyonları servis edeceksek onları burda yazıyoruz. BurdaIentityrepo kullanmama sebebimiz hepsini kullanmayacak olmamız. Ayrıca buraya kural koyulabilir.
    {
        List<Product> GetAll();
        List<Product> GetByCategory(int categoryId);
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId);
    }
}
