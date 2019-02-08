using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StrangerThings.Common.Models
{
	/// <summary>
	/// Object model for an episode of Stranger Things
	/// </summary>
	public class Episode
	{
		public int EpisodeNumber { get; set; }
		public int SeasonNumber { get; set; }
		public string EpisodeName { get; set; }
		public int RuntimeMinutes { get; set; }
		public float Rating { get; set; }
	}
}
