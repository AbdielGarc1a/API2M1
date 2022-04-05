using Domain.Entities.WeatherInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Root
    {

        public Coordenadas coord { get; set; }
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public Viento wind { get; set; }
        public AmAt sys { get; set; }
    }
}
