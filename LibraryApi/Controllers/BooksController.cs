using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using LibraryApi.Model;

namespace LibraryApi.Controllers
{
	public class BooksController : ApiController
	{
		LibraryContext context = new LibraryContext();

		public async Task<IEnumerable<Book>>  Get()
		{
			return await context.Books.ToListAsync();
		}

		public async Task<Book> Get(int id)
		{
			return await context.Books.FirstOrDefaultAsync(b => b.Id == id);
		}
	}
}
