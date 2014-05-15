using System.Threading.Tasks;

namespace LibraryApi.Model
{
	public interface ILibraryCommands
	{
		Task<Loan> AddLoan(int bookId, int friendId);
	}
}