﻿using System;
using System.Linq;

namespace BooksLibrarySystem.Web.ViewModels
{
	public class BookViewModel
	{
		public int BookId { get; set; }

		public string Title { get; set; }

		public string Authors { get; set; }

		public string ISBN { get; set; }

		public string WebSite { get; set; }

		public string CategoryName { get; set; }

		public string Description { get; set; }
	}
}