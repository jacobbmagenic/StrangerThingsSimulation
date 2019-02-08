using Microsoft.AspNetCore.Mvc;
using StrangerThings.Common.Models;
using StrangerThings.Server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StrangerThingsSimulation.Controllers
{
	/// <summary>
	/// Contains endpoints for tv episode related operations
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class EpisodeController : ControllerBase
	{
		IEpisodeService _EpisodeService;

		/// <summary>
		/// Instantiates the controller with an instance of the EpisodeService
		/// </summary>
		/// <param name="episodeService">Injected EpisodeService class with access to endpoint logic</param>
		public EpisodeController(IEpisodeService episodeService)
		{
			_EpisodeService = episodeService;
		}

		/// <summary>
		/// Returns JSON data for all episodes in the database
		/// </summary>
		/// <returns>Task<ActionResult<IEnumerable<Episode>>></returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Episode>>> Get()
		{
			return await _EpisodeService.GetAllEpisodesAsync();
		}


		/// <summary>
		/// Returns JSON data for episode in DB given episode number and season
		/// </summary>
		/// <param name="episodeNumber">The episode number</param>
		/// <returns>Task<ActionResult<Episode>></returns>
		[HttpGet("{episodeNumber}")]
		public async Task<ActionResult<Episode>> Get(int episodeNumber)
		{
			return await _EpisodeService.GetEpisodeByNumberAsync(episodeNumber);
		}

		/// <summary>
		/// Returns JSON data for episode that a given character is featured in
		/// </summary>
		/// <param name="characterName">The character that must be in each episode returned</param>
		/// <returns>Task<ActionResult<Episode>></returns>
		[HttpGet]
		[Route("api/episode/getEpisodesWithCharacter/{name}")]
		public async Task<ActionResult<List<Episode>>> GetEpisodesWithCharacter(int episodeNumber)          // -- TODO --
		{
			//return await _EpisodeService.GetEpisodesWithCharacterAsync(episodeNumber);
			return null;
		}

		/// <summary>
		/// Posts a new episode with the given body information
		/// </summary>
		/// <param name="episode">Episode being added</param>
		/// <returns>Task<ActionResult<Episode>></returns>
		[HttpPost]
		public async Task<ActionResult<Episode>> Post([FromBody] Episode episode)
		{
			return await _EpisodeService.CreateEpisodeAsync(episode);  // TODO: Note this doesn't handle duplicate data in any way right now
		}

		/// <summary>
		/// Updates a new episode with the given body information
		/// </summary>
		/// <param name="episodeNumber">The episode number</param>
		/// <param name="episode">Episode being updated</param>
		/// <returns>Task<ActionResult<Episode>></returns>
		[HttpPut("{episodeNumber}")]
		public async Task<ActionResult<Episode>> Put(int episodeNumber, [FromBody] Episode episode)
		{
			return await _EpisodeService.UpdateEpisodeAsync(episodeNumber, episode);
		}

		/// <summary>
		/// Deletes an episode of a given number
		/// </summary>
		/// <param name="episodeNumber">The episode number</param>
		/// <returns></returns>
		[HttpDelete("{episodeNumber}")]
		public async Task<ActionResult<Episode>> Delete(int episodeNumber)
		{
			return await _EpisodeService.DeleteEpisodeByNumberAsync(episodeNumber);
		}
	}
}
