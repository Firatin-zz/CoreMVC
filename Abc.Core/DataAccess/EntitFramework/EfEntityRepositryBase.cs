using Abc.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Abc.Core.DataAccess.EntitFramework
{
    public class EfEntityRepositryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
        //1-EfEntityRepositryBase<TEntity, TContext>  alanı: ef kullanmak için iki şey lazım nesne ve context bizde sana bunu gönderecez ki kullan diyoruz.
        //2-where TEntity : class, IEntity, new() alanı:  kısıtlarımızdır, sana class gelecek, IENtityden türetilmiş olmalı ve newlenebilir türetilebilir nesne olmalı
        //3-where TContext : DbContext, new() alanı: DbContextten türeyen nesne olmalı, newlenebilir yani türetilebilir nesne olmalı
    {
        public TEntity Get(Expression<Func<TEntity, bool>> filter /* = null kaldırdık çünkü null değer gönderilemesin dioruz ama durabilir*/)
        {
            using (var context = new TContext())// bu kullanıma Idisposible denir.new ile gelen contexti newliyoruz.
            {
                return context.Set<TEntity>().SingleOrDefault(filter);//filteri dikkate alarak sana gönderilen TEntity nesnesindeki değerin ilkini(SingleOrDefault) döndür
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return filter == null //filtre nul ise
                    ? context.Set<TEntity>().ToList() //o zaman TEntity gibi bir sorgu oluştur
                    : context.Set<TEntity>().Where(filter).ToList();// nul değilse filtreli sorguyu çağır
            }
        }
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);//entry gelen entity olacak, nesneyi set edicez
                addedEntity.State = EntityState.Added;//burdada gelen nesneyi eklenecek olarak yakala
                context.SaveChanges();//ve kaydet

            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;//gelen nesneyi değiştir
                context.SaveChanges();

            }
        }
        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }
    }
}
