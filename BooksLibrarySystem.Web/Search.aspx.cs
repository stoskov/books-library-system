using System;
using System.Collections.Generic;
using System.Linq;
using BooksLibrarySystem.Models;

namespace BooksLibrarySystem.Web
{
	public partial class Search : BooksLibrarySystemPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string query = this.Request.Params["q"];

			if (query == null)
			{
				query = string.Empty;
			}

			this.LiteralQuery.Text = query;
			List<Book> books = this.data.Books.All()
								   .Where(b => b.Title.Contains(query) || b.Authors.Contains(query))
								   .OrderBy(b => b.Title)
								   .ToList();

			this.RepeaterSearchResult.DataSource = books;
			this.DataBind();
		}
	}
}