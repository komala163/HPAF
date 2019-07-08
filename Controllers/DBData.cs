using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HPAF.Controllers
{
    public class DBData
    {
        SqlConnection con = null;
        string connSTR = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlCommand cmd = null;
        SqlDataAdapter sda = null;

        public int InsertOnBoardCustomerDetails_db(string jsoncustomer, string jsonguaranter, string jsonvehicle, string jsonscheme)
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(connSTR))
                {
                    using (cmd = new SqlCommand("InsertOnBoardCustomerDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@jsoncustomer", jsoncustomer);
                        cmd.Parameters.AddWithValue("@jsonguaranter", jsonguaranter);
                        cmd.Parameters.AddWithValue("@jsonvehicle", jsonvehicle);
                        cmd.Parameters.AddWithValue("@jsonscheme", jsonscheme);
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        con.Close();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                //ErrorLogger.Log(ex.Message.ToString(), "Exception on Retrieving BrandList.");
                return -1;
            }
            finally
            {
                con.Close();
            }
        }



        //EMIPayment
        public DataTable GetDataforEMIUpdate(string EMIPaymentInput)
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(connSTR))
                {
                    using (cmd = new SqlCommand("GetDataforEMIUpdate", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EMIPaymentInput", EMIPaymentInput);
                        con.Open();
                        using (sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                //ErrorLogger.Log(ex.Message.ToString(), "Exception on Retrieving BrandList.");
                var k = ex.ToString();
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable EMIPaymentTableRecord(string EMIPaymentInput)
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(connSTR))
                {
                    using (cmd = new SqlCommand("GetTableDataforEMIPayment", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EMIPaymentInput", EMIPaymentInput);
                        con.Open();
                        using (sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                //ErrorLogger.Log(ex.Message.ToString(), "Exception on Retrieving BrandList.");
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public int UpdateEMIPayment_db(string jsonEMI)
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(connSTR))
                {
                    using (cmd = new SqlCommand("UpdateEMIPayment", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@jsonEMI", jsonEMI);
                        
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        con.Close();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                //ErrorLogger.Log(ex.Message.ToString(), "Exception on Retrieving BrandList.");
                return -1;
            }
            finally
            {
                con.Close();
            }
        }


        //Geenerate Due List

        public DataTable GetDataforGenerateDueList(string LocationCode)
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(connSTR))
                {
                    using (cmd = new SqlCommand("GetDetailsForGenerateDueList", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LocationCode", LocationCode);
                        con.Open();
                        using (sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                //ErrorLogger.Log(ex.Message.ToString(), "Exception on Retrieving BrandList.");
                //var k = ex.ToString();
                return null;
            }
            finally
            {
                con.Close();
            }
        }


         #region Login
        public DataTable UserDetails(string username,string password)
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(connSTR))
                {
                    using (cmd = new SqlCommand("usp_fetchUserProfileDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        con.Open();
                        using (sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
               // ErrorLogger.Log(ex.Message.ToString(), "Exception on Login User Details");
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void LogUserActivity(int userId, string eventName, DateTime createdDate)
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(connSTR))
                {
                    using (cmd = new SqlCommand("usp_logUserActivity", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userID", userId);
                        cmd.Parameters.AddWithValue("@eventName", eventName);
                        cmd.Parameters.AddWithValue("@date", createdDate);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //ErrorLogger.Log(ex.Message.ToString(), "Exception on logging user activity");
                //return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion


    }
}