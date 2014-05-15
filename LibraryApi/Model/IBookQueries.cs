using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryApi.Controllers;

namespace LibraryApi.Model
{
	public interface IBookQueries
	{
		Task<IEnumerable<BookSummary>> GetAllBooks();
		Task<BookSummary> GetBook(int id);
	}
}