using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksLibrarySystem.Web.ViewModels
{
	public class CategoryViewModel
	{
		public int CategoryId { get; set; }

		public string Name { get; set; }

		public int TotalBooksCount { get; set; }

		public ICollection<BookSummaryViewModel> Books { get; set; }
	}
}