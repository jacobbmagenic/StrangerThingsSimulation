using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace StrangerThings.Server
{
	/// <summary>
	/// Gives access to DB connection info to other classes
	/// </summary>
	public class ConnectionFactory : IConnectionFactory
	{
		private readonly ConnectionStringConfig _ConnectionStringConfig;

		/// <summary>
		/// Instantiate ConnectionFactory with access to appsettings.json using IOptions pattern
		/// </summary>
		/// <param name="configAccessor"></param>
		public ConnectionFactory(IOptions<ConnectionStringConfig> configAccessor)
		{
			_ConnectionStringConfig = configAccessor.Value;
		}

		/// <summary>
		/// Returns a DBConection instance for connecting to the database
		/// </summary>
		/// <returns>IDbConnection</returns>
		public IDbConnection GetConnection()
		{
			var connectionString = _ConnectionStringConfig.AppDbConnection;
			IDbConnection conn = new SqlConnection(connectionString);
			conn.Open();
			return conn;
		}
	}
}
