using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using LibraryApi.Model;

namespace LibraryApi.Controllers
{
	[RoutePrefix("api")]
	public class LoansAndReturnsController : ApiController
	{

		private ILibraryCommands commands;

		public LoansAndReturnsController(ILibraryCommands commands)
		{
			this.commands = commands;
		}

		[HttpPost]
		[Route("loan/{bookId:int}/{friendId:int}")]
		public async Task<HttpResponseMessage> Loan(int bookId, int friendId)
		{
			var loan = await commands.AddLoan(bookId, friendId);
			var response = Request.CreateResponse(HttpStatusCode.Created, loan);
			response.Headers.Location = new Uri("/api/loans/" + loan.Id, UriKind.Relative);
			return response;
		}


	}
}
