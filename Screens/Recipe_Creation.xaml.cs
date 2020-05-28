using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace RobotRecipeManager
{
    public partial class Recipe_Creation : Window
    {
        public static string m_ChartPath = "Images//";
        public static string g_AppPath = "";
        public static List<float> Top_Size_Check = new List<float>();
        public static string Role = "";

        public Recipe_Creation()
        {
            InitializeComponent();
            //this.Loaded += new RoutedEventHandler(Recipe_Creation_Loaded);
            //MessageBox.Show("There");
        }
        public Recipe_Creation(string user_Role)
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Recipe_Creation_Loaded);
            g_AppPath = System.AppDomain.CurrentDomain.BaseDirectory;
            Role = user_Role;
            //preload_chart();
            //YourCommand();
            if (Role != "SYSADMIN")
            {
                Add_Remove_Img.Visibility = Visibility.Hidden;
            }

        }

        void Recipe_Creation_Loaded(object sender, RoutedEventArgs e)
        {
            preload_chart();
            YourCommand();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {

            Regex regex = new Regex(@"^\d*\.?\d*$");//[^0-9]+");
            e.Handled = !regex.IsMatch(e.Text);
        }

        public void preload_chart()
        {
            g_AppPath = System.AppDomain.CurrentDomain.BaseDirectory + "Images\\";
            Toolbox temp = (Toolbox)(this.Flow_Chart.Content);
            string[] image_name = new string[100];
            string[] station_id = new string[100];
            int i = 0;
            temp.Items.Clear();
            if (!Directory.Exists(m_ChartPath))
            {
                _ = Directory.CreateDirectory(g_AppPath);
            }
            else
            {
                using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("Select STATION_ID,IMAGE_NAME from[AU_RRM_EM].[dbo].LIMITS Order By POSITION", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string name = reader["IMAGE_NAME"].ToString();
                                string station = reader["STATION_ID"].ToString();
                                //Top_Size_Check.Add(num);
                                if (name != "" && name != null)
                                {
                                    image_name[i] = name;
                                    station_id[i] = station;
                                    i++;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                    //Top_Size.ItemsSource = Top_Size_Check.OrderByDescending(n => n).ToList();
                    //Top_Size_Check = null;
                }
                for (i = 0; i < 100; i++)
                {
                    //string fileName = fileinfo.FullName;
                    if (image_name[i] != "" && image_name[i] != null)
                    {
                        string temp_path = g_AppPath + image_name[i] + ".png";
                        try
                        {
                            string[] templst;
                            //string new_name = "";
                            string name = "";
                            templst = temp_path.Split('\\');
                            if (templst.Length > 0)
                            {
                                name = templst.Last();
                            }
                            else
                            {
                                templst = temp_path.Split('/');
                                if (templst.Length > 0)
                                    name = templst.Last();
                            }
                            string[] namelst = name.Split('.');
                            if (namelst.Length > 1)
                                name = namelst[0];

                            //int index1 = name.IndexOf('_', 0);
                            //int index2 = name.IndexOf('_', 5);

                            //if (index2 == -1)
                            //{
                            //new_name = name.Remove(0, index1 + 1);
                            //}
                            //else
                            //{
                            //    new_name = name.Remove(0, index1 + 1);
                            // }

                            Image tempimg = new Image();
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                            bitmap.UriSource = new Uri(temp_path, UriKind.RelativeOrAbsolute);
                            bitmap.CacheOption = BitmapCacheOption.OnLoad;
                            bitmap.EndInit();
                            tempimg.Source = bitmap;
                            //  tempimg.Height = 30;
                            //  tempimg.Width = 30;
                            TextBlock txtBlock1 = new TextBlock();
                            txtBlock1.Text = name;
                            txtBlock1.FontSize = 9.5;
                            txtBlock1.FontWeight = FontWeights.Bold;
                            //txtBlock1.Foreground = new SolidColorBrush(Colors.Green);
                            txtBlock1.VerticalAlignment = VerticalAlignment.Bottom;
                            txtBlock1.TextAlignment = TextAlignment.Center;

                            Grid tempgrid = new Grid();
                            //tempgrid.HorizontalAlignment = HorizontalAlignment.;
                            tempgrid.VerticalAlignment = VerticalAlignment.Center;

                            //tempgrid.ShowGridLines = true;
                            //tempgrid.Background = new SolidColorBrush(Colors.LightSteelBlue);
                            tempgrid.Width = 50;
                            //tempgrid.Height = 50;


                            ColumnDefinition gridCol1 = new ColumnDefinition();
                            tempgrid.ColumnDefinitions.Add(gridCol1);

                            RowDefinition gridRow1 = new RowDefinition();
                            gridRow1.Height = new GridLength(45);
                            RowDefinition gridRow2 = new RowDefinition();
                            gridRow2.Height = new GridLength(16);
                            //ColumnDefinition gridCol2 = new ColumnDefinition();
                            //gridCol2.Width = new GridLength(40,GridUnitType.Star);
                            tempgrid.RowDefinitions.Add(gridRow1);
                            tempgrid.RowDefinitions.Add(gridRow2);

                            Grid.SetRow(tempimg, 0);
                            Grid.SetColumn(tempimg, 0);
                            tempgrid.Children.Add(tempimg);
                            Grid.SetRow(txtBlock1, 1);
                            Grid.SetColumn(txtBlock1, 0);
                            tempgrid.Name = station_id[i];
                            //tempgrid.AllowDrop = false;
                            tempgrid.Children.Add(txtBlock1);
                            tempgrid.AllowDrop = true;
                            tempgrid.Opacity = 0.3;
                            temp.Items.Add(tempgrid);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else
                    {
                        i = 100;
                    }
                }

            }
        }
        private void Chart_Click(object sender, RoutedEventArgs e)
        {
            AddChart dlg = new AddChart();
            dlg.ShowDialog();
            preload_chart();
        }

        public void YourCommand()
        {

            //using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            //using (SqlCommand sqlCommand = new SqlCommand("Select DISTINCT TOPSIZE from[AU_RRM_EM].[dbo].TOPSIZE;", sqlConnection))
            ////("SELECT DISTINCT code FROM(SELECT DISTINCT INPUT_TOPSIZE FROM[AU_RRM_EM].[dbo].[LIMITS] " +
            ////"UNION SELECT DISTINCT OUTPUT_TOPSIZE FROM[AU_RRM_EM].[dbo].[LIMITS]" +
            ////") AS DistinctCodes(code) WHERE code <> ''; ", sqlConnection))
            //{
                Top_Size_Check.Add(50);
                //try
                //{
                //    sqlConnection.Open();
                //    //float intList = (float)
                //    SqlDataReader reader = sqlCommand.ExecuteReader();
                //    if (reader.HasRows)
                //    {
                //        while (reader.Read())
                //        {
                //            float num = float.Parse(reader["TOPSIZE"].ToString());
                //            Top_Size_Check.Add(num);
                //        }
                //    }
                //}
                //catch (Exception)
                //{
                //}
                Top_Size.ItemsSource = Top_Size_Check.OrderByDescending(n => n).ToList();
                Top_Size_Check = null;
            //}
            string s = this.Top_Size.Text;
            if (s == "")
                MessageBox.Show("Please Select Top Size Before Continuing");
        }
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void Top_Size_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string TopSize = Top_Size.SelectedItem.ToString();//Top_Size.Text;
            Custom_Functions.Validation_OnTopSize validation_TopSize = new Custom_Functions.Validation_OnTopSize();
            validation_TopSize.Validation_TopSize(TopSize, this);
        }
    }
}