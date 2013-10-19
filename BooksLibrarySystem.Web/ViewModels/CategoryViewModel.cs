using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksLibrarySystem.Web.ViewModels
{
	public class CategoryViewModel
	{
		public string Name { get; set; }

		public int TotalBooksCount { get; set; }

		public ICollection<BookViewModel> Books { get; set; }
	}
}