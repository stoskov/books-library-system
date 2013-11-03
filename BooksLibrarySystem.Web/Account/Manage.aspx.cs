using System;
using System.Collections.Generic;
using System.Linq;
using BooksLibrarySystem.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BooksLibrarySystem.Web.Account
{
	public partial class Manage : System.Web.UI.Page
	{
		protected string SuccessMessage { get; private set; }

		protected bool CanRemoveExternalLogins { get; private set; }

		protected void Page_Load()
		{
			if (!this.IsPostBack)
			{
				// Determine the sections to render
				ILoginManager manager = new IdentityManager(new IdentityStore(new BooksLibrarySystemContext())).Logins;
				if (manager.HasLocalLogin(this.User.Identity.GetUserId())) 
				{
					this.changePasswordHolder.Visible = true;
				}
				else 
				{
					this.setPassword.Visible = true;
					this.changePasswordHolder.Visible = false;
				}
				this.CanRemoveExternalLogins = manager.GetLogins(this.User.Identity.GetUserId()).Count() > 1;

				// Render success message
				var message = this.Request.QueryString["m"];
				if (message != null) 
				{
					// Strip the query string from action
					this.Form.Action = this.ResolveUrl("~/Account/Manage");

					this.SuccessMessage =
										 message == "ChangePwdSuccess" ? "Your password has been changed."
										 : message == "SetPwdSuccess" ? "Your password has been set."
										   : message == "RemoveLoginSuccess" ? "The account was removed."
											 : String.Empty;
					this.successMessage.Visible = !String.IsNullOrEmpty(this.SuccessMessage);
				}
			}
		}

		protected void ChangePassword_Click(object sender, EventArgs e)
		{
			if (this.IsValid)
			{
				IPasswordManager manager = new IdentityManager(new IdentityStore(new BooksLibrarySystemContext())).Passwords;
				IdentityResult result = manager.ChangePassword(this.User.Identity.GetUserName(), this.CurrentPassword.Text, this.NewPassword.Text);
				if (result.Success) 
				{
					this.Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
				}
				else 
				{
					this.AddErrors(result);
				}
			}
		}

		protected void SetPassword_Click(object sender, EventArgs e)
		{
			if (this.IsValid)
			{
				// Create the local login info and link the local account to the user
				ILoginManager manager = new IdentityManager(new IdentityStore(new BooksLibrarySystemContext())).Logins;
				IdentityResult result = manager.AddLocalLogin(this.User.Identity.GetUserId(), this.User.Identity.GetUserName(), this.password.Text);
				if (result.Success) 
				{
					this.Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
				}
				else 
				{
					this.AddErrors(result);
				}
			}
		}

		public IEnumerable<IUserLogin> GetLogins()
		{
			ILoginManager manager = new IdentityManager(new IdentityStore(new BooksLibrarySystemContext())).Logins;
			var accounts = manager.GetLogins(this.User.Identity.GetUserId());
			this.CanRemoveExternalLogins = accounts.Count() > 1;
			return accounts;
		}

		public void RemoveLogin(string loginProvider, string providerKey)
		{
			ILoginManager manager = new IdentityManager(new IdentityStore(new BooksLibrarySystemContext())).Logins;
			var result = manager.RemoveLogin(this.User.Identity.GetUserId(), loginProvider, providerKey);
			var msg = result.Success
					  ? "?m=RemoveLoginSuccess"
					  : String.Empty;
			this.Response.Redirect("~/Account/Manage" + msg);
		}

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				this.ModelState.AddModelError("", error);
			}
		}
	}
}