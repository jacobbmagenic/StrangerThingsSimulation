using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrangerThings.Client.Services;
using StrangerThings.Common.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace StrangerThings.Server.Tests.IntegrationTests
{
	[TestClass]
	public class SeasonControllerIntegrationTests
	{
		private string baseUrl;

		[TestInitialize]
		public void Initialize()
		{
			baseUrl = "https://localhost:44385/";
		}

		[TestMethod]
		public void GetAllSeasonsAsyncTest()
		{
			var seasonClientService = new SeasonClientService(baseUrl);
			var seasons = seasonClientService.GetAllSeasons();

			Assert.IsNotNull(seasons);
		}

		[TestMethod]
		public void GetSeasonByNumberTest()
		{
			var seasonNumber = 1;
			var seasonClientService = new SeasonClientService(baseUrl);
			var season = seasonClientService.GetSeasonByNumber(seasonNumber);

			Assert.AreEqual(season.SeasonNumber, seasonNumber);
		}

		[TestCleanup]
		public void Cleanup()
		{
			// TODO : Cleanup post methods here, revert DB to original state (not testing anything but gets at the moment)
		}
	}
}
