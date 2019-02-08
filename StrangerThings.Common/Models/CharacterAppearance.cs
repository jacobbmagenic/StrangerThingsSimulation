using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StrangerThings.Common.Models
{
	/// <summary>
	/// Object model for character appearance in episodes of Stranger Things
	/// </summary>
	public class CharacterAppearance
	{
		public string Name { get; set; }
		public int EpisodePresent { get; set; }
	}
}
