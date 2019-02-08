using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StrangerThings.Common.Models;
using StrangerThings.Server.Repositories;
using StrangerThings.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StrangerThings.Server.Tests.UnitTests
{
	[TestClass]
	public class SeasonServiceTests
	{
		[TestMethod]
		public void GetAllSeasonsAsyncTest()
		{
			//Initialization
			var expectedSeasons = 1;

			//Mock
			var mockSeasonRepository = new Mock<ISeasonRepository>();
			mockSeasonRepository.Setup(cn => cn.GetAllSeasonsAsync())
				.ReturnsAsync(() => new List<Season>() { new Season { SeasonNumber = 1, SeasonRating = 5, ReleaseDate = new DateTime(10/10/2016) } });

			//Service calls
			var seasonService = new SeasonService(mockSeasonRepository.Object);
			var seasons = seasonService.GetAllSeasonsAsync().Result;

			Assert.AreEqual(seasons.Count(), expectedSeasons);
		}

		[TestMethod]
		public void GetSeasonByNumberAsyncTest()
		{
			//Initialization
			var expectedSeason = new Season { SeasonNumber = 1, SeasonRating = 5, ReleaseDate = new DateTime(10/10/2016) };

			//Mock
			var mockSeasonRepository = new Mock<ISeasonRepository>();
			mockSeasonRepository.Setup(cn => cn.GetSeasonByNumberAsync(It.IsAny<int>()))
				.ReturnsAsync(() => new Season { SeasonNumber = 1, SeasonRating = 5, ReleaseDate = new DateTime(10/10/2016) });

			//Service calls
			var seasonService = new SeasonService(mockSeasonRepository.Object);
			var season = seasonService.GetSeasonByNumberAsync(1).Result;

			Assert.AreEqual(season.SeasonNumber, 1);
		}

		[TestMethod]
		public void CreateSeasonAsyncTest()
		{
			//Initialization
			var epsiodeToCreate = new Season { SeasonNumber = 1, SeasonRating = 5, ReleaseDate = new DateTime(10/10/2016) };

			//Mock
			var mockSeasonRepository = new Mock<ISeasonRepository>();
			mockSeasonRepository.Setup(cn => cn.CreateSeasonAsync(It.IsAny<Season>()))
				.ReturnsAsync(() => new Season { SeasonNumber = 1, SeasonRating = 5, ReleaseDate = new DateTime(10/10/2016) });

			//Service calls
			var seasonService = new SeasonService(mockSeasonRepository.Object);
			var seasonCreated = seasonService.CreateSeasonAsync(epsiodeToCreate).Result;

			Assert.AreEqual(seasonCreated.SeasonNumber, epsiodeToCreate.SeasonNumber);
		}

		[TestMethod]
		public void UpdateSeasonAsyncTest()
		{
			//Initialization
			var epsiodeToUpdate = new Season { SeasonNumber = 1, SeasonRating = 5, ReleaseDate = new DateTime(10/10/2016) };
			var expectedSeason = new Season { SeasonNumber = 1, SeasonRating = 4, ReleaseDate = new DateTime(10/10/2016) };

			//Mock
			var mockSeasonRepository = new Mock<ISeasonRepository>();
			mockSeasonRepository.Setup(cn => cn.UpdateSeasonAsync(It.IsAny<int>(), It.IsAny<Season>()))
				.ReturnsAsync(() => new Season { SeasonNumber = 1, SeasonRating = 4, ReleaseDate = new DateTime(10/10/2016) });

			//Service calls
			var seasonService = new SeasonService(mockSeasonRepository.Object);
			var seasonUpdated = seasonService.UpdateSeasonAsync(1, epsiodeToUpdate).Result;

			Assert.AreEqual(seasonUpdated.SeasonRating, expectedSeason.SeasonRating);
		}

		[TestMethod]
		public void DeleteSeasonByNumberAsync()
		{
			//Initialization
			var expectedDeletedSeason = new Season { SeasonNumber = 1, SeasonRating = 5, ReleaseDate = new DateTime(10/10/2016) };

			//Mock
			var mockSeasonRepository = new Mock<ISeasonRepository>();
			mockSeasonRepository.Setup(cn => cn.DeleteSeasonByNumberAsync(It.IsAny<int>()))
				.ReturnsAsync(() => new Season { SeasonNumber = 1, SeasonRating = 5, ReleaseDate = new DateTime(10/10/2016) });

			//Service calls
			var seasonService = new SeasonService(mockSeasonRepository.Object);
			var season = seasonService.DeleteSeasonByNumberAsync(1).Result;

			Assert.AreEqual(season.SeasonNumber, 1);
		}
	}
}
