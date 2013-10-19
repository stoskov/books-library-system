using System;
using System.Collections.Generic;
using System.Linq;
using BooksLibrarySystem.Models;
using BooksLibrarySystem.Web.ViewModels;

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

			if (!this.IsPostBack)
			{
				this.TextBoxSearch.Text = query;
			}

			var books = this.GetSearchResult(query);
			this.RepeaterSearchResult.DataSource = books;
			this.DataBind();
		}

		protected void LinkButtonSearch_Click(object sender, EventArgs e)
		{
			this.Response.Redirect("~/Search?q=" + this.TextBoxSearch.Text);
		}

		private IEnumerable<BookSearchViewModel> GetSearchResult(string query)
		{
			var books = this.data.Books.All()
							.AsEnumerable()
							.Select(b => new BookSearchViewModel()
								   {
									   BookId = b.BookId,
									   CategoryId = b.CategoryId,
									   CategoryName = b.Category.Name,
									   Authors = b.Authors,
									   Title = b.Title,
									   Relevance = this.CalcualteRelecance(b, query)
								   })
							.Where(b => b.Relevance > 0)
							.OrderByDescending(b => b.Relevance)
							.ToList();

			return books;
		}

		private int CalcualteRelecance(Book book, string queryString)
		{
			var relevance = 0;
			var words = queryString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			var searchTarget = string.Format("{0}{1}{2}", book.Title, book.Authors, book.Description).ToLower();

			foreach (var word in words)
			{
				if (searchTarget.IndexOf(word.ToLower()) >= 0)
				{
					relevance ++;
				}
			}

			return relevance;
		}
	}
}