using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirlineApp
{
    public partial class WebServices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetAll_Click(object sender, EventArgs e)
        {
            AirlineWS1.AirlineDetailsSoapClient details = new AirlineWS1.AirlineDetailsSoapClient();
            gvWSAirlines.DataSource =  details.GetAllAirlines();
            gvWSAirlines.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string origin = txtOrigin.Text;
            string destination = txtDestination.Text;
            AirlineWS1.AirlineDetailsSoapClient details = new AirlineWS1.AirlineDetailsSoapClient();
            gvWSAirlines.DataSource = details.searchAirlines(origin, destination);
            gvWSAirlines.DataBind();
        }
    }
}