using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.MvcUI.Models
{
    public class CategoryListVM
    {
        public List<Category> Categories { get; internal set; }
    }
}
