using Abc.Core.DataAccess.EntitFramework;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Northwind.DataAccess.Concrete.Entitframework
{//Bu arkadaşımız entityframewok kullanacak bu yüzden EfEntityRepositryBase  ve bir veri nesnesi+context kullanacak. ayrıca kendisi IProductdal kullanacak çünkü bll ve iş kkatmanı bu nesne uzerinden iletişim kuracaktır.
    public class EfProductDal:EfEntityRepositryBase<Product,NorthwindContext>,IProductDal
    {
        //artık update delete create get vs sorgularımız hazır duruma geldi.
    }
}
