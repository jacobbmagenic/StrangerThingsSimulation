using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StrangerThings.Common.Models;

namespace StrangerThings.Server.Services
{
	public interface ICharacterService
	{
		/// <summary>
		/// Makes a call to the CharacterRepository to get JSON data for all characters in the database
		/// </summary>
		/// <returns>Task<List<Character>></returns>
		Task<List<Character>> GetAllCharactersAsync();

		/// <summary>
		/// Makes a call to the CharacterRepository to get JSON data for character corresponding to the given name
		/// </summary>
		/// <param name="characterName">The character name</param>
		/// <returns>Task<Character></returns>
		Task<Character> GetCharacterByNameAsync(string characterName);

		/// <summary>
		/// Makes a call to the CharacterRepository to post given character, returns character if added successfully
		/// </summary>
		/// <param name="character">Character being added</param>
		/// <returns>Character</returns>
		Task<Character> CreateCharacterAsync(Character character);

		/// <summary>
		/// Makes a call to the CharacterRepository to update given character, returns character if updated successfully
		/// </summary>
		/// <param name="characterName">The character name</param>
		/// <param name="character">Character being added</param>
		Task<Character> UpdateCharacterAsync(string characterName, Character character);

		/// <summary>
		/// Makes a call to the CharacterRepository to delete given character, returns character if found and deleted successfully
		/// </summary>
		/// <param name="characterName"></param>
		/// <returns></returns>
		Task<Character> DeleteCharacterByNameAsync(string characterName);
	}
}