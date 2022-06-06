using Fulcro_api.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fulcro_api.DAL
{
    public class Address_Dal
    {
        string conString = ConfigurationManager.ConnectionStrings["AddressContext"].ToString();

        //public bool Check_product(int product_code)
        //{
        //    int flag = 0;

        //        using (SqlConnection connection = new SqlConnection(conString))
        //        {
        //            SqlCommand command = connection.CreateCommand();
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.CommandText = "sp_Sheet1@_check";
        //            command.Parameters.AddWithValue("@P_CODE", product_code);
        //            SqlDataAdapter SqlDA = new SqlDataAdapter(command);
        //            connection.Open();
        //            flag = Convert.ToInt32(command.ExecuteScalar());
        //            connection.Close();
        //        }

        //    return flag>0 ? true:false;
        //}

        
        public Address Get_Address(Input input)
        {
            Address address = new Address();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_Sheet1$_details1";
                command.Parameters.AddWithValue("@P_Code", input.product_code);
                command.Parameters.AddWithValue("@PIN", input.pincode);
                SqlDataAdapter SqlDA = new SqlDataAdapter(command);
                DataTable dtAddress = new DataTable();
                connection.Open();
                SqlDA.Fill(dtAddress);
                connection.Close();

                foreach (DataRow dr in dtAddress.Rows)
                {
                    string temp = null;
                    if (dr["NEG_PIN_CD_IND"].ToString() == "N")
                    { temp = "No"; }
                    else
                        temp = "Yes";

                    address = new Address
                    {
                        statusCode=200,
                        isNegativePincode=temp,
                        data= new Data()
                        {
                            pincode = Convert.ToInt32(dr["PIN_CODE"]),
                            city = dr["CITY"].ToString(),
                            district = dr["DISTRICT"].ToString(),
                            state = dr["STATE_UT"].ToString(),
                            country = "India"
                        }
                    }; 
                }
            }
            return address;
        }

    }
}