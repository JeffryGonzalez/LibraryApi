using System.Collections;
using System.Collections.Generic;

namespace LibraryApi.Model
{
	public class Friend
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Loan> Loans { get; set; }

	}
}