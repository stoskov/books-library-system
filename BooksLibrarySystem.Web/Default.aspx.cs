using System;
using System.Linq;
using BooksLibrarySystem.Web.ViewModels;

namespace BooksLibrarySystem.Web
{
	public partial class Default : BooksLibrarySystemPage
	{
		protected void Page_PreRender(object sender, EventArgs e)
		{
			var allCategories = (from c in this.data.Categories.All().OrderByDescending(c => c.Books.Count)
								 select new CategorySummaryViewModel
								 {
									 CategoryId = c.CategoryId,
									 Name = c.Name,
									 TotalBooksCount = c.Books.Count(),
									 Books = (from b in c.Books
											  select new BookSummaryViewModel
											  {
												  Authors = b.Authors,
												  BookId = b.BookId,
												  Title = b.Title
											  }).Take(50).ToList()
								 }).Take(90).ToList();

			this.ListViewCategories.DataSource = allCategories;
			this.DataBind();
		}

		protected void LinkButtonSearch_Click(object sender, EventArgs e)
		{
			this.Response.Redirect("~/Search?q=" + this.TextBoxSearch.Text);
		}
	}
}