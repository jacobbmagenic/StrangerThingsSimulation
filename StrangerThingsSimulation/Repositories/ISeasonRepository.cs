using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StrangerThings.Common.Models;

namespace StrangerThings.Server.Repositories
{
	public interface ISeasonRepository
	{
		/// <summary>
		/// Returns JSON data for all Seasons in the database
		/// </summary>
		/// <returns>Task<List<Season>></returns>
		Task<List<Season>> GetAllSeasonsAsync();

		/// <summary>
		/// Returns JSON data for Season corresponding to the input season number
		/// </summary>
		/// <param name="SeasonNumber">Input Season number</param>
		/// <returns>Task<Season></returns>
		Task<Season> GetSeasonByNumberAsync(int SeasonNumber);

		/// <summary>
		/// Returns JSON data for Season created if successful
		/// </summary>
		/// <param name="Season">Input Season object</param>
		/// <returns>Task<Season></returns>
		Task<Season> CreateSeasonAsync(Season Season);

		/// <summary>
		/// Updates and returns JSON data for Season corresponding to the given name
		/// </summary>
		/// <param name="SeasonNumber">Input Season number</param>
		/// <param name="Season">Input Season object</param>
		/// <returns>Task<Season></returns>
		Task<Season> UpdateSeasonAsync(int SeasonNumber, Season Season);

		/// <summary>
		/// Returns JSON data for the deleted Season
		/// </summary>
		/// <param name="SeasonNumber">Input Season number to be deleted</param>
		/// <returns>Task<Season></returns>
		Task<Season> DeleteSeasonByNumberAsync(int SeasonNumber);
	}
}