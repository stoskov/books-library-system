using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BooksLibrarySystem.Web.App_Start.Startup))]
namespace BooksLibrarySystem.Web.App_Start
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			this.ConfigureAuth(app);
		}
	}
}