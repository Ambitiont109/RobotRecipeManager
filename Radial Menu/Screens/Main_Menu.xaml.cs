using System.Windows.Input;

namespace RobotRecipeManager
{
    /// <summary>
    /// Interaction logic for Main_Menu.xaml
    /// </summary>
    public partial class Main_Menu
    {
        public Main_Menu()
        {
            InitializeComponent();
            //if (Recipe_Creation.Role.Contains("ADMIN"))
            //    this.Configuration.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private void Configurations_Click(object sender, System.Windows.RoutedEventArgs e)
        {
         }

 

        private void button_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if(radialpanel!=null)
                radialpanel.Visibility = System.Windows.Visibility.Visible;
        }

        private void button_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if(radialpanel!=null)
                radialpanel.Visibility = System.Windows.Visibility.Collapsed;
        }

        //private new void Loaded()
        //{
        //    RadialPanel.OuterRadius = 300;
        //    RadialPanel.InnerRadius = 150;
        //    RadialPanel.IsClockwise = (bool)DirectionCheckBox.IsChecked;
        //    RadialPanel.InvalidateVisual();
        //    RadialPanel.ShowBorder = (bool)ShowBorderCheckBox.IsChecked;
        //    RadialPanel.InvalidateVisual();
        //    RadialPanel.ShowPieLines = (bool)ShowPieLinesCheckBox.IsChecked;
        //    RadialPanel.InvalidateVisual();

        //}
        //private void DirectionCheckBoxChecked(object sender, RoutedEventArgs e)
        //{
        //    if (DirectionCheckBox.IsChecked != null && RadialPanel != null)
        //    {
        //        RadialPanel.IsClockwise = (bool)DirectionCheckBox.IsChecked;

        //        RadialPanel.InvalidateVisual();
        //    }
        //}

        //private void ShowBorderCheckBoxChecked(object sender, RoutedEventArgs e)
        //{
        //    if (ShowBorderCheckBox.IsChecked != null && RadialPanel != null)
        //    {
        //        RadialPanel.ShowBorder = (bool)ShowBorderCheckBox.IsChecked;

        //        RadialPanel.InvalidateVisual();
        //    }
        //}

        //private void ShowPieLinesCheckBoxChecked(object sender, RoutedEventArgs e)
        //{
        //    if (ShowPieLinesCheckBox.IsChecked != null && RadialPanel != null)
        //    {
        //        RadialPanel.ShowPieLines = (bool)ShowPieLinesCheckBox.IsChecked;

        //        RadialPanel.InvalidateVisual();
        //    }
        //}

        //private void StartAngleTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (RadialPanel != null)
        //    {
        //        Double.TryParse(StartAngle.Text, out double val);
        //        RadialPanel.StartAngle = val;

        //        RadialPanel.InvalidateVisual();
        //    }
        //}

        //private void DisplayAngleTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (RadialPanel != null)
        //    {
        //        Double.TryParse(DisplayAngle.Text, out double val);
        //        RadialPanel.Angle = val;

        //        RadialPanel.InvalidateVisual();
        //    }
        //}

        //private void InnerRadiusTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (RadialPanel != null)
        //    {
        //        Double.TryParse(InnerRadius.Text, out double val);
        //        RadialPanel.InnerRadius = val;

        //        RadialPanel.InvalidateVisual();
        //    }
        //}

        //private void OuterRadiusTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (RadialPanel != null)
        //    {
        //        Double.TryParse(OuterRadius.Text, out double val);
        //        RadialPanel.OuterRadius = val;

        //        RadialPanel.InvalidateVisual();
        //    }
        //}
    }
}
