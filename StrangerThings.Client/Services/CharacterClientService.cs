using Newtonsoft.Json;
using StrangerThings.Common.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace StrangerThings.Client.Services
{
	public class CharacterClientService
	{
		private string _BaseUrl;

		public CharacterClientService(string baseUrl)
		{
			_BaseUrl = baseUrl;
		}

		/// <summary>
		/// Returns all characters
		/// </summary>
		/// <returns>IEnumerable<Character><returns>
		public IEnumerable<Character> GetAllCharacters()
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(_BaseUrl);
				var result = client.GetAsync($"/api/character").Result;
				if (result.StatusCode != HttpStatusCode.OK)
				{
					return null;
				}
				return JsonConvert.DeserializeObject<IEnumerable<Character>>(result.Content.ReadAsStringAsync().Result);
			}
		}

		/// <summary>
		/// Returns character by number
		/// </summary>
		/// <returns>Character<returns>
		public Character GetCharacterByName(string characterName)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(_BaseUrl);
				var result = client.GetAsync($"/api/character/{characterName}").Result;
				if (result.StatusCode != HttpStatusCode.OK)
				{
					return null;
				}
				return JsonConvert.DeserializeObject<Character>(result.Content.ReadAsStringAsync().Result);
			}
		}
	}
}