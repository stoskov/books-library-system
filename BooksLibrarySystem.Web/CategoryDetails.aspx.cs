using System;
using System.Linq;
using BooksLibrarySystem.Models;
using BooksLibrarySystem.Web.Controls.ErrorSuccessNotifier;

namespace BooksLibrarySystem.Web
{
	public partial class CategoryDetails : BooksLibrarySystemPage
	{
		private Category category = new Category();

		public Category Category
		{
			get
			{
				return this.category;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			int categoryId;

			if (!int.TryParse(this.RouteData.Values["id"].ToString(), out categoryId))
			{
				ErrorSuccessNotifier.AddErrorMessage("Missing category id or category id is not a number");
				return;
			}

			Category category = this.data.Categories.GetById(categoryId);

			if (category == null)
			{
				ErrorSuccessNotifier.AddErrorMessage("Worng category id!");
				return;
			}

			this.category = category;
		}

		public IQueryable<Book> GridViewBooks_GetData()
		{
			if (this.category == null)
			{
				return null;
			}

			return this.category.Books.AsQueryable();
		}
	}
}