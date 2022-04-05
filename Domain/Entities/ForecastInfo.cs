using Domain.Entities.WeatherForestcast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
     public class ForecastInfo
    {
        public List<Daily> daily { get; set; }
    }
}
