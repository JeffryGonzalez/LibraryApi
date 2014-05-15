using System.Threading.Tasks;

namespace LibraryApi.Model
{
	public interface ILoanCommands
	{
		Task<Loan> AddLoan(int bookId, int friendId);
	}
}