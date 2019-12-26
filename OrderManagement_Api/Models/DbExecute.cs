using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace OrderManagement_Api.Models
{
    public class DbExecute
    {

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["Title_Product_Connection"].ConnectionString;

        // Function to get all records -- Parameter -> procedure name
        public static DataTable GetMultipleRecord(string store_procedure_name)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmdLoadBillfrom = new SqlCommand(store_procedure_name, con);
                cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
                using (con)
                {
                    cmdLoadBillfrom.Connection = con;
                    cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmdLoadBillfrom))
                    {
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        // Function to get all records based on some parameters -- Parameter -> Procedure name &  Array of condition / single also
        public static DataTable GetMultipleRecordByParam(string store_procedure_name, Dictionary<string, object> param)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmdLoadBillfrom = new SqlCommand(store_procedure_name, con);
                cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
                if (param.Count() > 0)
                {
                    foreach (var p in param)
                    {
                        cmdLoadBillfrom.Parameters.AddWithValue(p.Key, p.Value);
                    }
                }
                using (con)
                {
                  //  cmdLoadBillfrom.Connection = con;
                    //cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmdLoadBillfrom))
                    {
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        // Function to get all records based on some parameters -- Parameter -> Procedure name &  string as where clause
        public static DataTable GetMultipleRecordByStringParam(string store_procedure_name, string param)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmdLoadBillfrom = new SqlCommand(store_procedure_name, con);
                cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
                cmdLoadBillfrom.Parameters.AddWithValue("mywhere", param);
                using (con)
                {
                    cmdLoadBillfrom.Connection = con;
                    cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmdLoadBillfrom))
                    {
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }finally
            {
                con.Close();
            }
        }
        public static DataTable GetMultipleRecordByString(string store_procedure_name, string param)
        {
                SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmdLoadBillfrom = new SqlCommand(store_procedure_name, con);
                cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
                cmdLoadBillfrom.Parameters.AddWithValue("mywhere", param);
                using (con)
                {
                    cmdLoadBillfrom.Connection = con;
                    cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmdLoadBillfrom))
                    {
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public static int ExecuteSPForCRUD(string Procedure_Name, Dictionary<string, object> param)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            DataTable dt = new DataTable();
            SqlCommand cmdLoadBillfrom = new SqlCommand(Procedure_Name, con);
            cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
            int count = 0;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Procedure_Name, con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var p in param)
                {
                    //cmdLoadBillfrom.Parameters.AddWithValue("@", param);
                    cmd.Parameters.AddWithValue((string)p.Key, p.Value);
                }
                int n = cmd.ExecuteNonQuery();
                con.Close();
                if (n > 0)
                {
                    count = 1;
                }
                else
                {
                    count = 0;
                }
            }
            catch
            {
                count = 0;
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return count;
        }


        public static object ExecuteSPForScalar(string Procedure_Name, Dictionary<string, object> param)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            DataTable dt = new DataTable();
            SqlCommand cmdLoadBillfrom = new SqlCommand(Procedure_Name, con);
            cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
            object value;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Procedure_Name, con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var p in param)
                {
                    // cmdLoadBillfrom.Parameters.AddWithValue("@", param);
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
                value = cmd.ExecuteScalar();
                con.Close();
                return value;
            }
            catch
            {
                value = 0;
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return value;
        }
    }
}