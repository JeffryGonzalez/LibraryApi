using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using LibraryApi.Controllers;

namespace LibraryApi.Model
{
	public class LibraryEf : ILoanCommands, IBookQueries
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

		public async Task<IEnumerable<BookSummary>> GetAllBooks()
		{
			return await context.Books.Select(b => new BookSummary()
			{
				Id = b.Id,
				Title = b.Title,
				Author = b.Author,
				Available = b.Loans.Any(l => l.Returned != null)
			}).ToListAsync();
		}

		public async Task<BookSummary> GetBook(int id)
		{
			var book = await context.Books.Where(b => b.Id == id).Select(
				b =>
					new BookSummary()
					{
						Id = b.Id,
						Title = b.Title,
						Author = b.Author,
						Available = b.Loans.Any(l => l.Returned != null)
					}).SingleOrDefaultAsync();
			return book;
		}
	}
}