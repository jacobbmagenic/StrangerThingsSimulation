using StrangerThings.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StrangerThings.Server.Repositories
{
	/// <summary>
	/// Repository interface containing access to DB operations related to episodes
	/// </summary>
	public interface IEpisodeRepository
	{
		/// <summary>
		/// Returns JSON data for all episodes in the database
		/// </summary>
		/// <returns>Task<List<Episode>></returns>
		Task<List<Episode>> GetAllEpisodesAsync();

		/// <summary>
		/// Returns JSON data for episode corresponding to the given number
		/// </summary>
		/// <param name="episodeNumber">The episode number</param>
		/// <returns>Task<Episode></returns>
		Task<Episode> GetEpisodeByNumberAsync(int episodeNumber);

		/// <summary>
		/// Returns JSON data for episode created if successful
		/// </summary>
		/// <param name="episode">The episode being created</param>
		/// <returns>Task<Episode></returns>
		Task<Episode> CreateEpisodeAsync(Episode episode);

		/// <summary>
		/// Updates and returns JSON data for episode corresponding to the given number
		/// </summary>
		/// <param name="episodeNumber">The episode number</param>
		/// <param name="episode">The episode being added</param>
		/// <returns>Task<Episode></returns>
		Task<Episode> UpdateEpisodeAsync(int episodeNumber, Episode episode);

		/// <summary>
		/// Returns JSON data for deleted episode
		/// </summary>
		/// <param name="episodeNumber">The episode number to be deleted</param>
		/// <returns>Task<Episode></returns>
		Task<Episode> DeleteEpisodeByNumberAsync(int episodeNumber);
	}
}