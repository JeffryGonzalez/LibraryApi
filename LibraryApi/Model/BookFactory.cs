using System;
using LibraryApi.Controllers;
using Newtonsoft.Json.Linq;
using Tavis.IANA;

namespace LibraryApi.Model
{
	public class BookFactory
	{

		public dynamic Create(BookSummary book)
		{

			dynamic result = new JObject();
			result.id = book.Id;
			result.title = book.Title;
			result.author = book.Author;

			result.links = new JObject();

			var linkType = book.Available ? "http://bookstore.com/rel#loans" : "http://bookstore.com/rel#return";
			var template = book.Available ? "/loan/{bookId}/{friendId}" : "/return/{bookId}";

			result.links[linkType] = new JObject();
			result.links[linkType]["href-template"] = template;

			result.links[linkType]["href-vars"] = new JObject();
			result.links[linkType]["href-vars"].bookId = book.Id;

			result.links[linkType].hints = new JObject();
			result.links[linkType].hints.allow = new JArray();
			result.links[linkType].hints.allow.Add("POST");

			return result;

		}

	}

	public class Rootobject
	{
		public int id { get; set; }
		public string title { get; set; }
		public string author { get; set; }
		public Links links { get; set; }
	}

	public class Links
	{
		public HttpBookstoreComRelLoans httpbookstorecomrelloans { get; set; }
	}

	public class HttpBookstoreComRelLoans
	{
		public string hreftemplate { get; set; }
		public HrefVars hrefvars { get; set; }
		public Hints hints { get; set; }
	}

	public class HrefVars
	{
		public int bookId { get; set; }
	}

	public class Hints
	{
		public string[] allow { get; set; }
	}

}