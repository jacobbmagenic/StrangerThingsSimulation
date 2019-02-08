using Microsoft.AspNetCore.Mvc;
using StrangerThings.Common.Models;
using StrangerThings.Server.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrangerThings.Server.Services
{
	/// <summary>
	/// Service class containing various methods related to Stranger Things seasons
	/// </summary>
	public class SeasonService : ISeasonService
	{
		private readonly ISeasonRepository _SeasonRepository;

		/// <summary>
		/// Instantiate SeasonService with SeasonRepository injection
		/// </summary>
		/// <param name="seasonRepository">Variable containing DB access methods for CRUD operations</param>
		public SeasonService(ISeasonRepository seasonRepository)
		{
			_SeasonRepository = seasonRepository;
		}

		/// <summary>
		/// Makes a call to the SeasonRepository to get JSON data for all seasons in the database
		/// </summary>
		/// <returns>Task<List<Season>></returns>
		public async Task<List<Season>> GetAllSeasonsAsync()
		{
			return await _SeasonRepository.GetAllSeasonsAsync();
		}

		/// <summary>
		/// Makes a call to the SeasonRepository to get JSON data for season corresponding to the given season number
		/// </summary>
		/// <param name="seasonNumber">The season number</param>
		/// <returns>Task<Season></returns>
		public async Task<Season> GetSeasonByNumberAsync(int seasonNumber)
		{
			return await _SeasonRepository.GetSeasonByNumberAsync(seasonNumber);
		}

		/// <summary>
		/// Makes a call to the SeasonRepository to post given season, returns season if added successfully
		/// </summary>
		/// <param name="season">Season being added</param>
		/// <returns>Season</returns>
		public async Task<Season> CreateSeasonAsync(Season season)
		{
			return await _SeasonRepository.CreateSeasonAsync(season);
		}

		/// <summary>
		/// Makes a call to the SeasonRepository to update given season, returns season if updated successfully
		/// </summary>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="season">Season being added</param>
		public async Task<Season> UpdateSeasonAsync(int seasonNumber, Season season)
		{
			return await _SeasonRepository.UpdateSeasonAsync(seasonNumber, season);
		}

		/// <summary>
		/// Makes a call to the SeasonRepository to delete given season, returns season if found and deleted successfully
		/// </summary>
		/// <param name="seasonNumber"></param>
		/// <returns></returns>
		public async Task<Season> DeleteSeasonByNumberAsync(int seasonNumber)
		{
			return await _SeasonRepository.DeleteSeasonByNumberAsync(seasonNumber);
		}
	}
}
