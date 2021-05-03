using System;

namespace Weatherex.Domain.Entities
{
    public class Weather
    {
        public string Title { get; set; }

        public DateTime Time { get; set; }

        public string WeatherState { get; set; }

        public string WeatherAbbreviation { get; set; }
    }
}
