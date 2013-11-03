using System;
using System.Security.Claims;
using System.Web;
using BooksLibrarySystem.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace BooksLibrarySystem.Web.Account
{
	public partial class RegisterExternalLogin : System.Web.UI.Page
	{
		protected string ProviderName
		{
			get
			{
				return (string)this.ViewState["ProviderName"] ?? String.Empty;
			}
			private set
			{
				this.ViewState["ProviderName"] = value;
			}
		}

		protected string ProviderAccountKey
		{
			get
			{
				return (string)this.ViewState["ProviderAccountKey"] ?? String.Empty;
			}
			private set
			{
				this.ViewState["ProviderAccountKey"] = value;
			}
		}

		protected void Page_Load()
		{
			// Process the result from an auth provider in the request
			this.ProviderName = BooksLibrarySystem.Web.Account.OpenAuthProviders.GetProviderNameFromRequest(this.Request);
			if (String.IsNullOrEmpty(this.ProviderName))
			{
				this.Response.Redirect("~/Account/Login");
			}
			if (!this.IsPostBack)
			{
				IAuthenticationManager manager = new AuthenticationIdentityManager(new IdentityStore(new BooksLibrarySystemContext())).Authentication;
				var auth = this.Context.GetOwinContext().Authentication;
				ClaimsIdentity id = manager.GetExternalIdentity(auth);
				IdentityResult result = manager.SignInExternalIdentity(auth, id);
				if (result.Success)
				{
					BooksLibrarySystem.Web.Account.OpenAuthProviders.RedirectToReturnUrl(this.Request.QueryString["ReturnUrl"], this.Response);
				}
				else if (this.User.Identity.IsAuthenticated)
				{
					result = manager.LinkExternalIdentity(id, this.User.Identity.GetUserId());
					if (result.Success)
					{
						BooksLibrarySystem.Web.Account.OpenAuthProviders.RedirectToReturnUrl(this.Request.QueryString["ReturnUrl"], this.Response);
					}
					else
					{
						this.AddErrors(result);
						return;
					}
				}
				else
				{
					this.userName.Text = id.Name;
				}
			}
		}
        
		protected void LogIn_Click(object sender, EventArgs e)
		{
			this.CreateAndLoginUser();
		}

		private void CreateAndLoginUser()
		{
			if (!this.IsValid)
			{
				return;
			}
			var user = new User(this.userName.Text);
			IAuthenticationManager manager = new AuthenticationIdentityManager(new IdentityStore(new BooksLibrarySystemContext())).Authentication;
			IdentityResult result = manager.CreateAndSignInExternalUser(this.Context.GetOwinContext().Authentication, user);
			if (result.Success)
			{
				BooksLibrarySystem.Web.Account.OpenAuthProviders.RedirectToReturnUrl(this.Request.QueryString["ReturnUrl"], this.Response);
			}
			else
			{
				this.AddErrors(result);
				return;
			}
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