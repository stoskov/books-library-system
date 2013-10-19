using System;
using System.Linq;

namespace BooksLibrarySystem.Models
{
	public class Book
	{
		public int BookId { get; set; }

		public string Title { get; set; }

		public string Authors { get; set; }

		public string ISBN { get; set; }

		public string WebSite { get; set; }

		public int CategoryId { get; set; }

		public string Description { get; set; }

		public virtual Category Category { get; set; }
	}
}