using Domain.Entities;
using Domain.Entities.WeatherInfo;
using Domain.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Infraestructure
{
    public class JsonWeatherRepository: IWeatherInfo
    {
        private Root info;
        private ForecastInfo forecastInfo;
        private double lat;
        private double lon;
        private const string APIKEY = "db4fdcfcdeb09e6c36b4ef18af3b59dc";
        public Root GetWeather(string ciudad)
        {
            using (WebClient web = new WebClient())
            {
                string url = $@"https://api.openweathermap.org/data/2.5/weather?q={ciudad}&appid={APIKEY}";
                var json = web.DownloadString(url);
                info = JsonConvert.DeserializeObject<Root>(json);
                lat = info.coord.lat;
                lon = info.coord.lon;
                return info;
            }
        }
        public string GetImageLocation(Weather w)
        {
            string imageLocation = $@"https://openweathermap.org/img/w/{w.icon}.png";
            return imageLocation;
        }
        public ForecastInfo GetWeatherForecast()
        {
            using (WebClient web = new WebClient())
            {
                string url = $@"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&exclude=current,minutely,hourly,alerts&appid={APIKEY}";
                var json = web.DownloadString(url);
                forecastInfo = JsonConvert.DeserializeObject<ForecastInfo>(json);
            }
            return forecastInfo;
        }
        public DateTime convertToDateTime(long milisegundos)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(milisegundos).ToLocalTime();
            return day;
        }
    }
}
