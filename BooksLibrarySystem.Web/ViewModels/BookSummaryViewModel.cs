using System;
using System.Linq;

namespace BooksLibrarySystem.Web.ViewModels
{
	public class BookSummaryViewModel
	{
		public int BookId { get; set; }

		public string Title { get; set; }

		public string Authors { get; set; }
	}
}