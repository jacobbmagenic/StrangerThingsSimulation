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
	/// Service class containing various methods related to Stranger Things characters
	/// </summary>
	public class CharacterService : ICharacterService
	{
		private readonly ICharacterRepository _CharacterRepository;

		/// <summary>
		/// Instantiate CharacterService with CharacterRepository injection
		/// </summary>
		/// <param name="characterRepository">Variable containing DB access methods for CRUD operations</param>
		public CharacterService(ICharacterRepository characterRepository)
		{
			_CharacterRepository = characterRepository;
		}

		/// <summary>
		/// Makes a call to the CharacterRepository to get JSON data for all characters in the database
		/// </summary>
		/// <returns>Task<List<Character>></returns>
		public async Task<List<Character>> GetAllCharactersAsync()
		{
			return await _CharacterRepository.GetAllCharactersAsync();
		}

		/// <summary>
		/// Makes a call to the CharacterRepository to get JSON data for character corresponding to the given name
		/// </summary>
		/// <param name="characterName">The character name</param>
		/// <returns>Task<Character></returns>
		public async Task<Character> GetCharacterByNameAsync(string characterName)
		{
			return await _CharacterRepository.GetCharacterByNameAsync(characterName);
		}

		/// <summary>
		/// Makes a call to the CharacterRepository to post given character, returns character if added successfully
		/// </summary>
		/// <param name="character">Character being added</param>
		/// <returns>Character</returns>
		public async Task<Character> CreateCharacterAsync(Character character)
		{
			return await _CharacterRepository.CreateCharacterAsync(character);
		}

		/// <summary>
		/// Makes a call to the CharacterRepository to update given character, returns character if updated successfully
		/// </summary>
		/// <param name="characterName">The character name</param>
		/// <param name="character">Character being added</param>
		public async Task<Character> UpdateCharacterAsync(string characterName, Character character)
		{
			return await _CharacterRepository.UpdateCharacterAsync(characterName, character);
		}

		/// <summary>
		/// Makes a call to the CharacterRepository to delete given character, returns character if found and deleted successfully
		/// </summary>
		/// <param name="characterName"></param>
		/// <returns></returns>
		public async Task<Character> DeleteCharacterByNameAsync(string characterName)
		{
			return await _CharacterRepository.DeleteCharacterByNameAsync(characterName);
		}
	}
}
