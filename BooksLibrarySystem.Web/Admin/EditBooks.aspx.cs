using System;
using System.Linq;
using System.Web.UI.WebControls;
using BooksLibrarySystem.Models;

namespace BooksLibrarySystem.Web.Admin
{
	public partial class EditBooks : BooksLibrarySystemPage
	{
		private const int MaxLabelLength = 20;
		private const string ShortenLabelSymbols = "...";

		private int? currentBookId;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.currentBookId = (int?)this.ViewState["currentBookId"];
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			this.DataBind();
		}

		public IQueryable<Book> GridViewBooks_GetData()
		{
			return this.data.Books.All();
		}

		public IQueryable<Category> GridViewCategories_GetData()
		{
			return this.data.Categories.All();
		}

		protected void LinkButtonCreateNew_Click(object sender, EventArgs e)
		{
			this.OpenCreateMode();
		}

		protected void LinkButtonCreate_Click(object sender, EventArgs e)
		{
			string title = this.TextBoxBookCreateTitle.Text;
			string authors = this.TextBoxBookCreateAuthors.Text;
			string isbn = this.TextBoxBookCreateISBN.Text;
			string webSite = this.TextBoxBookCreateWebSite.Text;
			string description = this.TextTextBoxBookCreateDescription.Text;
			int categoryId = Convert.ToInt32(this.DropDownListBookCreateCategory.SelectedValue);

			if (this.ValidateBookTitle(title) | this.ValidateBookAuthors(authors))
			{
				Book book = new Book()
				{
					Title = title,
					CategoryId = categoryId,
					Authors = authors,
					ISBN = isbn,
					WebSite = webSite,
					Description = description
				};

				this.data.Books.Add(book);
				this.data.SaveChanges();

				this.CloseAllModes();
			}
		}

		protected void LinkButtonEditBook_Command(object sender, CommandEventArgs e)
		{
			int bookId = Convert.ToInt32(e.CommandArgument);
			this.SetBookId(bookId);
			this.OpenEditMode();
		}

		protected void LinkButtonEdit_Click(object sender, EventArgs e)
		{
			string title = this.TextBoxBookEditTitle.Text;
			string authors = this.TextBoxBookEditAuthors.Text;
			string isbn = this.TextBoxBookEditISBN.Text;
			string webSite = this.TextBoxBookEditWebSite.Text;
			string description = this.TextTextBoxBookEditDescription.Text;
			int categoryId = Convert.ToInt32(this.DropDownListBookEditCategory.SelectedValue);

			if (this.ValidateBookTitle(title) | this.ValidateBookAuthors(authors))
			{
				Book book = this.data.Books.GetById((int)this.currentBookId);
				book.Title = title;
				book.CategoryId = categoryId;
				book.Authors = authors;
				book.ISBN = isbn;
				book.WebSite = webSite;
				book.Description = description;

				this.data.Books.Update(book);
				this.data.SaveChanges();

				this.CloseAllModes();
			}
		}

		protected void LinkButtonDeleteBook_Command(object sender, CommandEventArgs e)
		{
			int bookId = Convert.ToInt32(e.CommandArgument);
			this.SetBookId(bookId);
			this.OpenDeleteMode();
		}

		protected void LinkButtonDelete_Click(object sender, EventArgs e)
		{
			this.data.Books.Delete((int)this.currentBookId);
			this.data.SaveChanges();

			this.CloseAllModes();
		}

		protected void LinkButtonCancel_Click(object sender, EventArgs e)
		{
			this.CloseAllModes();
		}

		protected string ShortenText(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}

			if (text.Length > MaxLabelLength)
			{
				return text.Substring(0, MaxLabelLength - ShortenLabelSymbols.Length) + ShortenLabelSymbols;
			}

			return text;
		}

		private void OpenCreateMode()
		{
			this.LinkButtonCreateNew.Visible = false;
			this.PanelCreate.Visible = true;
			this.PanelDelete.Visible = false;
			this.PanelEdit.Visible = false;
		}

		private void OpenDeleteMode()
		{
			this.LinkButtonCreateNew.Visible = false;
			this.PanelCreate.Visible = false;
			this.PanelDelete.Visible = true;
			this.PanelEdit.Visible = false;
			this.PopulateBookData();
		}

		private void OpenEditMode()
		{
			this.LinkButtonCreateNew.Visible = false;
			this.PanelCreate.Visible = false;
			this.PanelDelete.Visible = false;
			this.PanelEdit.Visible = true;
			this.PopulateBookData();
		}

		private void CloseAllModes()
		{
			this.LinkButtonCreateNew.Visible = true;
			this.PanelCreate.Visible = false;
			this.PanelDelete.Visible = false;
			this.PanelEdit.Visible = false;

			this.TextBoxBookEditTitle.Text = string.Empty;
			this.TextBoxBookEditAuthors.Text = string.Empty;
			this.TextBoxBookEditISBN.Text = string.Empty;
			this.TextBoxBookEditWebSite.Text = string.Empty;
			this.TextTextBoxBookEditDescription.Text = string.Empty;
			this.TextBoxBookCreateTitle.Text = string.Empty;
			this.TextBoxBookCreateAuthors.Text = string.Empty;
			this.TextBoxBookCreateISBN.Text = string.Empty;
			this.TextBoxBookCreateWebSite.Text = string.Empty;
			this.TextTextBoxBookCreateDescription.Text = string.Empty;
			this.TextTextBoxBookDeleteTitle.Text = string.Empty;
		}

		private void PopulateBookData()
		{
			if (this.currentBookId != null)
			{
				Book book = this.data.Books.GetById((int)this.currentBookId);

				this.TextBoxBookEditTitle.Text = book.Title;
				this.TextBoxBookEditAuthors.Text = book.Authors;
				this.TextBoxBookEditISBN.Text = book.ISBN;
				this.TextBoxBookEditWebSite.Text = book.WebSite;
				this.TextTextBoxBookEditDescription.Text = book.Description;
				this.DropDownListBookEditCategory.SelectedValue = book.CategoryId.ToString();
				this.TextTextBoxBookDeleteTitle.Text = book.Title;
			}
		}

		private void SetBookId(int id)
		{
			this.currentBookId = id;
			this.ViewState["currentBookId"] = id;
		}

		private bool ValidateBookTitle(string bookTitle)
		{
			if (string.IsNullOrEmpty(bookTitle))
			{
				BooksLibrarySystem.Web.Controls.ErrorSuccessNotifier.ErrorSuccessNotifier.AddErrorMessage("Book title can not be empty");
				return false;
			}

			return true;
		}

		private bool ValidateBookAuthors(string bookAthors)
		{
			if (string.IsNullOrEmpty(bookAthors))
			{
				BooksLibrarySystem.Web.Controls.ErrorSuccessNotifier.ErrorSuccessNotifier.AddErrorMessage("Book author(s) can not be empty");
				return false;
			}

			return true;
		}
	}
}