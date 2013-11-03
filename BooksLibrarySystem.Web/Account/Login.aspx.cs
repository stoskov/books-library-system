using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using BooksLibrarySystem.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace BooksLibrarySystem.Web.Account
{
	public partial class Login : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			this.RegisterHyperLink.NavigateUrl = "Register";
			this.OpenAuthLogin.ReturnUrl = this.Request.QueryString["ReturnUrl"];
			var returnUrl = HttpUtility.UrlEncode(this.Request.QueryString["ReturnUrl"]);
			if (!String.IsNullOrEmpty(returnUrl))
			{
				this.RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
			}
		}

		protected void LogIn(object sender, EventArgs e)
		{
			if (this.IsValid)
			{
				// Validate the user password
				IAuthenticationManager manager = new AuthenticationIdentityManager(new IdentityStore(new BooksLibrarySystemContext())).Authentication;
				IdentityResult result = manager.CheckPasswordAndSignIn(this.Context.GetOwinContext().Authentication, this.UserName.Text, this.Password.Text, this.RememberMe.Checked);
				if (result.Success)
				{
					this.Response.Redirect(this.Request.QueryString["ReturnUrl"], false);
					//OpenAuthProviders.RedirectToReturnUrl(this.Request.QueryString["ReturnUrl"], this.Response);
				}
				else
				{
					this.FailureText.Text = result.Errors.FirstOrDefault();
					this.ErrorMessage.Visible = true;
				}
			}
		}
	}
}