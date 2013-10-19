using System;
using System.Linq;
using System.Web.UI;
using BooksLibrarySystem.Data.UnitsOfWork;

namespace BooksLibrarySystem.Web
{
	public class LibrarySystemPage : Page
	{
		protected const string ShortenSymbols = "...";

		protected IUowData data;
		
		public LibrarySystemPage()
			: this(new UowData())
		{
		}

		public LibrarySystemPage(UowData uow)
		{
			this.data = uow;
		}

		protected string ShortenText(string text, int maxCharsCount, string shortenSymbols = ShortenSymbols)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}

			if (text.Length > maxCharsCount)
			{
				return text.Substring(0, maxCharsCount - shortenSymbols.Length) + shortenSymbols;
			}

			return text;
		}
	}
}