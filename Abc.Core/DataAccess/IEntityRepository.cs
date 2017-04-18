using Abc.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Abc.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()//generic olacağı için T için generic kısıtları koyuyoruz. dioruz ki gelen klaslar IEntity'den implement edilmiş olmalı. Bu sayede sadece db nesnesi gönderebiliriz.new lenmesini engellememiz için yani Ientity interfaceye gönderilmsin diyoruz. Abstract ve interfaceler de referanst tiplidir bu yüzden de class yerine gönderlmelerini new ile engelliyoruz.
    {
        T Get(Expression<Func<T, bool>> filter = null);
        //where id=1 gibi karşılık gelen tek nesne almak için.
        //int olabilir başka alan ile sorgulanabilir olabilir o yüzden kullanışlı olsun diye exp kullanıyoruz);
        //<Func<T, bool>> aslında filtremiz oluyor yani where c.Id= gibi
        //filter = null ise boş parametre, değer girilmezse ona göre çalışacak
        List<T> GetList(Expression<Func<T, bool>> filter = null);//Tüm listeyi döndürmek için T döndürecez ama olurda expresin gelirse ona göre datayı getir diyoruz. Hiç şart gönderilmezse hepsini getir.

        void Add(T entity);//Entity ver onu eklesin
        void Update(T entity);//Entity ver onu güncellesi n
        void Delete(T entity);//Entity ver onu silsin

    }
}
