using Newtonsoft.Json;
using StrangerThings.Common.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace StrangerThings.Client.Services
{
	public class SeasonClientService
	{
		private string _BaseUrl;

		public SeasonClientService(string baseUrl)
		{
			_BaseUrl = baseUrl;
		}

		/// <summary>
		/// Returns all seasons
		/// </summary>
		/// <returns>IEnumerable<Season><returns>
		public IEnumerable<Season> GetAllSeasons()
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(_BaseUrl);
				var result = client.GetAsync($"/api/season").Result;
				if (result.StatusCode != HttpStatusCode.OK)
				{
					return null;
				}
				return JsonConvert.DeserializeObject<IEnumerable<Season>>(result.Content.ReadAsStringAsync().Result);
			}
		}

		/// <summary>
		/// Returns season by number
		/// </summary>
		/// <returns>Season<returns>
		public Season GetSeasonByNumber(int seasonNumber)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(_BaseUrl);
				var result = client.GetAsync($"/api/season/{seasonNumber}").Result;
				if (result.StatusCode != HttpStatusCode.OK)
				{
					return null;
				}
				return JsonConvert.DeserializeObject<Season>(result.Content.ReadAsStringAsync().Result);
			}
		}
	}
}