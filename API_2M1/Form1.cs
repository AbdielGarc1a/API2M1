using Appcore.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_2M1
{
    public partial class Form1 : Form
    {
        private IWeatherService wheaterservice;
        public Form1(IWeatherService wheaterservice)
        {
            this.wheaterservice = wheaterservice;
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                var climas = wheaterservice.GetWeather(txtCiudad.Text);
                lblVelV.Text = climas.wind.speed.ToString() + " m/s";
                lblT.Text = (climas.main.temp-273).ToString() + " C°";
                lblAmanecer.Text = wheaterservice.convertToDateTime(climas.sys.sunset).ToShortTimeString();
                lblAtardecer.Text = wheaterservice.convertToDateTime(climas.sys.sunrise).ToShortTimeString();
                lblPresion.Text = climas.main.pressure.ToString();
                lblMinTemp.Text =( climas.main.temp_min-273).ToString() + "  C°";
                lblMaxTemp.Text = (climas.main.temp_max-273).ToString() + "  C°";
                lblHuminity.Text = climas.main.humidity.ToString();
                ptbIcon.ImageLocation = wheaterservice.GetImageLocation(climas.weather[0]);
                lblCondicion.Text = climas.weather[0].main.ToString();
                lblDetalles.Text = climas.weather[0].description.ToString();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
