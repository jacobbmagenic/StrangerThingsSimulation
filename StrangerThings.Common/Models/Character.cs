using System;
using System.Collections.Generic;
using System.Text;

namespace StrangerThings.Common.Models
{
	/// <summary>
	/// Object model for characters of Stranger Things
	/// </summary>
	public class Character
	{
		public string Name { get; set; }
		public char gender { get; set; }
		public int age { get; set; }
	}
}
