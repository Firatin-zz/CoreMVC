using Abc.Core.DataAccess;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>//bu durumda repoda ne varsa buraya uygulanmış gibidir. Özel işlemleride burda yaparız. Custom operations for product
    {
    }
}
