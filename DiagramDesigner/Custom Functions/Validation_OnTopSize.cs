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


namespace RobotRecipeManager.Custom_Functions
{
    class Validation_OnTopSize
    {
        //public static bool check = true;
        public void Validation_TopSize(object sender, SelectionChangedEventArgs e, string TopSize, Recipe_Creation recipe_Creation)
        {
            MessageBox.Show("Tried To change Text");
            if (TopSize == "50")
            {
                MessageBox.Show("Topsize is 50");
                // Place code where I get Image names in variable and place a code so that I can disable or enable Image By disable I mean the image gets grey and not allowed to be used.
 //               Recipe_Creation recipe_Creation = new Recipe_Creation();
                Toolbox temp = (Toolbox)(recipe_Creation.Flow_Chart.Content);
                Grid tempgrid = (Grid)(temp.Items[0]);
                Image image = new Image();
                //Image image = (Image)(tempgrid.GetValue);
                //BitmapImage bitmap = (BitmapImage)(recipe_Creation.Flow_Chart.Content);
                int row = 0;
                int column = 0;
                foreach (UIElement child in tempgrid.Children)
                {
                    if (Grid.GetRow(child) == row && Grid.GetColumn(child) == column)
                    {
                        if (child.GetType() == image.GetType())
                        {
                            image = (Image)(child);
                            //child.;
                        }
                    }
                }
                MessageBox.Show(image.Source.ToString());
                //image.AllowDrop = false;
                //tempgrid.AllowDrop = true;
                //check = false;
                //tempgrid.Visibility = Visibility.Hidden;
                
            }
        }
    }
}
