using Abc.Core.DataAccess.EntitFramework;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Northwind.DataAccess.Concrete.Entitframework
{
    public class EfCategoryDal:EfEntityRepositryBase<Category, NorthwindContext>,ICategoryDal
    {
    }
}
