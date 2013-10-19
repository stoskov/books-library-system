using System;
using System.Linq;

namespace BooksLibrarySystem.Web.ViewModels
{
	public class BookViewModel
	{
		public int BookId { get; set; }

		public string Title { get; set; }

		public string Authors { get; set; }
	}
}