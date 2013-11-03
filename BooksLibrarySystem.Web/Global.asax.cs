using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using BooksLibrarySystem.Data;
using BooksLibrarySystem.Data.Migrations;
using BooksLibrarySystem.Web.App_Start;

namespace BooksLibrarySystem.Web
{
	public class Global : HttpApplication
	{
		public void Application_Start(object sender, EventArgs e)
		{
			// Code that runs on application startup
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<BooksLibrarySystemContext, BooksLibrarySystemConfiguration>());
		}
	}
}