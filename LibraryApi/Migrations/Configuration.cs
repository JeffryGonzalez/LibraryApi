using LibraryApi.Model;

namespace LibraryApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryApi.Model.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibraryApi.Model.LibraryContext context)
        {
					var book1 = new Book() { Title = "Walden", Author = "Thoreau" };
					var book2 = new Book() { Title = "Nature", Author = "Emerson" };
					var book3 = new Book() { Title = "Philosophical Investigations", Author = "Wittgenstein" };

					var friend1 = new Friend() { Name = "Todd E" };
					var friend2 = new Friend() { Name = "Tim E" };
					var friend3 = new Friend() { Name = "Doug B" };
					// Jeff Was Here
					var loan1 = new Loan() { Book = book1, Friend = friend1, LoanedOn = DateTime.Now, Description = "In two weeks." };
					var loan2 = new Loan()
					{
						Book = book2,
						Friend = friend2,
						LoanedOn = DateTime.Now.AddDays(-14),
						Returned = DateTime.Now.AddDays(-1),
						Description = "He did."
					};

					context.Books.AddOrUpdate(b => b.Title,
						book1, book2, book3
						);

					context.Friends.AddOrUpdate(f => f.Name,
						friend1, friend2, friend3);

					context.Loans.AddOrUpdate(l => l.Description,
						loan1, loan2);
        }
    }
}
