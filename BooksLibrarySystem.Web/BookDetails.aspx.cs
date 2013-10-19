using System;
using System.Collections.Generic;
using System.Linq;
using BooksLibrarySystem.Models;

namespace BooksLibrarySystem.Web
{
	public partial class BookDetails : LibrarySystemPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			int bookId = Convert.ToInt32(this.Request.Params["id"]);

			Book book = this.data.Books.GetById(bookId);
			List<Book> booksDataSource = new List<Book>();
			booksDataSource.Add(book);

			if (book == null)
			{
				BooksLibrarySystem.Web.Controls.ErrorSuccessNotifier.ErrorSuccessNotifier.AddErrorMessage("Worng book id!");
				return;
			}

			this.RepeaterBookDetails.DataSource = booksDataSource;
			this.DataBind();
		}
	}
}