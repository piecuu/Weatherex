using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Weatherex.Application.Dto
{
    public class LocationDto
    {
        [JsonPropertyAttribute("consolidated_weather")]
        public List<WeatherDto> ConsolidatedWeather { get; set; }

        [JsonPropertyAttribute("time")]
        public DateTime Time { get; set; }

        [JsonPropertyAttribute("sun_rise")]
        public DateTime SunRise { get; set; }

        [JsonPropertyAttribute("sun_set")]
        public DateTime SunSet { get; set; }

        [JsonPropertyAttribute("timezone_name")]
        public string TimezoneName { get; set; }

        [JsonPropertyAttribute("parent")]
        public Parent Parent { get; set; }

        [JsonPropertyAttribute("sources")]
        public List<Source> Sources { get; set; }

        [JsonPropertyAttribute("title")]
        public string Title { get; set; }

        [JsonPropertyAttribute("location_type")]
        public string LocationType { get; set; }

        [JsonPropertyAttribute("woeid")]
        public int Woeid { get; set; }

        [JsonPropertyAttribute("latt_long")]
        public string LattLong { get; set; }

        [JsonPropertyAttribute("timezone")]
        public string Timezone { get; set; }
    }

    public class Parent
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

    public class Source
    {
        [JsonPropertyAttribute("title")]
        public string Title { get; set; }

        [JsonPropertyAttribute("slug")]
        public string Slug { get; set; }

        [JsonPropertyAttribute("url")]
        public string Url { get; set; }

        [JsonPropertyAttribute("crawl_rate")]
        public int CrawlRate { get; set; }
    }
}
