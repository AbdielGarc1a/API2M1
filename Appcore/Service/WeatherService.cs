
using Appcore.Interface;
using Domain.Entities;
using Domain.Entities.WeatherInfo;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appcore.Service
{
    public class WeatherService:IWeatherService
    {
        private IWeatherInfo weatherInfo;

        public WeatherService(IWeatherInfo weatherInfo)
        {
            this.weatherInfo = weatherInfo;
        }

        public DateTime convertToDateTime(long milisegundos)
        {
            return weatherInfo.convertToDateTime(milisegundos);
        }

        public string GetImageLocation(Weather w)
        {
            return weatherInfo.GetImageLocation(w);
        }

        public Root GetWeather(string ciudad)
        {
            return weatherInfo.GetWeather(ciudad);
        }

        public ForecastInfo GetWeatherForecast()
        {
            return weatherInfo.GetWeatherForecast();
        }

    }
}
