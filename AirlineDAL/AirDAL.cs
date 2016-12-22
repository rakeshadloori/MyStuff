using AirlineBO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineDAL
{
    public static class AirDAL
    {
        // SQL Connection
        static string connection = ConfigurationManager.ConnectionStrings["AirlineDBConnectionString"].ToString();
        
        public static DataTable getClassDetails()
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            DataTable dtAirlines = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "spGetClass";

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataSet dsAirlines = new DataSet();
                dataAdapter.Fill(dsAirlines);
                dtAirlines = dsAirlines.Tables[0];
                //Comment
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
        }
        public static DataTable getAirlineDetails()
        {
            SqlConnection conn = new SqlConnection(connection);
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
                //Comment
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dtAirlines;
        }
        public static void createAirlineDetails(AirBO air)
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "spCreateAirlineDetails";

                cmd.Parameters.AddWithValue("@name", air.name );
                cmd.Parameters.AddWithValue("@origin", air.origin);
                cmd.Parameters.AddWithValue("@destination", air.destination );
                cmd.Parameters.AddWithValue("@cost", air.cost );
                cmd.Parameters.AddWithValue("@classid", air.classid);
                cmd.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }
        public static void updateAirlineDetails(AirBO air)
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateAirlineDetails";
                cmd.Parameters.AddWithValue("@id", air.id);
                cmd.Parameters.AddWithValue("@name", air.name);
                cmd.Parameters.AddWithValue("@origin", air.origin);
                cmd.Parameters.AddWithValue("@destination", air.destination);
                cmd.Parameters.AddWithValue("@cost", air.cost);
                cmd.Parameters.AddWithValue("@classid", air.classid);
                cmd.ExecuteNonQuery();
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


        }
        public static void deleteAirlineDetails(int Aid)
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "spDeleteAirlineDetails";
                cmd.Parameters.AddWithValue("@id", Aid);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }


        }

    }
}
