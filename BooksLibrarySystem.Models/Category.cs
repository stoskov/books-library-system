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

		[MaxLength(50)]
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