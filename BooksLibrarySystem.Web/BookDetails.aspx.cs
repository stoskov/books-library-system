using System;
using System.Linq;
using BooksLibrarySystem.Models;
using BooksLibrarySystem.Web.ViewModels;

namespace BooksLibrarySystem.Web
{
	public partial class BookDetails : LibrarySystemPage
	{
		public BookViewModel Book = new BookViewModel();

		protected void Page_Load(object sender, EventArgs e)
		{
			int bookId = Convert.ToInt32(this.Request.Params["id"]);

			Book book = this.data.Books.GetById(bookId);

			if (book == null)
			{
				BooksLibrarySystem.Web.Controls.ErrorSuccessNotifier.ErrorSuccessNotifier.AddErrorMessage("Worng book id!");
				return;
			}

			var bookViewModel = new BookViewModel()
			{
				BookId = book.BookId,
				Title = book.Title,
				Authors = book.Authors,
				ISBN = book.ISBN,
				CategoryName = book.Category.Name,
				WebSite = book.WebSite,
				Description = book.Description
			};

			this.Book = bookViewModel;
		}
	}
}