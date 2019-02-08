using Dapper;
using Microsoft.AspNetCore.Mvc;
using StrangerThings.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrangerThings.Server.Repositories
{
	/// <summary>
	/// Repository containing access to DB operations related to characters
	/// </summary>
	public class CharacterRepository : ICharacterRepository
	{
		private IConnectionFactory _ConnectionFactory;

		/// <summary>
		/// Instantiate CharacterRepository with ConnectionFactory injection
		/// </summary>
		/// <param name="connectionFactory">Variable containing DB connection data</param>
		public CharacterRepository(IConnectionFactory connectionFactory)
		{
			_ConnectionFactory = connectionFactory;
		}

		/// <summary>
		/// Returns JSON data for all characters in the database
		/// </summary>
		/// <returns>Task<List<Character>></returns>
		public async Task<List<Character>> GetAllCharactersAsync()
		{
			var query = $"Select [Id], [Name], [Gender], [Age] From [dbo].[Character]";

			using (var cn = _ConnectionFactory.GetConnection())
			{
				var characters = await cn.QueryAsync<Character>(query);
				cn.Dispose();
				return characters.ToList();
			}
		}

		/// <summary>
		/// Returns JSON data for character corresponding to the input name
		/// </summary>
		/// <param name="characterName">Input character name</param>
		/// <returns>Task<Character></returns>
		public async Task<Character> GetCharacterByNameAsync(string characterName)
		{
			var query = $"Select [Id], [Name], [Gender], [Age] From [dbo].[Character] Where [Name] Like \'{characterName}\'";

			using (var cn = _ConnectionFactory.GetConnection())
			{
				var character = await cn.QueryAsync<Character>(query);
				cn.Dispose();

				if (!character.Any())
				{
					throw new Exception("No chatacters found for the given input.");
				}
				else
					return character.FirstOrDefault();
			}
		}

		/// <summary>
		/// Returns JSON data for character created if successful
		/// </summary>
		/// <param name="character">Input character object</param>
		/// <returns>Task<Character></returns>
		public async Task<Character> CreateCharacterAsync(Character character)
		{
			try
			{
				var query = $"INSERT INTO [dbo].[Character] ([Name],[Gender],[Age]) " +
					$"Output inserted.Id, inserted.Name, inserted.Gender, inserted.Age " +
					$"Values(\'{character.Name}\', \'{character.Gender}\', {character.Age})";

				using (var cn = _ConnectionFactory.GetConnection())
				{
					var characterAdded = await cn.QueryAsync<Character>(query);
					cn.Dispose();
					return characterAdded.FirstOrDefault();
				}
			}
			catch
			{
				throw new Exception("Invalid input character name.");
			}
		}

		/// <summary>
		/// Updates and returns JSON data for character corresponding to the given name
		/// </summary>
		/// <param name="characterName">Input character name</param>
		/// <param name="character">Input character object</param>
		/// <returns>Task<Character></returns>
		public async Task<Character> UpdateCharacterAsync(string characterName, Character character)
		{
			try
			{
				var query = $"Update [dbo].[Character] " +
					$"SET [Name] = \'{character.Name}\', [Gender] = \'{character.Gender}\', [Age] = {character.Age} " +
					$"Output inserted.Id, inserted.Name, inserted.Gender, inserted.Age " +
					$"Where [Name] Like \'{characterName}\'";

				using (var cn = _ConnectionFactory.GetConnection())
				{
					var characterUpdated = await cn.QueryAsync<Character>(query);
					cn.Dispose();
					return characterUpdated.FirstOrDefault(); //TODO: Handle case of bad query
				}
			}
			catch
			{
				throw new Exception("Invalid input character name.");  //TODO:  Implement better error handling and logging
			}
		}

		/// <summary>
		/// Returns JSON data for the deleted character
		/// </summary>
		/// <param name="characterName">Input character name to be deleted</param>
		/// <returns>Task<Character></returns>
		public async Task<Character> DeleteCharacterByNameAsync(string characterName)
		{
			var query = $"Select [Name],[Gender],[Age] From [dbo].[Character] Where [Name] Like \'{characterName}\' " +
				$"Delete From [dbo].[Character] Where [Name] Like \'{characterName}\'";

			using (var cn = _ConnectionFactory.GetConnection())
			{
				var deletedCharacter = await cn.QueryAsync<Character>(query);
				cn.Dispose();

				if (!deletedCharacter.Any())
				{
					throw new Exception("No characters found for the given inputs.");  //TODO:  Implement better error handling and logging
				}
				else
					return deletedCharacter.FirstOrDefault();
			}
		}
	}
}
