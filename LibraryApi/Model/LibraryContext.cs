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

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>().HasMany<Loan>(l=>l.Loans);
			modelBuilder.Entity<Friend>().HasMany<Loan>(f => f.Loans);
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Friend> Friends { get; set; }
		public DbSet<Loan> Loans { get; set; }
	}
}
