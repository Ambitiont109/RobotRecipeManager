using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace RobotRecipeManager
{
    public partial class AddChart : Form
    {
        public ImageList m_imglst = new ImageList();
        public string file_path = "";
        string showname = "", station_link = "";
        public AddChart()
        {
            InitializeComponent();
        }

        private void loadFile()
        {
            listView1.Clear();
            Recipe_Creation.g_AppPath = AppDomain.CurrentDomain.BaseDirectory + "Images\\";
            string[] image_name = new string[100];
            string temp_path = "";
            int i = 0;
            if (!Directory.Exists(Recipe_Creation.g_AppPath))
            {
                _ = Directory.CreateDirectory(Recipe_Creation.g_AppPath);
            }
            else
            {
                using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("Select IMAGE_NAME from[AU_RRM_EM].[dbo].LIMITS Order By POSITION;", sqlConnection))
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
                                if (name != "" && name != null)
                                {
                                    image_name[i] = name;
                                    i++;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            int index = -1;
            for (i = 0; i < 100; i++)
            {
                if (image_name[i] != "" && image_name[i] != null)
                {
                    temp_path = Recipe_Creation.g_AppPath + image_name[i] + ".png";
                    try
                    {
                        string[] templst;
                        string name = "";
                        showname = image_name[i];
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
                        FileStream stream = new FileStream(temp_path, FileMode.Open, FileAccess.Read);
                        Image tempimg = Image.FromStream(stream);
                        stream.Close();
                        //Image tempimg  = Image.FromFile(Recipe_Creation.g_AppPath + name);

                        m_imglst.Images.Add(name, tempimg);
                        // tell your ListView to use the new image list

                        // add an item
                        if (index >= 0)
                        {
                            var listViewItem = listView1.Items.Insert(index, showname);
                            listViewItem.ImageKey = name;
                        }
                        else
                        {
                            var listViewItem = listView1.Items.Add(showname);
                            listViewItem.ImageKey = name;
                        }
                        listView1.Invalidate();
                        // and tell the item which image to use
                    }
                    catch
                    {

                    }
                }
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            //if (File_Name.Text != "" && Station_ID_Link.Text != "" && listView1.SelectedItems.Count > 0)
            //{
            //    if (file_path != "")
            //    {
            //        AddChartItem(file_path, true);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please select new Image before trying to add");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please enter Display Image Name and assign it to the station");
            //}
            if (File_Name.Text != "")
            {
                if (Station_ID_Link.Text != "")
                {
                    if (CHILD_NODE_NUM.Text != "")
                    {
                        if (STATION_OUT.Text != "")
                        {
                            if (listView1.SelectedItems.Count > 0)
                            {
                                if (file_path != "")
                                {
                                    AddChartItem(file_path, true);
                                }
                                else
                                {
                                    MessageBox.Show("Please Select New Image before clicking on Add button");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please Select Image from List View before Clicking Add Button");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select Station Output True or False");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Number of Child Nodes for the WorkStation");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select workstation you want to assign the Image");
                }
            }
            else
            {
                MessageBox.Show("Please Enter the Image Display Name");
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            //foreach (ListViewItem eachItem in listView1.SelectedItems)
            //{
            //    // m_imglst.Images.RemoveByKey(eachItem.ImageKey);
            //    listView1.Items.Remove(eachItem);
            //    File.Delete(Recipe_Creation.g_AppPath + eachItem.ImageKey);
            //}
            if (listView1.SelectedItems.Count > 0)
            {
                //string name = listView1.SelectedItems[0].Text;
                using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("Update [AU_RRM_EM].dbo.[LIMITS] SET IMAGE_NAME = '' where IMAGE_NAME = '" + listView1.SelectedItems[0].Text + "';", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        File.Delete(Recipe_Creation.g_AppPath + listView1.SelectedItems[0].Text + ".png");
                        listView1.SelectedItems[0].Remove();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Update Query to Database has failed");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Image to be Deleted");
            }
        }

        private void AddChart_Load(object sender, EventArgs e)
        {
            listView1.LargeImageList = m_imglst;
            loadFile();
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            using (SqlCommand sqlCommand = new SqlCommand("Select STATION_ID from [AU_RRM_EM].dbo.[LIMITS] Order By Position", sqlConnection))
            {
                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string name = reader["STATION_ID"].ToString();
                            this.Station_ID_Link.Items.Add(name);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Database Link Broken");
                    return;
                }
            }
        }

        private void Select_Image_Click(object sender, EventArgs e)
        {
            if (File_Name.Text == "" && Station_ID_Link.Text == "")
            {
                MessageBox.Show("Please enter Image Display Name and Select Workstation");
            }
            else
            {
                showname = File_Name.Text;
                station_link = Station_ID_Link.Text;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files(*.png;*.BMP; *.JPG; *.GIF)|*.png; *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";

                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;
                openFileDialog.Title = "Robot_Recipe_Images";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    foreach (String file in openFileDialog.FileNames)
                    {
                        try
                        {
                            file_path = file;
                            string[] templst;
                            string name = "";
                            templst = file.Split('\\');
                            if (templst.Length > 0)
                            {
                                name = templst.Last();
                            }
                            else
                            {
                                templst = file.Split('/');
                                if (templst.Length > 0)
                                    name = templst.Last();
                            }
                            FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                            Image tempimg = Image.FromStream(stream);
                            stream.Close();
                            m_imglst.Images.Add(name, tempimg);
                            var listViewItem = listView1.Items.Add(showname);
                            listViewItem.ImageKey = name;
                            listView1.Invalidate();
                        }
                        catch (Exception)
                        {
                            return;
                        }
                    }
                }
            }
        }

        private void AddChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            int nlen = listView1.Items.Count;
            //string[] createText = new string[nlen];
            for (int i = 0; i < nlen; i++)
            {
                //string image_name = Path.GetFileNameWithoutExtension(listView1.Items[i].ImageKey); 
                //image_name = image_name.Split('.');
                using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("Update [AU_RRM_EM].dbo.[LIMITS] SET POSITION = '" + i + "' where IMAGE_NAME = '" + Path.GetFileNameWithoutExtension(listView1.Items[i].ImageKey) + "';", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Update Query to Database has failed");
                        return;
                    }
                }
                //createText[i] = Recipe_Creation.g_AppPath + listView1.Items[i].ImageKey;
            }
        }

        private void AddChartItem(string line, bool bcopy)
        {
            string name = "";
            showname = File_Name.Text;
            station_link = Station_ID_Link.Text;
            
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            using (SqlCommand sqlCommand = new SqlCommand("Select IMAGE_NAME from [AU_RRM_EM].dbo.[LIMITS] where STATION_ID = '" + station_link + "';", sqlConnection))
            {
                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            name = reader["IMAGE_NAME"].ToString();
                            if (name == "" || name == "NULL" || name == null)
                            {
                                bcopy = true;
                            }
                            else
                            {
                                bcopy = false;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Database Link Broken");
                    return;
                }
            }
            if (bcopy == true)
            {
                {
                    using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
                    using (SqlCommand sqlCommand = new SqlCommand("Update [AU_RRM_EM].dbo.[LIMITS] SET IMAGE_NAME = '" + showname + 
                                                                  "' ,CHILD_NODE_NUM = '" + CHILD_NODE_NUM.Text + "' ,STATION_OUT = '" +
                                                                  STATION_OUT.Text+ "' where STATION_ID = '" + station_link + "';", sqlConnection))
                    {
                        try
                        {
                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            File.Copy(line, Recipe_Creation.g_AppPath + showname + ".png");
                            MessageBox.Show("Image Added Successfully");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Update Query to Database has failed");
                            return;
                        }
                    }
                }
            }
            else if (bcopy == false)
            {
                DialogResult dialogResult = MessageBox.Show("Alert", "Do you want to overwrite image?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
                    using (SqlCommand sqlCommand = new SqlCommand("Update [AU_RRM_EM].dbo.[LIMITS] SET IMAGE_NAME = '" + showname +
                                                                  "' ,CHILD_NODE_NUM = '" + CHILD_NODE_NUM.Text + "' ,STATION_OUT = '" +
                                                                  STATION_OUT.Text + "' where STATION_ID = '" + station_link + "';", sqlConnection))
                    {
                        try
                        {
                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            File.Delete(Recipe_Creation.g_AppPath + showname + ".png");
                            File.Copy(line, Recipe_Creation.g_AppPath + showname + ".png");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Update Query to Database has failed");
                            return;
                        }
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            loadFile();

        }
    }
}
