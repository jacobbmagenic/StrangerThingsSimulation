using System.Data;

namespace StrangerThings.Server
{
	/// <summary>
	/// Gives access to DB connection info to other classes
	/// </summary>
	public interface IConnectionFactory
	{
		/// <summary>
		/// Returns a DBConection instance for connecting to the database
		/// </summary>
		/// <returns>IDbConnection</returns>
		IDbConnection GetConnection();
	}
}