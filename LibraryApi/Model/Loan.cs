using System;

namespace LibraryApi.Model
{
	public class Loan
	{
		public int Id { get; set; }
		public virtual Book Book { get; set; }
		public virtual Friend Friend { get; set; }
		public DateTime LoanedOn { get; set; }
		public DateTime? Returned { get; set; }
		public string Description { get; set; }
	}
}