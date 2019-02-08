using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
		private ILogger _Logger;

		/// <summary>
		/// Instantiate CharacterRepository with ConnectionFactory injection
		/// </summary>
		/// <param name="connectionFactory">Variable containing DB connection data</param>
		public CharacterRepository(IConnectionFactory connectionFactory, ILogger logger)
		{
			_ConnectionFactory = connectionFactory;
			_Logger = logger;
		}

		/// <summary>
		/// Returns JSON data for all characters in the database
		/// </summary>
		/// <returns>Task<List<Character>></returns>
		public async Task<List<Character>> GetAllCharactersAsync()
		{
			try
			{
				var query = $"Select [Id], [Name], [Gender], [Age] From [dbo].[Character]";

				using (var cn = _ConnectionFactory.GetConnection())
				{
					var characters = await cn.QueryAsync<Character>(query);
					cn.Dispose();
					return characters.ToList();
				}
			}
			catch(Exception ex)
			{
				_Logger.LogInformation($"Unexpected error: {ex.ToString()}");
				throw new Exception(ex.ToString());
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

			try
			{
				using (var cn = _ConnectionFactory.GetConnection())
				{
					var character = await cn.QueryAsync<Character>(query);
					cn.Dispose();

					if (!character.Any())
					{
						_Logger.LogInformation("No chatacters found for the given input.");
						throw new Exception("No chatacters found for the given input.");
					}
					else
						return character.FirstOrDefault();
				}
			}
			catch (Exception ex)
			{
				_Logger.LogInformation($"Unexpected error: {ex.ToString()}");
				throw new Exception(ex.ToString());
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
				_Logger.LogInformation("Invalid input character name.");
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
				_Logger.LogInformation("Invalid input character name.");
				throw new Exception("Invalid input character name.");
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
					_Logger.LogInformation("No characters found for the given inputs.");
					throw new Exception("No characters found for the given inputs.");
				}
				else
					return deletedCharacter.FirstOrDefault();
			}
		}
	}
}
