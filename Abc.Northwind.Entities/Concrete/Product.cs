using Abc.Core.Entities;
namespace Abc.Northwind.Entities.Concrete
{
    public class Product:IEntity
    {
        public int ProdutID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
    }
}
