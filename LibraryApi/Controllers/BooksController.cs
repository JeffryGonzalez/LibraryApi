using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using LibraryApi.Model;
using Newtonsoft.Json.Linq;

namespace LibraryApi.Controllers
{
	public class BooksController : ApiController
	{

		private readonly IBookQueries queries;


		public BooksController(IBookQueries queries)
		{
			this.queries = queries;
		}

		public async Task<IEnumerable<BookSummary>>  Get()
		{
			return await queries.GetAllBooks();
		}

		public async Task<JObject> Get(int id)
		{
			var book = await queries.GetBook(id);
			if (book == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			return new BookFactory().Create(book);
		}
	}
}
