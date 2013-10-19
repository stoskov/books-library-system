using System;
using System.Linq;
using System.Web.UI;
using BooksLibrarySystem.Data.UnitsOfWork;

namespace BooksLibrarySystem.Web
{
	public class LibrarySystemPage : Page
	{
		protected IUowData data;
		
		public LibrarySystemPage()
			: this(new UowData())
		{
		}

		public LibrarySystemPage(UowData uow)
		{
			this.data = uow;
		}
	}
}