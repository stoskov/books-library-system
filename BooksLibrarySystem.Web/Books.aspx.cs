using System;
using System.Linq;
using System.Text;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;
using BooksLibrarySystem.Models;
using BooksLibrarySystem.Web.Controls.ErrorSuccessNotifier;

namespace BooksLibrarySystem.Web.Admin
{
	public partial class Books : BooksLibrarySystemPage
	{
		private const string MessageBookUpdated = "Book successfully updated";
		private const string MessageBookCreated = "Book successfully created";
		private const string MessageBookDeleted = "Book successfully deleted";

		private int? currentBookId;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.currentBookId = (int?)this.ViewState["currentBookId"];
			this.HideUnauthorizedWidgets();
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			if (this.IsFormValid())
			{
				this.DataBind();
			}
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

		public BooksLibrarySystem.Models.Book FormViewBook_GetItem([ViewState("currentBookId")]
			int? id)
		{
			if (id == null)
			{
				return null;
			}

			return this.data.Books.GetById((int)id);
		}

		public void FormViewBook_DeleteItem([ViewState("currentBookId")]
			int id)
		{
			this.data.Books.Delete(id);
			this.data.SaveChanges();
			ErrorSuccessNotifier.AddSuccessMessage(MessageBookDeleted);
		}

		public void FormViewBook_UpdateItem([ViewState("currentBookId")]
			int id)
		{
			var book = this.data.Books.GetById(id);
			this.TryUpdateModel(book);

			if (!this.ModelState.IsValid)
			{
				this.SetFormValidity(false);
				this.DisplayErrorMessage();
				return;
			}
			else
			{
				this.SetFormValidity(true);
			}

			this.data.Books.Update(book);
			this.data.SaveChanges();
			this.CloseForm();
			ErrorSuccessNotifier.AddSuccessMessage(MessageBookUpdated);
		}

		public void FormViewBook_InsertItem()
		{
			var book = new Book();
			this.TryUpdateModel(book);

			if (!this.ModelState.IsValid)
			{
				this.SetFormValidity(false);
				this.DisplayErrorMessage();
				return;
			}
			else
			{
				this.SetFormValidity(true);
			}

			this.data.Books.Add(book);
			this.data.SaveChanges();
			this.CloseForm();
			ErrorSuccessNotifier.AddSuccessMessage(MessageBookCreated);
		}

		protected void LinkButtonEditBook_Command(object sender, CommandEventArgs e)
		{
			int bookId = Convert.ToInt32(e.CommandArgument);
			this.SetBookId(bookId);
			this.OpenEditMode();
		}

		protected void LinkButtonDeleteBook_Command(object sender, CommandEventArgs e)
		{
			int bookId = Convert.ToInt32(e.CommandArgument);
			this.SetBookId(bookId);
			this.OpenReadMode();
		}

		protected void FormView_Command(object sender, CommandEventArgs e)
		{
			this.CloseForm();
		}

		private void OpenCreateMode()
		{
			this.FormViewBook.Visible = true;
			this.FormViewBook.ChangeMode(FormViewMode.Insert);
		}

		private void OpenReadMode()
		{
			this.FormViewBook.Visible = true;
			this.FormViewBook.ChangeMode(FormViewMode.ReadOnly);
		}

		private void OpenEditMode()
		{
			this.FormViewBook.Visible = true;
			this.FormViewBook.ChangeMode(FormViewMode.Edit);
		}

		private void CloseForm()
		{
			this.FormViewBook.Visible = false;
		}

		private void DisplayErrorMessage()
		{
			var errorList = this.ModelState.Values
								.SelectMany(m => m.Errors)
								.Select(e => e.ErrorMessage)
								.ToList();

			var errors = new StringBuilder();
			errorList.ForEach(err => errors.AppendLine(err.ToString()));

			ErrorSuccessNotifier.AddErrorMessage(errors.ToString());
		}

		private void SetBookId(int id)
		{
			this.currentBookId = id;
			this.ViewState["currentBookId"] = id;
		}

		private void HideUnauthorizedWidgets()
		{
			if (this.Context.User.Identity.IsAuthenticated)
			{
				this.GridViewBooks.Columns[3].Visible = true;
				this.LinkButtonCreateNew.Visible = true;
			}
			else
			{
				this.GridViewBooks.Columns[3].Visible = false;
				this.LinkButtonCreateNew.Visible = false;
			}
		}

		private void SetFormValidity(bool isValid)
		{
			this.ViewState["isFormValid"] = isValid;
		}

		private bool IsFormValid()
		{
			var isValid = this.ViewState["isFormValid"];
			if (isValid != null && (bool)isValid == false)
			{
				return false;
			}

			return true;
		}
	}
}