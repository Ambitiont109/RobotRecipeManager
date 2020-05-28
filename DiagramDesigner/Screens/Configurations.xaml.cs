using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RobotRecipeManager.Screens
{
    /// <summary>
    /// Interaction logic for Configurations.xaml
    /// </summary>
    public partial class Configurations : Window
    {
        public Configurations()
        {
            InitializeComponent();
        }

		private void btnPreviousTab_Click(object sender, RoutedEventArgs e)
		{
			int newIndex = Tab_Ctrl.SelectedIndex - 1;
			if (newIndex < 0)
				newIndex = Tab_Ctrl.Items.Count - 1;
			Tab_Ctrl.SelectedIndex = newIndex;
		}

		private void btnNextTab_Click(object sender, RoutedEventArgs e)
		{
			int newIndex = Tab_Ctrl.SelectedIndex + 1;
			if (newIndex >= Tab_Ctrl.Items.Count)
				newIndex = 0;
			Tab_Ctrl.SelectedIndex = newIndex;
		}

		private void btnSelectedTab_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Selected tab: " + (Tab_Ctrl.SelectedItem as TabItem).Header);
		}
	}
}
