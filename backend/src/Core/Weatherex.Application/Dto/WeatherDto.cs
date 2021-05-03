using Newtonsoft.Json;
using System;

namespace Weatherex.Application.Dto
{
    public class WeatherDto
    {
        [JsonPropertyAttribute("id")]
        public string Id { get; set; }

        [JsonPropertyAttribute("weather_state_name")]
        public string WeatherStateName { get; set; }

        [JsonPropertyAttribute("weather_state_abbr")]
        public string WeatherStateAbbr { get; set; }

        [JsonPropertyAttribute("wind_direction_compass")]
        public string WindDirectionCompass { get; set; }

        [JsonPropertyAttribute("created")]
        public DateTime Created { get; set; }

        [JsonPropertyAttribute("applicable_date")]
        public string ApplicableDate { get; set; }

        [JsonPropertyAttribute("min_temp")]
        public double MinTemp { get; set; }

        [JsonPropertyAttribute("max_temp")]
        public double MaxTemp { get; set; }

        [JsonPropertyAttribute("the_temp")]
        public double TheTemp { get; set; }

        [JsonPropertyAttribute("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonPropertyAttribute("wind_direction")]
        public double WindDirection { get; set; }

        [JsonPropertyAttribute("air_pressure")]
        public double AirPressure { get; set; }

        [JsonPropertyAttribute("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyAttribute("visibility")]
        public double Visibility { get; set; }

        [JsonPropertyAttribute("predictability")]
        public int Predictability { get; set; }
    }
}
