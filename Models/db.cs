using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_Group1V2.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source =test.cnbfneyqkfr8.us-east-1.rds.amazonaws.com, 1433; database=group1lab3;User ID = test; Password=password;");
        public int LoginCheck(User user)
        {
            SqlCommand com = new SqlCommand("User_Login", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@User_id", user.UserId);
            com.Parameters.AddWithValue("@Password", user.Password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;
        }
    }
}
