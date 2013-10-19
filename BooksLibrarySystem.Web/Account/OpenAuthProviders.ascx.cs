using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;

namespace BooksLibrarySystem.Web.Account
{
	public partial class OpenAuthProviders : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.IsPostBack)
			{
				var provider = this.Request.Form["provider"];
				if (provider == null)
				{
					return;
				}
				// Request a redirect to the external login provider
				string redirectUrl = this.ResolveUrl(String.Format(CultureInfo.InvariantCulture, "~/Account/RegisterExternalLogin?{0}={1}&returnUrl={2}", ProviderNameKey, provider, this.ReturnUrl));
				this.Context.GetOwinContext().Authentication.Challenge(new AuthenticationProperties() { RedirectUrl = redirectUrl }, provider);
				this.Response.StatusCode = 401;
				this.Response.End();
			}
		}

		public string ReturnUrl { get; set; }

		public IEnumerable<string> GetProviderNames()
		{
			return this.Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes().Select(t => t.AuthenticationType);
		}

		public const string ProviderNameKey = "providerName";

		public static string GetProviderNameFromRequest(HttpRequest request)
		{
			return request[ProviderNameKey];
		}

		public static string GetExternalLoginRedirectUrl(string accountProvider)
		{
			return "/Account/RegisterExternalLogin?" + ProviderNameKey + "=" + accountProvider;
		}

		private static bool IsLocalUrl(string url)
		{
			return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
		}

		public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
		{
			if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
			{
				response.Redirect(returnUrl);
			}
			else
			{
				response.Redirect("~/");
			}
		}
	}
}