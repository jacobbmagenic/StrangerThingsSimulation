using Dapper;
using Microsoft.Extensions.Logging;
using StrangerThings.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrangerThings.Server.Repositories
{
	/// <summary>
	/// Repository containing access to DB operations related to episodes
	/// </summary>
	public class EpisodeRepository : IEpisodeRepository
	{
		private IConnectionFactory _ConnectionFactory;
		private ILogger _Logger;

		/// <summary>
		/// Instantiate EpisodeRepository with ConnectionFactory injection
		/// </summary>
		/// <param name="connectionFactory">Variable containing DB connection data</param>
		public EpisodeRepository(IConnectionFactory connectionFactory, ILogger logger)
		{
			_ConnectionFactory = connectionFactory;
			_Logger = logger;
		}

		/// <summary>
		/// Returns JSON data for all episodes in the database
		/// </summary>
		/// <returns>Task<List<Episode>></returns>
		public async Task<List<Episode>> GetAllEpisodesAsync()
		{
			try
			{

				var query = $"Select [Id], [EpisodeNumber], [SeasonNumber], [EpisodeName], [RuntimeMinutes], [Rating] From [dbo].[Episode]";

				using (var cn = _ConnectionFactory.GetConnection())
				{
					var episodes = await cn.QueryAsync<Episode>(query);
					cn.Dispose();
					return episodes.ToList();
				}
			}
			catch(Exception ex)
			{
				_Logger.LogInformation($"Unexpected error: {ex.ToString()}");
				throw new Exception(ex.ToString());
			}
		}

		/// <summary>
		/// Returns JSON data for episode corresponding to the given number
		/// </summary>
		/// <param name="episodeNumber">The episode number</param>
		/// <returns>Task<Episode></returns>
		public async Task<Episode> GetEpisodeByNumberAsync(int episodeNumber)
		{
			var query = $"Select [Id], [EpisodeNumber], [SeasonNumber], [EpisodeName], [RuntimeMinutes], [Rating] From [dbo].[Episode] Where [EpisodeNumber] = {episodeNumber}";

			using (var cn = _ConnectionFactory.GetConnection())
			{
				var episode = await cn.QueryAsync<Episode>(query);
				cn.Dispose();

				if (!episode.Any())
				{
					_Logger.LogInformation("No episodes found for the given inputs.");
					throw new Exception("No episodes found for the given inputs.");
				}
				else
					return episode.FirstOrDefault();
			}
		}

		/// <summary>
		/// Return JSON data for episodes containing the input character
		/// </summary>
		/// <param name="charName">character Name field to query</param>
		/// <returns>Task<List<Episode>></returns>
		public async Task<List<Episode>> GetEpisodesWithCharacterAsync(string charName) {
			try
			{

				var query = $"Select [EpisodeNumber], [SeasonNumber], [EpisodeName], [RuntimeMinutes], [Rating] " +
					$"From [dbo].[Episode] Inner Join [dbo].[CharacterAppearance] On " +
					$"[dbo].[Episode].[EpisodeNumber] = [dbo].[CharacterAppearance].[EpisodePresent] Where [Name] = \'{charName}\'";

				using (var cn = _ConnectionFactory.GetConnection())
				{
					var episodes = await cn.QueryAsync<Episode>(query);
					cn.Dispose();

					if (!episodes.Any())
					{
						return new List<Episode>();
					}
					else
						return episodes.ToList();
				}
			}
			catch (Exception ex)
			{
				_Logger.LogInformation($"Unexpected error: {ex.ToString()}");
				throw new Exception(ex.ToString());
			}
		}

		/// <summary>
		/// Returns JSON data for episode created if successful
		/// </summary>
		/// <param name="episode">The episode being created</param>
		/// <returns>Task<Episode></returns>
		public async Task<Episode> CreateEpisodeAsync(Episode episode)
		{
			try
			{
				var query = $"INSERT INTO [dbo].[Episode] ([EpisodeNumber],[SeasonNumber],[EpisodeName],[RuntimeMinutes],[Rating]) " +
					$"OUTPUT inserted.Id, inserted.EpisodeNumber, inserted.SeasonNumber, inserted.EpisodeName, inserted.RuntimeMinutes, inserted.Rating " +
					$"VALUES({episode.EpisodeNumber}, {episode.SeasonNumber}, \'{episode.EpisodeName}\', {episode.RuntimeMinutes}, {episode.Rating})";

				using (var cn = _ConnectionFactory.GetConnection())
				{
					var episodeAdded = await cn.QueryAsync<Episode>(query);
					cn.Dispose();
					return episodeAdded.FirstOrDefault(); //TODO: Handle case of bad query
				}
			}
			catch
			{
				_Logger.LogInformation("Invalid input episode.");
				throw new Exception("Invalid input episode.");
			}
		}

		/// <summary>
		/// Updates and returns JSON data for episode corresponding to the given number
		/// </summary>
		/// <param name="episodeNumber">The episode number</param>
		/// <param name="episode">The episode being added</param>
		/// <returns>Task<Episode></returns>
		public async Task<Episode> UpdateEpisodeAsync(int episodeNumber, Episode episode)
		{
			try
			{
				var query = $"Update [dbo].[Episode] " +
					$"SET [EpisodeNumber] = {episode.EpisodeNumber}, [SeasonNumber] = {episode.SeasonNumber}, [EpisodeName] = \'{episode.EpisodeName}\', [RuntimeMinutes] = {episode.RuntimeMinutes}, [Rating] = {episode.Rating} " +
					$"OUTPUT inserted.Id, inserted.EpisodeNumber, inserted.SeasonNumber, inserted.EpisodeName, inserted.RuntimeMinutes, inserted.Rating " +
					$"WHERE [EpisodeNumber] = {episodeNumber}";

				using (var cn = _ConnectionFactory.GetConnection())
				{
					var episodeUpdated = await cn.QueryAsync<Episode>(query);
					cn.Dispose();
					return episodeUpdated.FirstOrDefault(); //TODO: Handle case of bad query
				}
			}
			catch
			{
				_Logger.LogInformation("Invalid input episode.");
				throw new Exception("Invalid input episode.");
			}
		}

		/// <summary>
		/// Returns JSON data for deleted episode
		/// </summary>
		/// <param name="episodeNumber">The episode number to be deleted</param>
		/// <returns>Task<Episode></returns>
		public async Task<Episode> DeleteEpisodeByNumberAsync(int episodeNumber)
		{
			var query = $"Select [Id], [EpisodeNumber], [SeasonNumber], [EpisodeName], [RuntimeMinutes], [Rating] From [dbo].[Episode] Where [EpisodeNumber] = {episodeNumber} " +
				$"Delete From [dbo].[Episode] Where [EpisodeNumber] = {episodeNumber}";

			using (var cn = _ConnectionFactory.GetConnection())
			{
				var deletedEpisode = await cn.QueryAsync<Episode>(query);
				cn.Dispose();

				if (!deletedEpisode.Any())
				{
					_Logger.LogInformation("No episodes found for the given inputs.");
					throw new Exception("No episodes found for the given inputs.");
				}
				else
					return deletedEpisode.FirstOrDefault();
			}
		}
	}
}
