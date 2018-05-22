using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MusicFinderXamarin.Services;
using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    public class ApiRest
    {
        public const string SERVICE_ENDPOINT = "https://musicbrainz.org/ws/2/";

        public async Task<string> GetJson()
        {
            var client = CreateClient();
            var json = await client.GetStringAsync(CreateUrl("artist/?query=artist:blink-182"));

            //Debug.WriteLine(json);

            // get artist
            var artistList = JsonConvert.DeserializeObject<ArtistList>(json);

            // get releases
            json = await client.GetStringAsync(CreateUrl("release/?query=arid:" + artistList.Artists[0].MbId));

            var releases = JsonConvert.DeserializeObject<ReleaseList>(json);

            // get songs
            json = await client.GetStringAsync(CreateUrl("recording/?query=reid:" + releases.Releases[0].MbId));

            var recordings = JsonConvert.DeserializeObject<RecordingList>(json);

            return json;
        }

        public async Task<List<Artist>> GetArtists(string searchQuery)
        {
            var client = CreateClient();
            var json = await client.GetStringAsync(CreateUrl("artist/?query=artist:" + searchQuery));

            // get artist
            var artistList = JsonConvert.DeserializeObject<ArtistList>(json);

            return artistList.Artists;
        }

        public async Task<List<Release>> GetReleases(string artistId)
        {
            var client = CreateClient();
            
            // get releases
            var json = await client.GetStringAsync(CreateUrl("release/?query=arid:" + artistId));

            var releases = JsonConvert.DeserializeObject<ReleaseList>(json);

            return releases.Releases;
        }

        private HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(SERVICE_ENDPOINT);
            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("Application-name", "Jefrey-app"));
            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("version", "0.0.1"));
            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("contact-email", "jefsolis-gmail.com"));

            return client;
        }

        private string CreateUrl(string target)
        {
            return string.Format("{0}&fmt=json", target);
        }
    }
}
