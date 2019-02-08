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
	public class EpisodeServiceTests
	{
		[TestMethod]
		public void GetAllEpisodesAsyncTest()
		{
			//Initialization
			var expectedEpisodes = 1;

			//Mock
			var mockEpisodeRepository = new Mock<IEpisodeRepository>();
			mockEpisodeRepository.Setup(cn => cn.GetAllEpisodesAsync())
				.ReturnsAsync(() => new List<Episode>() { new Episode { EpisodeName = "test", EpisodeNumber = 1, Rating = 5, RuntimeMinutes = 60, SeasonNumber = 1 } });

			//Service calls
			var episodeService = new EpisodeService(mockEpisodeRepository.Object);
			var episodes = episodeService.GetAllEpisodesAsync().Result;

			Assert.AreEqual(episodes.Count(), expectedEpisodes);
		}

		[TestMethod]
		public void GetEpisodeByNumberAsyncTest()
		{
			//Initialization
			var expectedEpisode = new Episode { EpisodeName = "test", EpisodeNumber = 1, Rating = 5, RuntimeMinutes = 60, SeasonNumber = 1 };

			//Mock
			var mockEpisodeRepository = new Mock<IEpisodeRepository>();
			mockEpisodeRepository.Setup(cn => cn.GetEpisodeByNumberAsync(It.IsAny<int>()))
				.ReturnsAsync(() => new Episode { EpisodeName = "test", EpisodeNumber = 1, Rating = 5, RuntimeMinutes = 60, SeasonNumber = 1 });

			//Service calls
			var episodeService = new EpisodeService(mockEpisodeRepository.Object);
			var episode = episodeService.GetEpisodeByNumberAsync(1).Result;

			Assert.AreEqual(episode.EpisodeNumber, 1);
		}

		[TestMethod]
		public void GetEpisodesWithCharacterAsyncTest()
		{
			//Initialization
			var expectedEpisodes = 1;

			//Mock
			var mockEpisodeRepository = new Mock<IEpisodeRepository>();
			mockEpisodeRepository.Setup(cn => cn.GetEpisodesWithCharacterAsync(It.IsAny<string>()))
				.ReturnsAsync(() => new List<Episode>() { new Episode { EpisodeName = "test", EpisodeNumber = 1, Rating = 5, RuntimeMinutes = 60, SeasonNumber = 1} });

			//Service calls
			var episodeService = new EpisodeService(mockEpisodeRepository.Object);
			var episodesWithChar = episodeService.GetEpisodesWithCharacterAsync("Bob").Result;

			Assert.AreEqual(episodesWithChar.Count(), expectedEpisodes);
		}

		[TestMethod]
		public void GetEpisodesWithCharacterAsyncNoneFoundTest()
		{
			//Initialization
			var expectedEpisodes = 0;

			//Mock
			var mockEpisodeRepository = new Mock<IEpisodeRepository>();
			mockEpisodeRepository.Setup(cn => cn.GetEpisodesWithCharacterAsync(It.IsAny<string>()))
				.ReturnsAsync(() => new List<Episode>());

			//Service calls
			var episodeService = new EpisodeService(mockEpisodeRepository.Object);
			var episodesWithChar = episodeService.GetEpisodesWithCharacterAsync("Bob").Result;

			Assert.AreEqual(episodesWithChar.Count(), expectedEpisodes);
		}

		[TestMethod]
		public void CreateEpisodeAsyncTest()
		{
			//Initialization
			var epsiodeToCreate = new Episode { EpisodeName = "test", EpisodeNumber = 1, Rating = 5, RuntimeMinutes = 60, SeasonNumber = 1 };

			//Mock
			var mockEpisodeRepository = new Mock<IEpisodeRepository>();
			mockEpisodeRepository.Setup(cn => cn.CreateEpisodeAsync(It.IsAny<Episode>()))
				.ReturnsAsync(() => new Episode { EpisodeName = "test", EpisodeNumber = 1, Rating = 5, RuntimeMinutes = 60, SeasonNumber = 1 });

			//Service calls
			var episodeService = new EpisodeService(mockEpisodeRepository.Object);
			var episodeCreated = episodeService.CreateEpisodeAsync(epsiodeToCreate).Result;

			Assert.AreEqual(episodeCreated.EpisodeNumber, epsiodeToCreate.EpisodeNumber);
		}

		[TestMethod]
		public void UpdateEpisodeAsyncTest()
		{
			//Initialization
			var epsiodeToUpdate = new Episode { EpisodeName = "test", EpisodeNumber = 1, Rating = 5, RuntimeMinutes = 60, SeasonNumber = 1 };
			var expectedEpisode = new Episode { EpisodeName = "test", EpisodeNumber = 1, Rating = 4, RuntimeMinutes = 60, SeasonNumber = 1 };

			//Mock
			var mockEpisodeRepository = new Mock<IEpisodeRepository>();
			mockEpisodeRepository.Setup(cn => cn.UpdateEpisodeAsync(It.IsAny<int>(), It.IsAny<Episode>()))
				.ReturnsAsync(() => new Episode { EpisodeName = "test", EpisodeNumber = 1, Rating = 4, RuntimeMinutes = 60, SeasonNumber = 1 });

			//Service calls
			var episodeService = new EpisodeService(mockEpisodeRepository.Object);
			var episodeUpdated = episodeService.UpdateEpisodeAsync(1, epsiodeToUpdate).Result;

			Assert.AreEqual(episodeUpdated.Rating, expectedEpisode.Rating);
		}

		[TestMethod]
		public void DeleteEpisodeByNumberAsync()
		{
			//Initialization
			var expectedDeletedEpisode = new Episode { EpisodeName = "test", EpisodeNumber = 1, Rating = 5, RuntimeMinutes = 60, SeasonNumber = 1 };

			//Mock
			var mockEpisodeRepository = new Mock<IEpisodeRepository>();
			mockEpisodeRepository.Setup(cn => cn.DeleteEpisodeByNumberAsync(It.IsAny<int>()))
				.ReturnsAsync(() => new Episode { EpisodeName = "test", EpisodeNumber = 1, Rating = 5, RuntimeMinutes = 60, SeasonNumber = 1 });

			//Service calls
			var episodeService = new EpisodeService(mockEpisodeRepository.Object);
			var episode = episodeService.DeleteEpisodeByNumberAsync(1).Result;

			Assert.AreEqual(episode.EpisodeNumber, 1);
		}
	}
}
