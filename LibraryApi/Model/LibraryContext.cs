using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Model
{
	public class LibraryContext :DbContext
	{

		public LibraryContext() : base("server=.;database=MayWebApi;integrated security=true")
		{
			
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Friend> Friends { get; set; }
		public DbSet<Loan> Loans { get; set; }
	}
}
