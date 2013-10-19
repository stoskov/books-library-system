using System;
using System.Linq;
using BooksLibrarySystem.Models;

namespace BooksLibrarySystem.Web
{
	public partial class BookDetails : BooksLibrarySystemPage
	{
		private Book book = new Book();

		public Book Book
		{
			get
			{
				return this.book;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			int bookId = Convert.ToInt32(this.Request.Params["id"]);

			Book book = this.data.Books.GetById(bookId);

			if (book == null)
			{
				BooksLibrarySystem.Web.Controls.ErrorSuccessNotifier.ErrorSuccessNotifier.AddErrorMessage("Worng book id!");
				return;
			}

			this.book = book;
		}
	}
}