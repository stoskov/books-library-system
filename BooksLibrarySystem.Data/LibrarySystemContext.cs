using System;
using System.Data.Entity;
using System.Linq;
using BooksLibrarySystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BooksLibrarySystem.Data
{
	public class LibrarySystemContext : IdentityDbContext<ApplicationUser, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement> 
	{
		public IDbSet<Category> Categories { get; set; }
  
		public IDbSet<Book> Books { get; set; }
  
		public LibrarySystemContext()
			: base("BooksLibrarySystem")
		{
		}
	}
}