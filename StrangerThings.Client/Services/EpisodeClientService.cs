using Newtonsoft.Json;
using StrangerThings.Common.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace StrangerThings.Client.Services
{
	public class EpisodeClientService
	{
		private string _BaseUrl;

		public EpisodeClientService(string baseUrl)
		{
			_BaseUrl = baseUrl;
		}

		/// <summary>
		/// Returns all episodes
		/// </summary>
		/// <returns>IEnumerable<Episode><returns>
		public IEnumerable<Episode> GetAllEpisodes()
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(_BaseUrl);
				var result = client.GetAsync($"/api/episode").Result;
				if (result.StatusCode != HttpStatusCode.OK)
				{
					return null;
				}
				return JsonConvert.DeserializeObject<IEnumerable<Episode>>(result.Content.ReadAsStringAsync().Result);
			}
		}

		/// <summary>
		/// Returns episode by number
		/// </summary>
		/// <returns>Episode<returns>
		public Episode GetEpisodeByNumber(int episodeNumber)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(_BaseUrl);
				var result = client.GetAsync($"/api/episode/{episodeNumber}").Result;
				if (result.StatusCode != HttpStatusCode.OK)
				{
					return null;
				}
				return JsonConvert.DeserializeObject<Episode>(result.Content.ReadAsStringAsync().Result);
			}
		}

		/// <summary>
		/// Returns episodes containing input character
		/// </summary>
		/// <returns>List<Episode></Episode><returns>
		public List<Episode> GetEpisodesWithCharacter(string characterName)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(_BaseUrl);
				var result = client.GetAsync($"/api/episode/episodes?containingCharacter={characterName}").Result;
				if (result.StatusCode != HttpStatusCode.OK)
				{
					return null;
				}
				return JsonConvert.DeserializeObject<List<Episode>>(result.Content.ReadAsStringAsync().Result);
			}
		}
	}
}