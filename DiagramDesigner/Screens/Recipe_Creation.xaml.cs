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
        //public static string Role = "";

        public Recipe_Creation()//string user_Role)
        {
            InitializeComponent();
            //g_AppPath = System.AppDomain.CurrentDomain.BaseDirectory;
            //Role = user_Role;
            preload_chart();
            YourCommand();
            //if (Role != "SYSADMIN")
            //{
            //    Add_Remove_Img.Visibility = Visibility.Hidden;
            //}

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {

            Regex regex = new Regex(@"^\d*\.?\d*$");//[^0-9]+");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void preload_chart()
        {
            g_AppPath = System.AppDomain.CurrentDomain.BaseDirectory + "Images\\";
            Toolbox temp = (Toolbox)(this.Flow_Chart.Content);

            temp.Items.Clear();
            if (!Directory.Exists(m_ChartPath))
            {
                _ = Directory.CreateDirectory(g_AppPath);
            }
            else
            {
                //string[] fileEntries = Directory.GetFiles(g_AppPath);
                //FileInfo[] fileEntries = new DirectoryInfo(g_AppPath)
                //        .GetFiles()
                //        .OrderBy(f => f.CreationTime)
                //        .ToArray();
                string path = "logo.txt";
                string[] fileEntries;
                if (File.Exists(path))
                {
                    fileEntries = File.ReadAllLines(path, System.Text.Encoding.UTF8);
                }
                else
                {
                    fileEntries = Directory.GetFiles(Recipe_Creation.g_AppPath);
                }

                foreach (string fileName in fileEntries)
                {
                    //string fileName = fileinfo.FullName;
                    try
                    {
                        string[] templst;
                        string name = "";
                        templst = fileName.Split('\\');
                        if (templst.Length > 0)
                        {
                            name = templst.Last();
                        }
                        else
                        {
                            templst = fileName.Split('/');
                            if (templst.Length > 0)
                                name = templst.Last();
                        }
                        string[] namelst = name.Split('.');
                        if (namelst.Length > 1)
                            name = namelst[0];

                        Image tempimg = new Image();
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                        bitmap.UriSource = new Uri(fileName, UriKind.RelativeOrAbsolute);
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                        tempimg.Source = bitmap;
                        //  tempimg.Height = 30;
                        //  tempimg.Width = 30;
                        TextBlock txtBlock1 = new TextBlock();
                        txtBlock1.Text = name;
                        txtBlock1.FontSize = 12;
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
                        gridRow2.Height = new GridLength(20);
                        tempgrid.RowDefinitions.Add(gridRow1);
                        tempgrid.RowDefinitions.Add(gridRow2);

                        Grid.SetRow(tempimg, 0);
                        Grid.SetColumn(tempimg, 0);
                        tempgrid.Children.Add(tempimg);
                        Grid.SetRow(txtBlock1, 1);
                        Grid.SetColumn(txtBlock1, 0);
                        tempgrid.Name = name;
                        //tempgrid.AllowDrop = false;
                        tempgrid.Children.Add(txtBlock1);

                        temp.Items.Add(tempgrid);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
        private void Chart_Click(object sender, RoutedEventArgs e)
        {
            AddChart dlg = new AddChart();
            dlg.ShowDialog();
            preload_chart();
            // this.contentControl.Content = new UserControl2();
        }

        private void Top_Size_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public void YourCommand()
        {

            //using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            //using (SqlCommand sqlCommand = new SqlCommand("Select DISTINCT TOPSIZE from[AU_RRM_EM].[dbo].TOPSIZE;", sqlConnection))
            //("SELECT DISTINCT code FROM(SELECT DISTINCT INPUT_TOPSIZE FROM[AU_RRM_EM].[dbo].[LIMITS] " +
            //"UNION SELECT DISTINCT OUTPUT_TOPSIZE FROM[AU_RRM_EM].[dbo].[LIMITS]" +
            //") AS DistinctCodes(code) WHERE code <> ''; ", sqlConnection))
            //{
                Top_Size_Check.Add(50);
            //    try
            //    {
            //        sqlConnection.Open();
            //        //float intList = (float)
            //        SqlDataReader reader = sqlCommand.ExecuteReader();
            //        if (reader.HasRows)
            //        {
            //            while (reader.Read())
            //            {
            //                float num = float.Parse(reader["TOPSIZE"].ToString());
            //                Top_Size_Check.Add(num);
            //            }
            //        }
            //    }
            //    catch (Exception)
            //    {
            //    }
                Top_Size.ItemsSource = Top_Size_Check.OrderByDescending(n => n).ToList();
                Top_Size_Check = null;
            //}
            //string s = this.Top_Size.Text;
            //if (s == "")
            //    MessageBox.Show("Null");
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
            validation_TopSize.Validation_TopSize(sender, e, TopSize, this);
        }
    }
}