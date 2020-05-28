using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using MessageBox = System.Windows.Forms.MessageBox;
//using ComponentOwl.BetterListView;

namespace RobotRecipeManager
{
    public partial class AddChart : Form
    {
        public ImageList m_imglst = new ImageList();
        public AddChart()
        {
            InitializeComponent();

        }

        private void AddChart_Load(object sender, EventArgs e)
        {
            listView1.LargeImageList = m_imglst;
            loadFile();
        }

        private void loadFile()
        {
            // string[] fileEntries = Directory.GetFiles(Recipe_Creation.g_AppPath);
            //FileInfo[] fileEntries = new DirectoryInfo(Recipe_Creation.g_AppPath)
            //            .GetFiles();
            ////.OrderBy(f => f.CreationTime)
            ////.ToArray();
            string path = "logo.txt";
            string[] fileEntries;
            if (File.Exists(path))
            {
                fileEntries = File.ReadAllLines(path, Encoding.UTF8);
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
                    AddChartItem(fileName,false);
                }
                catch (Exception)
                {

                }
            }            
        }

        private void AddChartItem(string line,bool bcopy)
        {
            string[] templst;
            string name = "";
            string showname = "";
            templst = line.Split('\\');
            if (templst.Length > 0)
            {
                name = templst.Last();
            }
            else
            {
                templst = line.Split('/');
                if (templst.Length > 0)
                    name = templst.Last();
            }
            string[] namelst = name.Split('.');
            if (namelst.Length > 1)
                showname = namelst[0];
            int index = -1;
            if(bcopy)
            {
               if(File.Exists(Recipe_Creation.g_AppPath + name))
                {
                    DialogResult dialogResult = MessageBox.Show("Alert", "Do you want to overwrite image?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {                           
                            File.Delete(Recipe_Creation.g_AppPath + name);
                            File.Copy(line, Recipe_Creation.g_AppPath + name);

                            index = m_imglst.Images.Keys.IndexOf(name);

                            //m_imglst.Images.RemoveByKey(name);
                            listView1.Items.RemoveAt(index);
                            DirectoryInfo dir = new DirectoryInfo(Recipe_Creation.g_AppPath);

                            dir.Refresh();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                        //do something
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
                else
                {
                    try
                    {
                        File.Copy(line, Recipe_Creation.g_AppPath + name);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
                

            //if (m_imglst.Images.Keys.Contains(name))
            //    return;
            FileStream stream = new FileStream(Recipe_Creation.g_AppPath + name, FileMode.Open, FileAccess.Read);
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

        private void btn_add_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();            
            openFileDialog.Filter = "Image Files(*.png;*.BMP; *.JPG; *.GIF)|*.png; *.BMP; *.JPG; *.GIF | All files(*.*) | *.*"; 
           
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "My Chart Image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                                   
                foreach (String file in openFileDialog.FileNames)
                {                    
                    try
                    {
                        AddChartItem(file,true);
                    }
                    catch (Exception)
                    {

                    }
                
                }
               // saveFile();
            }
        }

        private void saveFile()
        {

            using (StreamWriter sw = File.CreateText(Recipe_Creation.m_ChartPath))
            {
                foreach (string imgkey in m_imglst.Images.Keys)
                {
                    sw.WriteLine(imgkey);
                }
                sw.Close();
            }
            
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView1.SelectedItems)
            {
               // m_imglst.Images.RemoveByKey(eachItem.ImageKey);
                listView1.Items.Remove(eachItem);
                File.Delete(Recipe_Creation.g_AppPath + eachItem.ImageKey);
            }
           // saveFile();
        }

        private void AddChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = "logo.txt";
            int nlen = listView1.Items.Count;
            string[] createText = new string[nlen];
            for(int i = 0; i < nlen; i++)
            {
                createText[i] = Recipe_Creation.g_AppPath + listView1.Items[i].ImageKey;
                //createText[i]= Recipe_Creation.g_AppPath + listView1.LargeImageList.Images.Keys[i];
               
            }
            File.WriteAllLines(path, createText, Encoding.UTF8);
            
        }
    }
}
