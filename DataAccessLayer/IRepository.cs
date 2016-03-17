using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer {
	public interface IRepository<T> {
		// Insert an entity into the repository
		void Insert(T entity);
		// Delete an entity from the repository
		void Delete(T entity);
		// Update an entity in the repository
		void Update(T entity);
		// Get an entity from the repository by its Id
		T GetById(int id);
		// Search for one or more entities according to a predicate expression
		IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
		// Get all entities from a repository
		IEnumerable<T> GetAll();
		// Get a single entity from a repository based on a where expression
		T GetSingle(Func<T, bool> where,
			params Expression<Func<T, object>>[] navigationProperties);
	}
}