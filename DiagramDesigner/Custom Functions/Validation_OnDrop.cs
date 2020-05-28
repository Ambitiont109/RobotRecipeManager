using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace RobotRecipeManager.Custom_Functions
{
    class Validation_OnDrop
    {
        public bool Validation_Check(DragEventArgs e)
        {
            //MessageBox.Show("You Tried To Drop Image");

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
        // Place code where I check Image name which has been tried to dropped I need the name of the Image so that I can put conditions and allow or disallow user
    }
}
