using System;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace BooksLibrarySystem.Web.App_Start
{
	public static class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			var settings = new FriendlyUrlSettings();
			settings.AutoRedirectMode = RedirectMode.Permanent;
			routes.EnableFriendlyUrls(settings);

			routes.MapPageRoute(
				"CategoryDetails", "Category/{id}", "~/CategoryDetails.aspx", true,
				new RouteValueDictionary() { { "id", "" } },
				new RouteValueDictionary() { { "id", "[0-9]{0,}" } });

			routes.MapPageRoute(
				"BookDetails", "Book/{id}", "~/BookDetails.aspx", true,
				new RouteValueDictionary() { { "id", "" } },
				new RouteValueDictionary() { { "id", "[0-9]{0,}" } });
		}
	}
}