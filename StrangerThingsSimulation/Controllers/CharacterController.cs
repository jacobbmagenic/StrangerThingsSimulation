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
	/// Contains endpoints for tv character related operations
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class CharacterController : ControllerBase
	{
		ICharacterService _CharacterService;

		/// <summary>
		/// Instantiates the controller with an instance of the CharacterService
		/// </summary>
		/// <param name="characterService">Injected CharacterService class with access to endpoint logic</param>
		public CharacterController(ICharacterService characterService)
		{
			_CharacterService = characterService;
		}

		/// <summary>
		/// Returns JSON data for all characters in the database
		/// </summary>
		/// <returns>Task<ActionResult<IEnumerable<Character>>></returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Character>>> Get()
		{
			return await _CharacterService.GetAllCharactersAsync();
		}

		/// <summary>
		/// Returns JSON data for character given name
		/// </summary>
		/// <param name="characterName">The character name</param>
		/// <returns>Task<Character></returns>
		[HttpGet("{characterName}")]
		public async Task<Character> Get(string characterName)
		{
			return await _CharacterService.GetCharacterByNameAsync(characterName);
		}

		/// <summary>
		/// Posts a new character with the given body information
		/// </summary>
		/// <param name="character">Character being added</param>
		/// <returns>Task<Character></returns>
		[HttpPost]
		public async Task<Character> Post([FromBody] Character character)
		{
			return await _CharacterService.CreateCharacterAsync(character);
		}

		/// <summary>
		/// Updates a new character with the given body information
		/// </summary>
		/// <param name="characterName">The character name</param>
		/// <param name="character">Character being updated</param>
		/// <returns>Task<Character></returns>
		[HttpPut("{characterName}")]
		public async Task<Character> Put(string characterName, [FromBody] Character character)
		{
			return await _CharacterService.UpdateCharacterAsync(characterName, character);
		}

		/// <summary>
		/// Deletes a character of a given name
		/// </summary>
		/// <param name="characterName">The character name</param>
		/// <returns></returns>
		[HttpDelete("{characterName}")]
		public async Task<Character> Delete(string characterName)
		{
			return await _CharacterService.DeleteCharacterByNameAsync(characterName);
		}
	}
}