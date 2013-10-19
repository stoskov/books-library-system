using System;
using System.Linq;

namespace BooksLibrarySystem.Web.ViewModels
{
	public class BookSearchViewModel
	{
		public int BookId { get; set; }

		public string Title { get; set; }

		public string Authors { get; set; }

		public int CategoryId { get; set; }

		public string CategoryName { get; set; }

		public int Relevance { get; set; }
	}
}