using System;
using System.Linq;
using BooksLibrarySystem.Models;
using BooksLibrarySystem.Web.Controls.ErrorSuccessNotifier;

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
			int bookId;

			if (!int.TryParse(this.RouteData.Values["id"].ToString(), out bookId))
			{
				ErrorSuccessNotifier.AddErrorMessage("Missing book id or book id is not a number");
				return;
			}

			Book book = this.data.Books.GetById(bookId);

			if (book == null)
			{
				ErrorSuccessNotifier.AddErrorMessage("Worng book id!");
				return;
			}

			if (book == null)
			{
				BooksLibrarySystem.Web.Controls.ErrorSuccessNotifier.ErrorSuccessNotifier.AddErrorMessage("Worng book id!");
				return;
			}

			this.book = book;
		}
	}
}