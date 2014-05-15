using System;
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
		LibraryContext context = new LibraryContext();

		public async Task<IEnumerable<Book>>  Get()
		{
			return await context.Books.ToListAsync();
		}

		public  JObject Get(int id)
		{
			var book =
				context.Books.Where(b=>b.Id==id).Select(
					b =>
						new BookSummary()
						{
							Id = b.Id,
							Title = b.Title,
							Author = b.Author,
							Available = b.Loans.Any(l => l.Returned == null)
						}).Single();
			//var book = context.Books.FirstOrDefaultAsync(b => b.Id == id).Result;
			dynamic model = new BookFactory().Create(book);
			return model;
		}
	}

	public class BookSummary
	{

		public int Id { get;  set; }
		public string Title { get;  set; }
		public string Author { get;  set; }
		public bool Available { get;  set; }

	}
}
