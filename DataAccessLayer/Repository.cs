using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DataAccessLayer {
	public class Repository<T> : IRepository<T> where T : class {
		// the database context
		protected DbContext context;
		// the collection of all entities within the given context
		protected DbSet<T> dbset;

		// Repository constructor taking a database for its DbContext
		// and setting its DbSet equal to the DbContext's set of collections
		public Repository(DbContext datacontext) {
			context = datacontext;
			dbset = context.Set<T>();
		}

		// Insert an entity into the repository in the disconnected state
		public void Insert(T entity) {
			context.Entry(entity).State = System.Data.Entity.EntityState.Added;
			context.SaveChanges();
		}

		// Delete an entity from the repository in the disconnected state
		public void Delete(T entity) {
			context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
			context.SaveChanges();
		}

		// Update an entity in the repository in the disconnected state
		public void Update(T entity) {
			context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
			context.SaveChanges();
		}

		// Get an entity from the dbset by Id
		public T GetById(int id) {
			return dbset.Find(id);
		}

		// Get a set of entities according to a predicate 
		public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate) {
			return dbset.Where(predicate);
		}

		// Return a list of all entities in the given repository
		public IEnumerable<T> GetAll() {
			return dbset.ToList();
		}

		// Uses a where expression to get a single entity
		public T GetSingle(Func<T, bool> where,
			params Expression<Func<T, object>>[] navigationProperties) {
			T item = null;
			IQueryable<T> dbQuery = context.Set<T>();
			foreach (Expression<Func<T, object>> navigationProperty
				in navigationProperties)
				dbQuery = dbQuery.Include<T, object>(navigationProperty);

			// The entity matching the where expression
			item = dbQuery.FirstOrDefault(where);

			// Return the entity
			return item;
		}
	}
}
