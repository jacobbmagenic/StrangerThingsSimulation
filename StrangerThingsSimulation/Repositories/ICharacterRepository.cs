using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StrangerThings.Common.Models;

namespace StrangerThings.Server.Repositories
{
	public interface ICharacterRepository
	{
		/// <summary>
		/// Returns JSON data for all characters in the database
		/// </summary>
		/// <returns>Task<List<Character>></returns>
		Task<List<Character>> GetAllCharactersAsync();

		/// <summary>
		/// Returns JSON data for character corresponding to the input name
		/// </summary>
		/// <param name="characterName">Input character name</param>
		/// <returns>Task<Character></returns>
		Task<Character> GetCharacterByNameAsync(string characterName);

		/// <summary>
		/// Returns JSON data for character created if successful
		/// </summary>
		/// <param name="character">Input character object</param>
		/// <returns>Task<Character></returns>
		Task<Character> CreateCharacterAsync(Character character);

		/// <summary>
		/// Updates and returns JSON data for character corresponding to the given name
		/// </summary>
		/// <param name="characterName">Input character name</param>
		/// <param name="character">Input character object</param>
		/// <returns>Task<Character></returns>
		Task<Character> UpdateCharacterAsync(string characterName, Character character);

		/// <summary>
		/// Returns JSON data for the deleted character
		/// </summary>
		/// <param name="characterName">Input character name to be deleted</param>
		/// <returns>Task<Character></returns>
		Task<Character> DeleteCharacterByNameAsync(string characterName);
	}
}