using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BooksLibrarySystem.Models
{
	public class Book
	{
		public int BookId { get; set; }

		[Required]
		[Display(Name="Book Title")]
		[MaxLength(100, ErrorMessage="Book Title cannot be longer than 100 symbols.")]
		public string Title { get; set; }

		[Required]
		[Display(Name = "Authors")]
		[MaxLength(100, ErrorMessage = "Authors cannot be longer than 100 symbols.")]
		public string Authors { get; set; }

		[Display(Name = "ISBN")]
		[MaxLength(20, ErrorMessage = "ISBN cannot be longer than 100 symbols.")]
		public string ISBN { get; set; }

		[Display(Name = "Web Site")]
		[MaxLength(256, ErrorMessage = "Web Site cannot be longer than 256 symbols.")]
		public string WebSite { get; set; }

		public int CategoryId { get; set; }

		[Display(Name = "Book Description")]
		[MaxLength(1000, ErrorMessage = "Book Description cannot be longer than 1000 symbols.")]
		public string Description { get; set; }

		public virtual Category Category { get; set; }
	}
}