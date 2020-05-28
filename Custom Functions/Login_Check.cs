using System;
using System.Configuration;
using System.Data.SqlClient;

namespace RobotRecipeManager.Custom_Functions
{
    class Login_Check
    {
        public Tuple<bool, string> Check_Login(string user_name, string user_pass)
        {
            string user_role = "";
            Boolean check = true;
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM[AU_RRM_EM].[dbo].[USERS] ", sqlConnection))
            {
                try
                {
                    sqlConnection.Open();
                    //float intList = (float)
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string name = reader["USERNAME"].ToString();
                            string ini = reader["INITIALS"].ToString();
                            string pass = reader["PASSWORDS"].ToString();
                            string role = reader["ROLES"].ToString();
                            if (user_name == name || user_name == ini)
                            {
                                if (pass == user_pass)
                                {
                                    user_role = role;
                                    check = true;
                                    reader.Close();
                                }
                            }
                            else
                            {
                                check = false;
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
                return new Tuple<bool, string>(check, user_role);
            }
        }
    }
}