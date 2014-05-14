using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using LibraryApi.Model;
using Tavis;
using Tavis.Home;
using Tavis.IANA;

namespace LibraryApi.Controllers
{
	public class HomeController : ApiController
	{

		public HttpResponseMessage Get()
		{
			var home = new HomeDocument();
			/*"http://bookstore.com/rel#book": {
			"href-template": "/book/{id}",
			"href-vars": {
				"id": null
			},
			"hints": {
				"allow": [
					"GET"
				],
				"formats": {
					"application/json": {},
					"application/vnd.book+json": {}
				}
			}
		},*/
			var bookLink = new Link()
			{
				Relation = "http://bookstore.com/rel#book",
				Target = new Uri("/books/{id}", UriKind.Relative)
			};
			bookLink.AddHint<AllowHint>(h=>h.AddMethod(HttpMethod.Get));
			bookLink.AddHint<FormatsHint>(h =>
			{
				h.AddMediaType("application/json");
				h.AddMediaType("application/vnd.book+json");
			});

			home.AddResource(bookLink);

			/*"http://bookstore.com/rel#books": {
			"href": "/books",
			"hints": {
				"allow": [
					"GET"
				]
			},
			"formats": {
				"application/json": {},
				"application/vnd.collection+json": {}
			}
		}*/
			var booksLink = new Link()
			{
				Relation = "http://bookstore.com/rel#books",
				Target = new Uri("/books/", UriKind.Relative)
			};

			booksLink.AddHint<AllowHint>(h=>h.AddMethod(HttpMethod.Get));
			booksLink.AddHint<FormatsHint>(h =>
			{
				h.AddMediaType("application/json");
				h.AddMediaType("application/vnd.collection+json");
			});

			home.AddResource(booksLink);

			/*"http://bookstore.com/rel#loans": {
			"href-template": "/loans/{bookId}/{friendId}{?action}",
			"href-vars": {
				"bookId": null,
				"friendId": null,
				"action": null
			},
			"hints": {
				"allow": [
          "POST"
				]
			*/

			var loanLink = new Link()
			{
				Relation = "http://bookstore.com/rel#loans",
				Target = new Uri("/loans/{bookId}/{friendId}?action", UriKind.Relative)
			};
			loanLink.AddHint<AllowHint>(h=>h.AddMethod(HttpMethod.Post));

			home.AddResource(loanLink);

			return new HttpResponseMessage()
			{
				RequestMessage = Request,
				Content = new HomeContent(home)
			};

		}
	}
}
