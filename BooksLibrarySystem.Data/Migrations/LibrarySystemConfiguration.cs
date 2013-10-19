namespace BooksLibrarySystem.Data.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using System.Text;
	using BooksLibrarySystem.Data;
	using BooksLibrarySystem.Models;

	public sealed class LibrarySystemConfiguration : DbMigrationsConfiguration<LibrarySystemContext>
	{
		public LibrarySystemConfiguration()
		{
			this.AutomaticMigrationsEnabled = true;
			this.AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(LibrarySystemContext context)
		{
			var rand = new Random();

			var description = new StringBuilder();
			for (int s = 0; s < rand.Next(10, 150); s++)
			{
				description.Append("Book description test. ");
			}

			for (int i = 0; i < 7; i++)
			{
				var category = new Category()
				{
					Name = "Category No: " + i.ToString() + " <br>"
				};

				for (int j = 0; j < rand.Next(10, 50); j++)
				{
					var book = new Book()
					{
						Authors = "Author1, Author2, Author3, Author4 <br>",
						Category = category,
						Description = description.ToString(),
						ISBN = "12345678912345678",
						Title = "Book No: " + j.ToString() + " in category: " + category.Name,
						WebSite = "http://www.new-test-book-website.com/category"
					};

					context.Books.Add(book);
				}
			}

			var emptyCategory = new Category()
			{
				Name = "Category EMPTY  <br>"
			};

			context.Categories.Add(emptyCategory);

			context.SaveChanges();

			base.Seed(context);
		}
	}
}