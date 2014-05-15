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
			//dynamic model = new BookModel();
			//model.Id = book.Id;
			//model.Title = book.Title;
			//model.Author = book.Author;
			//model.Links.Add(new SelfLink() {Target = new Uri("/books/"  + book.Id, UriKind.Relative)});
			//return model;
			/*
			 * "links": {
		"http://bookstore.com/rel#loans": {
			"href-template": "/loans/{bookId}/{friendId}{?action}",
			"href-vars": {
				"bookId": 1,
				"friendId": null,
				"action": "borrow"
			},
			"hints": {
				"allow": [
					"POST"
				]
			}
		}*/
			dynamic result = JObject.FromObject(book);

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
}