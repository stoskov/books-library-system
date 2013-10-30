using System;
using System.Linq;

namespace BooksLibrarySystem.Data.Repositories
{
	public interface IRepository<T> where T : class
	{
		IQueryable<T> All();

		T GetById(int id);

		T GetById(string id);

		void Add(T entity);

		void Update(T entity);

		void Delete(T entity);

		void Delete(int id);

		void Detach(T entity);

		void Reload(T entry);
	}
}