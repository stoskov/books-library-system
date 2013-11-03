using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BooksLibrarySystem.Data;
using BooksLibrarySystem.Data.Repositories;
using BooksLibrarySystem.Data.UnitsOfWork;
using BooksLibrarySystem.Models;

namespace BooksLibrarySystem.Data.UnitsOfWork
{
	public class UowData : IUowData
	{
		private readonly DbContext context;
		private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

		public UowData()
			: this(new BooksLibrarySystemContext())
		{
		}

		public UowData(DbContext context)
		{
			this.context = context;
		}

		public int SaveChanges()
		{
			return this.context.SaveChanges();
		}

		public void Dispose()
		{
			this.context.Dispose();
		}

		public IRepository<Category> Categories
		{
			get
			{
				return this.GetRepository<Category>();
			}
		}

		public IRepository<Book> Books
		{
			get
			{
				return this.GetRepository<Book>();
			}
		}

		private IRepository<T> GetRepository<T>() where T : class
		{
			if (!this.repositories.ContainsKey(typeof(T)))
			{
				var type = typeof(GenericRepository<T>);

				this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
			}

			return (IRepository<T>)this.repositories[typeof(T)];
		}
	}
}