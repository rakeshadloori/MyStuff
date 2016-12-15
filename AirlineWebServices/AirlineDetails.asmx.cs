using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AirlineDAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AirlineWebServices
{
    /// <summary>
    /// Summary description for AirlineDetails
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AirlineDetails : System.Web.Services.WebService
    {
        [WebMethod]
        public DataTable searchAirlines(string ori, string dest)
        {
            string connection = ConfigurationManager.ConnectionStrings["AirlineDBConnectionString"].ToString();

            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            DataTable dtAirlineresult = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "spSearchAirlineDetails";
                cmd.Parameters.AddWithValue("@origin", ori);
                cmd.Parameters.AddWithValue("@destination", dest);

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataSet dsAirlines = new DataSet();
                dataAdapter.Fill(dsAirlines);
                dtAirlineresult = dsAirlines.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dtAirlineresult;
        }



        [WebMethod]
        public DataTable GetAllAirlines()
        {
            //string connection = ConfigurationManager.ConnectionStrings["AirlineDBConnectionString"].ToString();

            DataTable dtAirlines2 = new DataTable();
             try
             {
                 dtAirlines2 = AirDAL.getAirlineDetails();
             }
             catch(Exception ex)
             {
                 Console.WriteLine(ex);
             }

            return dtAirlines2;
            
            /*SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            DataTable dtAirlines = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "spGetAirlineDetails";

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataSet dsAirlines = new DataSet();
                dataAdapter.Fill(dsAirlines);
                dtAirlines = dsAirlines.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dtAirlines;
            */
        }
    }
}
