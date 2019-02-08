using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StrangerThings.Common.Models;
using StrangerThings.Server.Repositories;
using StrangerThings.Server.Services;
using System.Collections.Generic;
using System.Linq;

namespace StrangerThings.Server.Tests.UnitTests
{
	[TestClass]
	public class CharacterServiceTests
	{
		[TestMethod]
		public void GetAllCharactersAsyncTest()
		{
			//Initialization
			var expectedCharacters = 1;

			//Mock
			var mockCharacterRepository = new Mock<ICharacterRepository>();
			mockCharacterRepository.Setup(cn => cn.GetAllCharactersAsync())
				.ReturnsAsync(() => new List<Character>() { new Character { Name = "testChar", Age = 24, Gender = 'm'} });

			//Service calls
			var characterService = new CharacterService(mockCharacterRepository.Object);
			var characters = characterService.GetAllCharactersAsync().Result;

			Assert.AreEqual(characters.Count(), expectedCharacters);
		}

		[TestMethod]
		public void GetCharacterByNameAsyncTest()
		{
			//Initialization
			var expectedCharacter = new Character { Name = "testChar", Age = 24, Gender = 'm'};

			//Mock
			var mockCharacterRepository = new Mock<ICharacterRepository>();
			mockCharacterRepository.Setup(cn => cn.GetCharacterByNameAsync(It.IsAny<string>()))
				.ReturnsAsync(() => new Character { Name = "testChar", Age = 24, Gender = 'm'});

			//Service calls
			var characterService = new CharacterService(mockCharacterRepository.Object);
			var character = characterService.GetCharacterByNameAsync("testChar").Result;

			Assert.AreEqual(character.Name, "testChar");
		}

		[TestMethod]
		public void CreateCharacterAsyncTest()
		{
			//Initialization
			var epsiodeToCreate = new Character { Name = "testChar", Age = 24, Gender = 'm'};

			//Mock
			var mockCharacterRepository = new Mock<ICharacterRepository>();
			mockCharacterRepository.Setup(cn => cn.CreateCharacterAsync(It.IsAny<Character>()))
				.ReturnsAsync(() => new Character { Name = "testChar", Age = 24, Gender = 'm'});

			//Service calls
			var characterService = new CharacterService(mockCharacterRepository.Object);
			var characterCreated = characterService.CreateCharacterAsync(epsiodeToCreate).Result;

			Assert.AreEqual(characterCreated.Name, epsiodeToCreate.Name);
		}

		[TestMethod]
		public void UpdateCharacterAsyncTest()
		{
			//Initialization
			var epsiodeToUpdate = new Character { Name = "testChar", Age = 24, Gender = 'm'};
			var expectedCharacter = new Character { Name = "testChar", Age = 24, Gender = 'm'};

			//Mock
			var mockCharacterRepository = new Mock<ICharacterRepository>();
			mockCharacterRepository.Setup(cn => cn.UpdateCharacterAsync(It.IsAny<string>(), It.IsAny<Character>()))
				.ReturnsAsync(() => new Character { Name = "testChar", Age = 24, Gender = 'm'});

			//Service calls
			var characterService = new CharacterService(mockCharacterRepository.Object);
			var characterUpdated = characterService.UpdateCharacterAsync("testChar", epsiodeToUpdate).Result;

			Assert.AreEqual(characterUpdated.Name, expectedCharacter.Name);
		}

		[TestMethod]
		public void DeleteCharacterByNameAsync()
		{
			//Initialization
			var expectedDeletedCharacter = new Character { Name = "testChar", Age = 24, Gender = 'm'};

			//Mock
			var mockCharacterRepository = new Mock<ICharacterRepository>();
			mockCharacterRepository.Setup(cn => cn.DeleteCharacterByNameAsync(It.IsAny<string>()))
				.ReturnsAsync(() => new Character { Name = "testChar", Age = 24, Gender = 'm'});

			//Service calls
			var characterService = new CharacterService(mockCharacterRepository.Object);
			var character = characterService.DeleteCharacterByNameAsync("testChar").Result;

			Assert.AreEqual(character.Name, "testChar");
		}
	}
}
