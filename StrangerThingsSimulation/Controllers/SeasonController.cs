using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StrangerThings.Common.Models;
using StrangerThings.Server.Services;

namespace StrangerThings.Server.Controllers
{
	/// <summary>
	/// Contains endpoints for tv season related operations
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class SeasonController : ControllerBase
	{
		ISeasonService _SeasonService;

		/// <summary>
		/// Instantiates the controller with an instance of the SeasonService
		/// </summary>
		/// <param name="seasonService">Injected SeasonService class with access to endpoint logic</param>
		public SeasonController(ISeasonService seasonService)
		{
			_SeasonService = seasonService;
		}

		/// <summary>
		/// Returns JSON data for all seasons in the database
		/// </summary>
		/// <returns>Task<ActionResult<IEnumerable<Season>>></returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Season>>> Get()
		{
			return await _SeasonService.GetAllSeasonsAsync();
		}

		/// <summary>
		///  Returns JSON data for season of given number
		/// </summary>
		/// <param name="seasonNumber">The season number</param>
		/// <returns></returns>
		[HttpGet("{seasonNumber}")]
		public async Task<Season> Get(int seasonNumber)
		{
			return await _SeasonService.GetSeasonByNumberAsync(seasonNumber);
		}

		/// <summary>
		/// Posts a new season with the given body information
		/// </summary>
		/// <param name="season">Season being added</param>
		/// <returns>Task<Season></returns>
		[HttpPost]
		public async Task<Season> Post([FromBody] Season season)
		{
			return await _SeasonService.CreateSeasonAsync(season);
		}

		/// <summary>
		/// Updates a new season with the given body information
		/// </summary>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="season">Season being updated</param>
		/// <returns>Task<Season></returns>
		[HttpPut("{seasonNumber}")]
		public async Task<Season> Put(int seasonNumber, [FromBody] Season season)
		{
			return await _SeasonService.UpdateSeasonAsync(seasonNumber, season);
		}

		/// <summary>
		/// Deletes a season of a given name
		/// </summary>
		/// <param name="seasonNumber">The season number</param>
		/// <returns></returns>
		[HttpDelete("{seasonNumber}")]
		public async Task<Season> Delete(int seasonNumber)
		{
			return await _SeasonService.DeleteSeasonByNumberAsync(seasonNumber);
		}
	}
}