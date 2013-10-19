using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace BooksLibrarySystem.Web.Account
{
	public partial class Register : Page
	{
		protected void CreateUser_Click(object sender, EventArgs e)
		{
			string userName = this.UserName.Text;
			var manager = new AuthenticationIdentityManager(new IdentityStore());
			User u = new User(userName) { UserName = userName };
			IdentityResult result = manager.Users.CreateLocalUser(u, this.Password.Text);
			if (result.Success) 
			{
				manager.Authentication.SignIn(this.Context.GetOwinContext().Authentication, u.Id, isPersistent: false);
				BooksLibrarySystem.Web.Account.OpenAuthProviders.RedirectToReturnUrl(this.Request.QueryString["ReturnUrl"], this.Response);
			}
			else 
			{
				this.ErrorMessage.Text = result.Errors.FirstOrDefault();
			}
		}
	}
}