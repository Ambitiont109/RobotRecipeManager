using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace RobotRecipeManager.Custom_Functions
{
    class Validation_OnTopSize
    {
        public void Validation_TopSize(string User_TopSize, Recipe_Creation recipe_Creation)
        {
            string station_Id = "";
            float input_TopSize = 0;
            float output_TopSize = 0;
            Toolbox temp = (Toolbox)recipe_Creation.Flow_Chart.Content;
            for (int i = 0; i < temp.Items.Count; i++)
            {
                Grid tempgrid = (Grid)(temp.Items[i]);
                Image image = new Image();
                int row = 0;
                int column = 0;
                foreach (UIElement child in tempgrid.Children)
                {
                    if (Grid.GetRow(child) == row && Grid.GetColumn(child) == column)
                    {
                        if (child.GetType() == image.GetType())
                        {
                            image = (Image)(child);
                        }
                    }
                }
                using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("Select STATION_ID, INPUT_TOPSIZE,OUTPUT_TOPSIZE from [AU_RRM_EM].[dbo].LIMITS where STATION_ID = '" + tempgrid.Name + "';", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                station_Id = reader["STATION_ID"].ToString();
                                input_TopSize = float.Parse(reader["INPUT_TOPSIZE"].ToString());
                                output_TopSize = float.Parse(reader["OUTPUT_TOPSIZE"].ToString());
                                if (input_TopSize == output_TopSize)
                                {
                                    if (input_TopSize != float.Parse(User_TopSize))
                                    {
                                        tempgrid.AllowDrop = true;
                                        tempgrid.Opacity = 0.3;
                                    }
                                    else
                                    {
                                        tempgrid.AllowDrop = false;
                                        tempgrid.Opacity = 1;
                                    }
                                }
                                else if (input_TopSize >= float.Parse(User_TopSize) && output_TopSize < float.Parse(User_TopSize))
                                {
                                    tempgrid.AllowDrop = false;
                                    tempgrid.Opacity = 1;
                                }
                                else
                                {
                                    tempgrid.AllowDrop = true;
                                    tempgrid.Opacity = 0.3;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
}
