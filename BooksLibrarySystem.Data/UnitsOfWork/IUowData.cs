using System;
using System.Linq;
using BooksLibrarySystem.Data.Repositories;
using BooksLibrarySystem.Models;

namespace BooksLibrarySystem.Data.UnitsOfWork
{
	public interface IUowData
	{
		IRepository<Category> Categories { get; }

		IRepository<Book> Books { get; }

		int SaveChanges();
	}
}