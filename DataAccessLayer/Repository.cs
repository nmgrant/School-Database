using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.Entity;

namespace DataAccessLayer {
    public class Repository<T> : IRepository<T> where T : class {
        protected DbContext context;
        protected DbSet<T> dbset;

        public Repository(DbContext datacontext) {
            context = datacontext;
            dbset = context.Set<T>();
        }

        public void Insert(T entity) {
            context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(T entity) {
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(T entity) {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public T GetById(int id) {
            return dbset.Find(id);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate) {
            return dbset.Where(predicate);
        }

        public IEnumerable<T> GetAll() {
            return dbset.ToList();
        }

        public T GetSingle(Func<T, bool> where,
           params Expression<Func<T, object>>[] navigationProperties) {
            T item = null;
            IQueryable<T> dbQuery = null;
            foreach (Expression<Func<T, object>> navigationProperty
               in navigationProperties)
                dbQuery = dbset.Include<T, object>(navigationProperty);

            item = dbQuery.AsNoTracking().FirstOrDefault(where);
            return item;
        }
    }
}
