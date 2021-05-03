using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weatherex.Application.Dto;
using Weatherex.Application.Interfaces;

namespace Weatherex.Infrastructure.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientFactory _httpFactory;

        public WeatherService(IHttpClientFactory httpFactory)
        {
            _httpFactory = httpFactory;
        }

        public async Task<LocationDto> GetWeatherInLocationAsync(string city)
        {
            var location = await GetLocation(city);

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://www.metaweather.com/api/location/{location.Woeid}"
                );

            var client = _httpFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseStream = await response.Content.ReadAsStreamAsync();
            var result = DeserializeJsonFromStream<LocationDto>(responseStream);

            return result;
        }

        private async Task<LocationSearchDto> GetLocation(string city)
        {
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://www.metaweather.com/api/location/search/?query={city}"
                );

            var client = _httpFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseStream = await response.Content.ReadAsStreamAsync();
            var result = DeserializeJsonFromStream<List<LocationSearchDto>>(responseStream);

            return result.FirstOrDefault();
        }

        private static T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var sr = new StreamReader(stream))
            using (var jtr = new JsonTextReader(sr))
            {
                var js = new JsonSerializer();
                var searchResult = js.Deserialize<T>(jtr);
                return searchResult;
            }
        }
    }
}
