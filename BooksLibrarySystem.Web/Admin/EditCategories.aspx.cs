using System;
using System.Linq;
using System.Web.UI.WebControls;
using BooksLibrarySystem.Models;

namespace BooksLibrarySystem.Web.Admin
{
	public partial class EditCategories : BooksLibrarySystemPage
	{
		private int? currentCategoryId;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.currentCategoryId = (int?)this.ViewState["currentCategoryId"];
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			this.DataBind();
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
			string categoryName = this.TextBoxCategoryCreate.Text;
			if (this.ValidateCategoryName(categoryName))
			{
				Category category = new Category()
				{
					Name = categoryName
				};

				this.data.Categories.Add(category);
				this.data.SaveChanges();

				this.CloseAllModes();
			}
		}

		protected void LinkButtonEditCategory_Command(object sender, CommandEventArgs e)
		{
			int categoryId = Convert.ToInt32(e.CommandArgument);
			this.SetCategoryId(categoryId);
			this.OpenEditMode();
		}

		protected void LinkButtonEdit_Click(object sender, EventArgs e)
		{
			string categoryName = this.TextBoxCategoryEdit.Text;

			if (this.ValidateCategoryName(categoryName))
			{
				Category category = this.data.Categories.GetById((int)this.currentCategoryId);
				category.Name = categoryName;

				this.data.Categories.Update(category);
				this.data.SaveChanges();

				this.CloseAllModes();
			}
		}

		protected void LinkButtonDeleteCategory_Command(object sender, CommandEventArgs e)
		{
			int categoryId = Convert.ToInt32(e.CommandArgument);
			this.SetCategoryId(categoryId);
			this.OpenDeleteMode();
		}

		protected void LinkButtonDelete_Click(object sender, EventArgs e)
		{
			this.data.Categories.Delete((int)this.currentCategoryId);
			this.data.SaveChanges();

			this.CloseAllModes();
		}

		protected void LinkButtonCancel_Click(object sender, EventArgs e)
		{
			this.CloseAllModes();
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
			this.PopulateCategoryName();
		}

		private void OpenEditMode()
		{
			this.LinkButtonCreateNew.Visible = false;
			this.PanelCreate.Visible = false;
			this.PanelDelete.Visible = false;
			this.PanelEdit.Visible = true;
			this.PopulateCategoryName();
		}

		private void CloseAllModes()
		{
			this.LinkButtonCreateNew.Visible = true;
			this.PanelCreate.Visible = false;
			this.PanelDelete.Visible = false;
			this.PanelEdit.Visible = false;
			this.TextBoxCategoryCreate.Text = string.Empty;
			this.TextBoxCategoryEdit.Text = string.Empty;
			this.TextBoxCategoryDelete.Text = string.Empty;
		}

		private void PopulateCategoryName()
		{
			if (this.currentCategoryId != null)
			{
				Category category = this.data.Categories.GetById((int)this.currentCategoryId);
				string categoryName = category.Name;
				this.TextBoxCategoryEdit.Text = categoryName;
				this.TextBoxCategoryDelete.Text = categoryName;
			}
		}

		private void SetCategoryId(int id)
		{
			this.currentCategoryId = id;
			this.ViewState["currentCategoryId"] = id;
		}

		private bool ValidateCategoryName(string categoryName)
		{
			if (string.IsNullOrEmpty(categoryName))
			{
				BooksLibrarySystem.Web.Controls.ErrorSuccessNotifier.ErrorSuccessNotifier.AddErrorMessage("Category name can not be empty");
				return false;
			}

			return true;
		}
	}
}