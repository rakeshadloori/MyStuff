using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AirlineApp
{
    public partial class WcfwsHttpBinding : System.Web.UI.Page
    {
        ServiceReference1.IwsHttpBindingClient client = new ServiceReference1.IwsHttpBindingClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGv();
                ddlClass.DataSource = client.GetClass();
                ddlClass.DataTextField = "name";
                ddlClass.DataValueField = "id";
                ddlClass.DataBind();

            }

             

        }

        private void BindGv()
        {
            gvWCFAirlines.DataSource = client.GetData();
            gvWCFAirlines.DataBind();
        }

        protected void lbAid_Command(object sender, CommandEventArgs e)
        {
            LinkButton lb1 = (LinkButton)sender;
            hdnAid.Value = lb1.Attributes["Aid"].ToString();

            txtAirline.Text = lb1.Attributes["Name"].ToString();
            txtOrigin.Text = lb1.Attributes["Origin"].ToString();
            txtDestination.Text = lb1.Attributes["Destination"].ToString();
            txtCost.Text = lb1.Attributes["Cost"].ToString();
            string AirClass = lb1.Attributes["Class"].ToString();
            ddlClass.ClearSelection();
            ddlClass.Items.FindByText(AirClass).Selected = true;
            btnSave.Text = "Update";
            hdnIsSave.Value = lb1.Attributes["Aid"].ToString();
        }

        protected void ibDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ImageButton ibDelete = (ImageButton)sender;
                int Aid = Convert.ToInt32(ibDelete.Attributes["Aid"].ToString());
                client.DeleteData(Aid);
                //AirlineDAL.AirDAL.deleteAirlineDetails(Aid);
                BindGv();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AirlineBO.AirBO air = new AirlineBO.AirBO();
            air.name = txtAirline.Text;
            air.origin = txtOrigin.Text;
            air.destination = txtDestination.Text;
            air.cost = Convert.ToInt32(txtCost.Text);
            air.classid = Convert.ToInt32(ddlClass.SelectedValue);

            if (hdnIsSave.Value == "0")
            {
                client.CreateData(air);         
                BindGv();
                txtAirline.Text = "";
                txtOrigin.Text = "";
                txtDestination.Text = "";
                txtCost.Text = "";
            }
            else
            {
                air.id = Convert.ToInt32(hdnAid.Value);
                client.UpdateData(air);
                //AirlineDAL.AirDAL.updateAirlineDetails(air);
                BindGv();

                txtAirline.Text = "";
                txtOrigin.Text = "";
                txtDestination.Text = "";
                txtCost.Text = "";
                ddlClass.SelectedIndex = 0;

                hdnIsSave.Value = "0";
                btnSave.Text = "Save";
            }
        }
    }
}