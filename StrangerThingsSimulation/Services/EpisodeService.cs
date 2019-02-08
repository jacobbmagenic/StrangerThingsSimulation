using StrangerThings.Common.Models;
using StrangerThings.Server.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrangerThings.Server.Services
{
	/// <summary>
	/// Service class containing various methods related to Stranger Things episodes
	/// </summary>
	public class EpisodeService : IEpisodeService
	{
		private readonly IEpisodeRepository _EpisodeRepository;

		/// <summary>
		/// Instantiate EpisodeService with EpisodeRepository injection
		/// </summary>
		/// <param name="episodeRepository">Variable containing DB access methods for CRUD operations</param>
		public EpisodeService(IEpisodeRepository episodeRepository)
		{
			_EpisodeRepository = episodeRepository;
		}

		/// <summary>
		/// Makes a call to the EpisodeRepository to get JSON data for all episodes in the database
		/// </summary>
		/// <returns>Task<List<Episode>></returns>
		public async Task<List<Episode>> GetAllEpisodesAsync()
		{
			return await _EpisodeRepository.GetAllEpisodesAsync();
		}

		/// <summary>
		/// Makes a call to the EpisodeRepository to get JSON data for episode corresponding to the given number
		/// </summary>
		/// <param name="episodeNumber">The episode number</param>
		/// <returns>Task<Episode></returns>
		public async Task<Episode> GetEpisodeByNumberAsync(int episodeNumber)
		{
			return await _EpisodeRepository.GetEpisodeByNumberAsync(episodeNumber);
		}

		/// <summary>
		/// Makes a call to the EpisodeRepository to post given episode, returns episode if added successfully
		/// </summary>
		/// <param name="episode">Episode being added</param>
		/// <returns>Episode</returns>
		public async Task<Episode> CreateEpisodeAsync(Episode episode)
		{
			return await _EpisodeRepository.CreateEpisodeAsync(episode);
		}

		/// <summary>
		/// Makes a call to the EpisodeRepository to update given episode, returns episode if updated successfully
		/// </summary>
		/// <param name="episodeNumber">The episode number</param>
		/// <param name="episode">Episode being added</param>
		public async Task<Episode> UpdateEpisodeAsync(int episodeNumber, Episode episode)
		{
			return await _EpisodeRepository.UpdateEpisodeAsync(episodeNumber, episode);
		}

		/// <summary>
		/// Makes a call to the EpisodeRepository to delete given episode, returns episode if found and deleted successfully
		/// </summary>
		/// <param name="episodeNumber">The episode number</param>
		public async Task<Episode> DeleteEpisodeByNumberAsync(int episodeNumber)
		{
			return await _EpisodeRepository.DeleteEpisodeByNumberAsync(episodeNumber);
		}
	}
}
