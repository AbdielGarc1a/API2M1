using Appcore.Interface;
using Appcore.Service;
using Autofac;
using Domain.Interface;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_2M1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JsonWeatherRepository>().As<IWeatherInfo>();
            builder.RegisterType<WeatherService>().As<IWeatherService>();
            var container = builder.Build();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(container.Resolve<IWeatherService>()));
        }
    }
}
