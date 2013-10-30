using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BooksLibrarySystem.Models
{
	public class Category
	{
		private ICollection<Book> books;

		public Category()
		{
			this.books = new HashSet<Book>();
		}

		public int CategoryId { get; set; }

		[Required]
		[Display(Name="Category Name")]
		[MaxLength(50, ErrorMessage = "Category Name cannot be longer than 50 symbols.")]
		public string Name { get; set; }

		public virtual ICollection<Book> Books
		{
			get
			{
				return this.books;
			}
			set
			{
				this.books = value;
			}
		}
	}
}