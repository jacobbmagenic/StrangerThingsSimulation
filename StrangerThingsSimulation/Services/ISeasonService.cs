using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StrangerThings.Common.Models;

namespace StrangerThings.Server.Services
{
	public interface ISeasonService
	{
		/// <summary>
		/// Makes a call to the SeasonRepository to get JSON data for all seasons in the database
		/// </summary>
		/// <returns>Task<List<Season>></returns>
		Task<List<Season>> GetAllSeasonsAsync();

		/// <summary>
		/// Makes a call to the SeasonRepository to get JSON data for season corresponding to the given season number
		/// </summary>
		/// <param name="seasonNumber">The season number</param>
		/// <returns>Task<Season></returns>
		Task<Season> GetSeasonByNumberAsync(int seasonNumber);

		/// <summary>
		/// Makes a call to the SeasonRepository to post given season, returns season if added successfully
		/// </summary>
		/// <param name="season">Season being added</param>
		/// <returns>Season</returns>
		Task<Season> CreateSeasonAsync(Season season);

		/// <summary>
		/// Makes a call to the SeasonRepository to update given season, returns season if updated successfully
		/// </summary>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="season">Season being added</param>
		Task<Season> UpdateSeasonAsync(int seasonNumber, Season season);

		/// <summary>
		/// Makes a call to the SeasonRepository to delete given season, returns season if found and deleted successfully
		/// </summary>
		/// <param name="seasonNumber"></param>
		/// <returns></returns>
		Task<Season> DeleteSeasonByNumberAsync(int seasonNumber);
	}
}