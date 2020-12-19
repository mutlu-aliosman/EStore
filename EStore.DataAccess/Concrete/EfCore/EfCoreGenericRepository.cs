using EStore.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EStore.DataAccess.Concrete.EfCore
{
    public class EfCoreGenericRepository<T, TContext> : IRepository<T>
         where T : class
         where TContext : DbContext, new()
    {
        public void Create(T entity)
        {
            using (var db = new TContext())
            {
                db.Set<T>().Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var db = new TContext())
            {
                db.Set<T>().Remove(entity);
                db.SaveChanges();
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter=null)
        {
            using (var db = new TContext())
            {
                return filter == null
                     ? db.Set<T>().ToList()
                     : db.Set<T>().Where(filter).ToList();
            }
        }

        public T GetById(int id)
        {
            using (var db = new TContext())
            {
                return db.Set<T>().Find(id);
            }
        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            using (var db = new TContext())
            {
                return db.Set<T>().Where(filter).SingleOrDefault();
            }
        }

        public void Update(T entity)
        {
            using (var db = new TContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
