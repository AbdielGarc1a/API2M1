using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.WeatherInfo
{
    public class  AmAt
    {
        public long sunrise { get; set; }
        public long sunset { get; set; }
        public string country { get; set; }
    }
}
