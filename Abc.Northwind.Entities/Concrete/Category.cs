using Abc.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Northwind.Entities.Concrete
{
    public class Category: IEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
