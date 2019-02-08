using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrangerThings.Server
{
	/// <summary>
	/// Simple class for storing connection string configuration data to extract from appsettings.json
	/// </summary>
	public class ConnectionStringConfig
	{
		public string AppDbConnection { get; set; }
	}
}
