using System;
using System.Collections.Generic;
using System.Linq;
using BooksLibrarySystem.Models;

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