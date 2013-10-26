using System;
using System.Linq;
using BooksLibrarySystem.Models;

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
			int categoryId = Convert.ToInt32(this.Request.QueryString["id"]);

			Category category = this.data.Categories.GetById(categoryId);

			if (category == null)
			{
				BooksLibrarySystem.Web.Controls.ErrorSuccessNotifier.ErrorSuccessNotifier.AddErrorMessage("Worng category id!");
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