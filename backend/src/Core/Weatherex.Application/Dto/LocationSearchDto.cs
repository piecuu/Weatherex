using Newtonsoft.Json;

namespace Weatherex.Application.Dto
{
    public class LocationSearchDto
    {
        [JsonPropertyAttribute("title")]
        public string Title { get; set; }

        [JsonPropertyAttribute("location_type")]
        public string LocationType { get; set; }

        [JsonPropertyAttribute("woeid")]
        public int Woeid { get; set; }

        [JsonPropertyAttribute("latt_long")]
        public string LattLong { get; set; }
    }
}
