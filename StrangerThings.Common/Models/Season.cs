using System;
using System.Collections.Generic;
using System.Text;

namespace StrangerThings.Common.Models
{
	/// <summary>
	/// Object model for a season of Stranger Things
	/// </summary>
	public class Season
	{
		public int SeasonNumber { get; set; }
		public float SeasonRating { get; set; }
		public DateTime ReleaseDate { get; set; }
	}
}
