using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RobotRecipeManager.Custom_Functions
{
    class Create_Recipe
    {
        public void Create_Recipe_Data(DesignerItem source, DesignerItem sink)
        {
            Recipe_Creation recipe_Creation = new Recipe_Creation();
            if (source != null && sink!= null)
            {
                Grid tempgrid = (Grid)source.Content;
                Grid tempgrid1 = (Grid)sink.Content;
                MessageBox.Show("Source = " + tempgrid.Name.ToString());
                MessageBox.Show("Sink = " + tempgrid1.Name.ToString());
                DataTable employeeData = CreateDataTable();
                recipe_Creation.Show_Recipe.ItemsSource = employeeData.DefaultView;
            } 
        }
        public DataTable CreateDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Date", typeof(System.DateTime));
            table.Rows.Add("cat", System.DateTime.Now);
            table.Rows.Add("dog", System.DateTime.Today);
            return table;
        }
    }
}
