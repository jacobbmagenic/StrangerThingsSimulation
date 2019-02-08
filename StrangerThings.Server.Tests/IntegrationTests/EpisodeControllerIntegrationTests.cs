using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrangerThings.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrangerThings.Server.Tests.IntegrationTests
{
	[TestClass]
	public class EpisodeControllerIntegrationTests
	{
		protected IConnectionFactory _ConnectionFactory;

		[TestInitialize]
		public void Initialize(IConnectionFactory connectionFactory)
		{
			_ConnectionFactory = connectionFactory;
		}

		[TestMethod]
		public async void GetAllEpisodesAsyncTest()
		{
			Initialize(_ConnectionFactory);
			var tester = new List<Episode>();
			var query = $"Select [Id], [EpisodeNumber], [SeasonNumber], [EpisodeName], [RuntimeMinutes], [Rating] From [dbo].[Episode]";

			using (var cn = _ConnectionFactory.GetConnection())
			{
				var episodes = await cn.QueryAsync<Episode>(query);
				cn.Dispose();
				tester.AddRange(episodes.ToList());
			}

			Assert.AreEqual(tester.Count(), 1);
		}

		[TestCleanup]
		public void Cleanup()
		{
		}
	}
}
