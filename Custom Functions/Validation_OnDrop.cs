using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RobotRecipeManager.Custom_Functions
{
    class Validation_OnDrop
    {
        //public static string[] old_name = new string[100];
        public bool Validation_Check(DragEventArgs e)
        {
            MessageBox.Show("You Tried To Drop Image");

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(Recipe_Creation))
                {
                    string s = (window as Recipe_Creation).Top_Size.Text;
                    if (s == "")
                        return false;
                    else
                        return true;
                }
            }
            return false;
        }
        public void Validation_Check_Image(DesignerItem designerItem, Recipe_Creation recipe_Creation)
        {
            //bool check = true;
            Custom_Functions.Validation_OnTopSize validation = new Custom_Functions.Validation_OnTopSize();
            //DesignerItem designerItem = childElement as DesignerItem;
            if (designerItem != null)
            {
                //int current_connection = designerItem.Current_Connection_Cnt;
                //int max_connection = designerItem.Max_Connection_Cnt;
                //int current_sink_connection = designerItem.Current_Sink_Connection_Cnt;
                Grid tempgrid = (Grid)(designerItem.Content);
                string name = tempgrid.Name;
                //for (int i = 0; i < 100; i++)
                //{
                //    if (old_name[i] == name)
                //    {
                //        check = false;
                //        i = 100;
                //    }
                //    else if (old_name[i] == null)
                //    {
                //        break;
                //    }
                //}
                //MessageBox.Show(name);
                //if (check == true)
                //{
                    using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
                    using (SqlCommand sqlCommand = new SqlCommand("Select OUTPUT_TOPSIZE from[AU_RRM_EM].[dbo].LIMITS where STATION_ID = '" + name + "'", sqlConnection))
                    {
                        try
                        {
                            sqlConnection.Open();
                            SqlDataReader reader = sqlCommand.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string top_size = reader["OUTPUT_TOPSIZE"].ToString();
                                    //int child_node_num = Int32.Parse(reader["CHILD_NODE_NUM"].ToString());
                                    //Top_Size_Check.Add(num);
                                    //if (child_node_num <= 1)
                                    validation.Validation_TopSize(top_size, recipe_Creation);
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    //for (int i = 0; i < 100; i++)
                    //{
                    //    if (old_name[i] == null)
                    //    {
                    //        old_name[i] = name;
                    //        i = 100;
                    //    }
                    //}
                //}
            }
        }
    }
}

