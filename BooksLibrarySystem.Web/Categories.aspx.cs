using System;
using System.Linq;
using System.Text;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;
using BooksLibrarySystem.Models;
using BooksLibrarySystem.Web.Controls.ErrorSuccessNotifier;

namespace BooksLibrarySystem.Web
{
	public partial class Categories : BooksLibrarySystemPage
	{
		private const string MessageCategoryUpdated = "Category successfully updated";
		private const string MessageCategoryCreated = "Category successfully created";
		private const string MessageCategoryDeleted = "Category successfully deleted";

		protected void Page_Load(object sender, EventArgs e)
		{
			this.HideUnauthorizedWidgets();
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			if (this.IsFormValid())
			{
				this.DataBind();
			}
		}

		public IQueryable<Category> GridViewCategories_GetData()
		{
			return this.data.Categories.All().AsQueryable();
		}

		protected void LinkButtonCreateNew_Click(object sender, EventArgs e)
		{
			this.OpenCreateMode();
		}

		public Category FormViewCategory_GetItem([ViewState("currentCategoryId")]
			int? id)
		{
			if (id == null)
			{
				return null;
			}

			return this.data.Categories.GetById((int)id);
		}

		public void FormViewCategory_DeleteItem([ViewState("currentCategoryId")]
			int id)
		{
			this.data.Categories.Delete(id);
			this.data.SaveChanges();
			this.CloseForm();
			ErrorSuccessNotifier.AddSuccessMessage(MessageCategoryDeleted);
		}

		public void FormViewCategory_UpdateItem([ViewState("currentCategoryId")]
			int id)
		{
			var category = this.data.Categories.GetById(id);
			this.TryUpdateModel(category);

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

			this.data.Categories.Update(category);
			this.data.SaveChanges();
			this.CloseForm();
			ErrorSuccessNotifier.AddSuccessMessage(MessageCategoryUpdated);
		}

		public void FormViewCategory_InsertItem()
		{
			var category = new Category();
			this.TryUpdateModel(category);

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

			this.data.Categories.Add(category);
			this.data.SaveChanges();
			this.CloseForm();
			ErrorSuccessNotifier.AddSuccessMessage(MessageCategoryCreated);
		}

		protected void LinkButtonEditCategory_Command(object sender, CommandEventArgs e)
		{
			int categoryId = Convert.ToInt32(e.CommandArgument);
			this.SetCategoryId(categoryId);
			this.OpenEditMode();
		}

		protected void LinkButtonDeleteCategory_Command(object sender, CommandEventArgs e)
		{
			int categoryId = Convert.ToInt32(e.CommandArgument);
			this.SetCategoryId(categoryId);
			this.OpenReadMode();
		}

		protected void FormView_Command(object sender, CommandEventArgs e)
		{
			this.CloseForm();
		}

		private void SetCategoryId(int id)
		{
			this.ViewState["currentCategoryId"] = id;
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

		private void HideUnauthorizedWidgets()
		{
			if (this.Context.User.Identity.IsAuthenticated)
			{
				this.GridViewCategories.Columns[1].Visible = true;
				this.LinkButtonCreateNew.Visible = true;
			}
			else
			{
				this.GridViewCategories.Columns[1].Visible = false;
				this.LinkButtonCreateNew.Visible = false;
			}
		}

		private void OpenCreateMode()
		{
			this.FormViewCategory.Visible = true;
			this.FormViewCategory.ChangeMode(FormViewMode.Insert);
		}

		private void OpenReadMode()
		{
			this.FormViewCategory.Visible = true;
			this.FormViewCategory.ChangeMode(FormViewMode.ReadOnly);
		}

		private void OpenEditMode()
		{
			this.FormViewCategory.Visible = true;
			this.FormViewCategory.ChangeMode(FormViewMode.Edit);
		}

		private void CloseForm()
		{
			this.FormViewCategory.Visible = false;
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
	}
}