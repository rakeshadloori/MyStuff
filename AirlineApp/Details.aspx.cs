using AirlineBO;
using AirlineDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirlineApp
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGv();
                
            }
        }

        private void BindGv()
        {
            gvAirlines.DataSource = AirDAL.getAirlineDetails();
            gvAirlines.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AirBO air = new AirBO();

            air.name = txtAirline.Text;
            air.origin = txtOrigin.Text;
            air.destination = txtDestination.Text;
            air.classid = Convert.ToInt32(ddlClass.SelectedValue);
            air.cost = Convert.ToInt32(txtCost.Text);

            if(hdnIsSave.Value == "0")
            {
                AirDAL.createAirlineDetails(air);
                BindGv();
                txtAirline.Text = "";
                txtOrigin.Text = "";
                txtDestination.Text = "";
                txtCost.Text = "";
                ddlClass.SelectedIndex = 0;
            }
            else
            {
                air.id = Convert.ToInt32(hdnAid.Value);
                AirDAL.updateAirlineDetails(air);
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

        protected void ibDelete_Command(object sender, EventArgs e)
        {
            try
            {
                ImageButton ibDelete = (ImageButton)sender;
                int Aid = Convert.ToInt32(ibDelete.Attributes["Aid"].ToString());
                AirDAL.deleteAirlineDetails(Aid);
                BindGv();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void lbAid_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbEdit = (LinkButton)sender;
            hdnAid.Value = lbEdit.Attributes["Aid"].ToString();
            hdnIsSave.Value = lbEdit.Attributes["Aid"].ToString();
            int Aid = Convert.ToInt32(lbEdit.Attributes["Aid"].ToString());
            txtAirline.Text = lbEdit.Attributes["Name"].ToString();
            txtOrigin.Text = lbEdit.Attributes["Origin"].ToString();
            txtDestination.Text = lbEdit.Attributes["Destination"].ToString();
            txtCost.Text = lbEdit.Attributes["Cost"].ToString();

            string AirClass = lbEdit.Attributes["Class"].ToString();
            ddlClass.ClearSelection();
            ddlClass.Items.FindByText(AirClass).Selected = true;
            btnSave.Text = "Update";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            hdnIsSave.Value = "0";
            txtAirline.Text = "";
            txtOrigin.Text = "";
            txtDestination.Text = "";
            txtCost.Text = "";
            ddlClass.SelectedIndex = 0;
        }
    }
}