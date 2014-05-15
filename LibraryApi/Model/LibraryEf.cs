using System;
using System.Threading.Tasks;

namespace LibraryApi.Model
{
	public class LibraryEf : ILibraryCommands
	{
		private LibraryContext context;

		public LibraryEf(LibraryContext context)
		{
			this.context = context;
		}

		public async Task<Loan> AddLoan(int bookId, int friendId)
		{
			var loan = new Loan();

			var friend = await context.Friends.FindAsync(friendId);
			var book = await context.Books.FindAsync(bookId);

			loan.Friend = friend;
			loan.Book = book;

			loan.LoanedOn = DateTime.Now;
			loan.Description = "Web Apis Are Fun!";
			context.Loans.Add(loan);
			await context.SaveChangesAsync();
			return loan;
		}
	}
}