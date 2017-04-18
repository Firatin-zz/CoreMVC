using Abc.Core.DataAccess;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.DataAccess.Abstract
{
    public interface ICategoryDal: IEntityRepository<Category>//bu durumda repoda ne varsa buraya uygulanmış gibidir. Özel işlemleride burda yaparız. Custom operations for product
    {
    }
}
