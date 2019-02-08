using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrangerThings.Client.Services;
using StrangerThings.Common.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace StrangerThings.Server.Tests.IntegrationTests
{
	[TestClass]
	public class EpisodeControllerIntegrationTests
	{
		private string baseUrl;

		[TestInitialize]
		public void Initialize()
		{
			baseUrl = "https://localhost:44385/";
		}

		[TestMethod]
		public void GetAllEpisodesAsyncTest()
		{
			var episodeClientService = new EpisodeClientService(baseUrl);
			var episodes = episodeClientService.GetAllEpisodes();

			Assert.IsNotNull(episodes);
		}

		[TestMethod]
		public void GetEpisodeByNumberTest()
		{
			var episodeNumber = 1;
			var episodeClientService = new EpisodeClientService(baseUrl);
			var episode = episodeClientService.GetEpisodeByNumber(episodeNumber);

			Assert.AreEqual(episode.EpisodeNumber, episodeNumber);
		}

		[TestMethod]
		public void GetEpisodesWithCharacterTest()
		{
			var characterName = "Bob";
			var episodeClientService = new EpisodeClientService(baseUrl);
			var episodes = episodeClientService.GetEpisodesWithCharacter(characterName);

			Assert.IsNotNull(episodes);
		}

		[TestCleanup]
		public void Cleanup()
		{
			// TODO : Cleanup post methods here, revert DB to original state (not testing anything but gets at the moment)
		}
	}
}
