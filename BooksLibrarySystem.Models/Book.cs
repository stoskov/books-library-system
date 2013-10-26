using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BooksLibrarySystem.Models
{
	public class Book
	{
		public int BookId { get; set; }

		[MaxLength(100)]
		public string Title { get; set; }

		[MaxLength(100)]
		public string Authors { get; set; }

		[MaxLength(20)]
		public string ISBN { get; set; }

		[MaxLength(100)]
		public string WebSite { get; set; }

		public int CategoryId { get; set; }

		[MaxLength(500)]
		public string Description { get; set; }

		public virtual Category Category { get; set; }
	}
}