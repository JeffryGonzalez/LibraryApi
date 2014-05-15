using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavis;
using Tavis.IANA;

namespace LibraryApi.Model
{
	public class BookModel
	{
		public BookModel()
		{
			this.Links = new List<Link>();
		}
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }

		public IList<Link> Links { get; set; } 
	}

	
}
