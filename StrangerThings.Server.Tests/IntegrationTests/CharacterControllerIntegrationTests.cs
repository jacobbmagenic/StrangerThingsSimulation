using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrangerThings.Client.Services;
using StrangerThings.Common.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace StrangerThings.Server.Tests.IntegrationTests
{
	[TestClass]
	public class CharacterControllerIntegrationTests
	{
		private string baseUrl;

		[TestInitialize]
		public void Initialize()
		{
			baseUrl = "https://localhost:44385/";
		}

		[TestMethod]
		public void GetAllCharactersAsyncTest()
		{
			var characterClientService = new CharacterClientService(baseUrl);
			var characters = characterClientService.GetAllCharacters();

			Assert.IsNotNull(characters);
		}

		[TestMethod]
		public void GetCharacterByNameTest()
		{
			var characterName = "Bob";
			var characterClientService = new CharacterClientService(baseUrl);
			var character = characterClientService.GetCharacterByName(characterName);

			Assert.AreEqual(character.Name, characterName);
		}

		[TestCleanup]
		public void Cleanup()
		{
			// TODO : Cleanup post methods here, revert DB to original state (not testing anything but gets at the moment)
		}
	}
}
