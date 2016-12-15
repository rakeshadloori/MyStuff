using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirlineApp
{
    public partial class WCF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetWeather_Click(object sender, EventArgs e)
        {
            WeatherService.WeatherDataClient client = new WeatherService.WeatherDataClient();
            string result = client.GetWeatherData(txtLocation.Text);
            lblResult.Text = result;
        }
    }
}