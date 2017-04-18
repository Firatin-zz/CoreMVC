using Abc.Northwind.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Abc.Northwind.DataAccess.Concrete.Entitframework
{
    public class NorthwindContext : DbContext
    {//Veritabanını sorguladıgımız arayüz gibi varsayılabilir. Mapping işlemleride burda yapılabilir()
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connectionstring NOT: yüklenmesi gereken Microsoft.EntityFrameworkCore.SqlServer
            optionsBuilder.UseSqlServer("Server=.;Database=NORTHWND;Trusted_Connection=True;");
            //UseSqlServer: enetityframework core implementasyonu olarak geldi.
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
