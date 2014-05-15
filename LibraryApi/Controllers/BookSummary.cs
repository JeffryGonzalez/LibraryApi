using System;
using System.Collections.Generic;
using LibraryApi.Model;
using Newtonsoft.Json;

namespace LibraryApi.Controllers
{
	public class BookSummary
	{
		public BookSummary()
		{
			Links = new List<RelLink> {new RelLink() {Link = new Uri("/books/" + Id, UriKind.Relative), Relation = "item"}};
		}

		public int Id { get;  set; }
		public string Title { get;  set; }
		public string Author { get;  set; }
		public bool Available { get;  set; }

		public List<RelLink> Links { get; set; }

	}

	[JsonConverter(typeof(LinkSerializer))]
	public class RelLink
	{	
		public string Relation { get; set; }
		
		public Uri Link { get; set; }
	}

	public class LinkSerializer : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof (RelLink);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return false;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var link = (RelLink) value;
			writer.WriteStartObject();
			writer.WritePropertyName("rel");
			writer.WriteValue(link.Relation);
			writer.WritePropertyName("href");
			writer.WriteValue(link.Link.ToString());
			writer.WriteEndObject();
		}
	}



}