using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace RobotRecipeManager.Screens
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        public void On_Click(object sender, RoutedEventArgs e)
        {
            //if (Username.Text.ToString() != "" && Password.Password.ToString() != "")
            //{
            //    Console.WriteLine(Username.Text.ToString());
            //    Custom_Functions.Login_Check login = new Custom_Functions.Login_Check();
            //Tuple<bool, string> result = login.Check_Login(Username.Text.ToString(), Password.Password.ToString());
            Recipe_Creation win = new Recipe_Creation("SYSADMIN");// result.Item2);

                //if (result.Item1 == true)
                //{
                    this.Close();
                    win.Show();
            //    }
            //    else
            //        MessageBox.Show("Wrong Username or Password");
            //}
            //else
            //{
            //    MessageBox.Show("Please check Username or Password is Empty");
            //}
        }
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
    }
}
