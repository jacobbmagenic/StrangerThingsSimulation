using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StrangerThings.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrangerThings.Server.Repositories
{
	/// <summary>
	/// Repository containing access to DB operations related to Seasons
	/// </summary>
	public class SeasonRepository : ISeasonRepository
	{
		private IConnectionFactory _ConnectionFactory;
		private ILogger _Logger;

		/// <summary>
		/// Instantiate SeasonRepository with ConnectionFactory injection
		/// </summary>
		/// <param name="connectionFactory">Variable containing DB connection data</param>
		public SeasonRepository(IConnectionFactory connectionFactory, ILogger logger)
		{
			_ConnectionFactory = connectionFactory;
			_Logger = logger;
		}

		/// <summary>
		/// Returns JSON data for all Seasons in the database
		/// </summary>
		/// <returns>Task<List<Season>></returns>
		public async Task<List<Season>> GetAllSeasonsAsync()
		{
			try
			{
				var query = $"Select [Id], [SeasonNumber], [SeasonRating], [ReleaseDate] From [dbo].[Season]";

				using (var cn = _ConnectionFactory.GetConnection())
				{
					var Seasons = await cn.QueryAsync<Season>(query);
					cn.Dispose();
					return Seasons.ToList();
				}
			}
			catch (Exception ex)
			{
				_Logger.LogInformation($"Unexpected error: {ex.ToString()}");
				throw new Exception(ex.ToString());
			}
		}

		/// <summary>
		/// Returns JSON data for Season corresponding to the input season number
		/// </summary>
		/// <param name="SeasonNumber">Input Season number</param>
		/// <returns>Task<Season></returns>
		public async Task<Season> GetSeasonByNumberAsync(int SeasonNumber)
		{
			var query = $"Select [Id], [SeasonNumber], [SeasonRating], [ReleaseDate] From [dbo].[Season] Where [SeasonNumber] = {SeasonNumber}";

			using (var cn = _ConnectionFactory.GetConnection())
			{
				var Season = await cn.QueryAsync<Season>(query);
				cn.Dispose();

				if (!Season.Any())
				{
					_Logger.LogInformation("No seasons found for the given input.");
					throw new Exception("No seasons found for the given input.");
				}
				else
					return Season.FirstOrDefault();
			}
		}

		/// <summary>
		/// Returns JSON data for Season created if successful
		/// </summary>
		/// <param name="Season">Input Season object</param>
		/// <returns>Task<Season></returns>
		public async Task<Season> CreateSeasonAsync(Season Season)
		{
			try
			{
				var query = $"INSERT INTO [dbo].[Season] ([SeasonNumber],[SeasonRating],[ReleaseDate]) " +
					$"Output inserted.Id, inserted.SeasonNumber, inserted.SeasonRating, inserted.ReleaseDate " +
					$"Values({Season.SeasonNumber}, {Season.SeasonRating}, \'{Season.ReleaseDate}\')";

				using (var cn = _ConnectionFactory.GetConnection())
				{
					var SeasonAdded = await cn.QueryAsync<Season>(query);
					cn.Dispose();
					return SeasonAdded.FirstOrDefault();
				}
			}
			catch
			{
				_Logger.LogInformation("Invalid input Season number.");
				throw new Exception("Invalid input Season number.");
			}
		}

		/// <summary>
		/// Updates and returns JSON data for Season corresponding to the given name
		/// </summary>
		/// <param name="SeasonNumber">Input Season number</param>
		/// <param name="Season">Input Season object</param>
		/// <returns>Task<Season></returns>
		public async Task<Season> UpdateSeasonAsync(int SeasonNumber, Season Season)
		{
			try
			{
				var query = $"Update [dbo].[Season] " +
					$"SET [SeasonNumber] = {Season.SeasonNumber}, [SeasonRating] = {Season.SeasonRating}, [ReleaseDate] = \'{Season.ReleaseDate}\' " +
					$"Output inserted.Id, inserted.SeasonNumber, inserted.SeasonRating, inserted.ReleaseDate " +
					$"Where [SeasonNumber] = {SeasonNumber}";

				using (var cn = _ConnectionFactory.GetConnection())
				{
					var SeasonUpdated = await cn.QueryAsync<Season>(query);
					cn.Dispose();
					return SeasonUpdated.FirstOrDefault();
				}
			}
			catch
			{
				_Logger.LogInformation("Invalid input Season number.");
				throw new Exception("Invalid input Season number.");
			}
		}

		/// <summary>
		/// Returns JSON data for the deleted Season
		/// </summary>
		/// <param name="SeasonNumber">Input Season number to be deleted</param>
		/// <returns>Task<Season></returns>
		public async Task<Season> DeleteSeasonByNumberAsync(int SeasonNumber)
		{
			var query = $"Select [SeasonNumber],[SeasonRating],[ReleaseDate] From [dbo].[Season] Where [SeasonNumber] = {SeasonNumber} " +
				$"Delete From [dbo].[Season] Where [SeasonNumber] = {SeasonNumber}";

			using (var cn = _ConnectionFactory.GetConnection())
			{
				var deletedSeason = await cn.QueryAsync<Season>(query);
				cn.Dispose();

				if (!deletedSeason.Any())
				{
					_Logger.LogInformation("No Seasons found for the given input.");
					throw new Exception("No Seasons found for the given input.");
				}
				else
					return deletedSeason.FirstOrDefault();
			}
		}
	}
}
