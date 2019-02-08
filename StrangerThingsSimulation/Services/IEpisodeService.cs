using StrangerThings.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StrangerThings.Server.Services
{
	/// <summary>
	/// Service class interface containing various methods related to Stranger Things episodes
	/// </summary>
	public interface IEpisodeService
	{
		/// <summary>
		/// Makes a call to the EpisodeRepository to get JSON data for all episodes in the database
		/// </summary>
		/// <returns>Task<List<Episode>></returns>
		Task<List<Episode>> GetAllEpisodesAsync();

		/// <summary>
		/// Makes a call to the EpisodeRepository to get JSON data for episode corresponding to the given number
		/// </summary>
		/// <param name="episodeNumber">The episode number</param>
		/// <returns>Task<Episode></returns>
		Task<Episode> GetEpisodeByNumberAsync(int episodeNumber);

		/// <summary>
		/// Makes a call to the EpisodeRepository to post given episode, returns episode if added successfully
		/// </summary>
		/// <param name="episode">Episode being added</param>
		/// <returns>Episode</returns>
		Task<Episode> CreateEpisodeAsync(Episode episode);

		/// <summary>
		/// Makes a call to the EpisodeRepository to update given episode, returns episode if updated successfully
		/// </summary>
		/// <param name="episodeNumber">The episode number</param>
		/// <param name="episode">Episode being added</param>
		Task<Episode> UpdateEpisodeAsync(int episodeNumber, Episode episode);

		/// <summary>
		/// Makes a call to the EpisodeRepository to delete given episode, returns episode if found and deleted successfully
		/// </summary>
		/// <param name="episodeNumber">The episode number</param>
		Task<Episode> DeleteEpisodeByNumberAsync(int episodeNumber);
	}
}